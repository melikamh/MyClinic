using MyClinic.Domain.Primitives;
using System.Diagnostics.Metrics;

namespace MyClinic.Domain.Entities
{
    /// <summary>
    /// وقت ملاقات پزشک و بیمار
    /// </summary>
    public class Appointment : Entity
    {
        private readonly List<ValidTimeDoctor> _validTimeDoctors = new();

        private Appointment(int id, int validTimeDoctorId, int patientId) : base(id)
        {
            ValidTimeDoctorId = validTimeDoctorId;
            PatientId = patientId;
        }

        private Appointment()
        { }
        /// <summary>
        /// رفرنس به موجودیت ValidTimeDoctor
        /// </summary>
        public int ValidTimeDoctorId { get; set; }

        /// <summary>
        /// شناسه بیمار
        /// </summary>
        public int PatientId { get; set; }
        public IReadOnlyCollection<ValidTimeDoctor> ValidTimeDoctors => _validTimeDoctors;

        public static Appointment Create(
            int id,
            int validTimeDoctorId,
            int patientId
            )
        {
            var member = new Appointment(
                id,
                validTimeDoctorId,
                patientId);

            return member;
        }
    }
}