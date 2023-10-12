using MyClinic.Domain.Entities;
using MyClinic.Persistence.Constants;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyClinic.Persistence.Configurations
{
    internal sealed class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable(TableNames.Appointment);

            builder.HasKey(x => x.Id);

            builder
                .HasOne<Patient>()
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne<ValidTimeDoctor>()
               .WithMany()
               .HasForeignKey(x => x.ValidTimeDoctorId);
        }
    }

}
