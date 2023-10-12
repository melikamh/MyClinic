using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using MyClinic.Application.Apoitment.Commands;
using MyClinic.Application.Logic;
using MyClinic.Domain.DomainEvents;
using MyClinic.Domain.Entities;
using MyClinic.Domain.Enums;
using MyClinic.Domain.Repositories;
using MyClinic.Persistence.Repositories;
using NUnit.Framework;


namespace MyClinic.Application.IntegrationTests
{
    [TestFixture]
    public class SetAppointmentQueryHandlerIntegrationTest
    {
        private SetAppointmentQueryHandler handler;
        private Mock<IAppointmentReserverByTime> appointmentReserver;
        private Mock<IAppointmentRepository> appointmentRepositoryMock;
        private Mock<IValidTimeDoctorRepository> validTimeDoctorRepositoryMock;
        private Mock<IUnitOfWork> unitOfWorkMock;

        [SetUp]
        public void Setup()
        {
            appointmentReserver = new Mock<IAppointmentReserverByTime>();
            appointmentRepositoryMock = new Mock<IAppointmentRepository>();
            validTimeDoctorRepositoryMock = new Mock<IValidTimeDoctorRepository>();
            unitOfWorkMock = new Mock<IUnitOfWork>();

            // Create instances for any other dependencies if needed.

            handler = new SetAppointmentQueryHandler(
                appointmentRepositoryMock.Object,
                appointmentReserver.Object,
                validTimeDoctorRepositoryMock.Object,
                unitOfWorkMock.Object
            );
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up or reset your mocks if needed
        }

        [Test]
        public async Task Handle_ValidAppointment_ReturnsAppointment()
        {
            // Arrange

           
            var request = new SetAppointment(
                 1,
                 1,
                 DateTime.Now,
                 TimeSpan.Parse("09:00 AM")
            );

           
            appointmentRepositoryMock.Setup(repo => repo.Add(It.IsAny<Appointment>())).Verifiable();
            //validTimeDoctorRepositoryMock
            // .Setup(repo => repo.GetAvailableDoctorByDate(request.doctorId, request.date).Result.ToList())
            // .ReturnsAsync(new List<ValidTimeDoctor>()); // Adjust to provide valid data


            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.That(result.Value, Is.TypeOf<Appointment>());

            // Verify that the appointment was added to the repository
            appointmentRepositoryMock.Verify(repo => repo.Add(It.IsAny<Appointment>()), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(CancellationToken.None), Times.Once);
        }
    }
}
