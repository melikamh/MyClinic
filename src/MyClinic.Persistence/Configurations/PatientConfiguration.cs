using MyClinic.Domain.Entities;
using MyClinic.Persistence.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyClinic.Domain.ValueObjects;

namespace MyClinic.Persistence.Configurations
{
    internal sealed class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable(TableNames.Patient);

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.NationalCode)
                .HasConversion(x => x.Value, v => NationalCode.Create(v).Value);
            builder
                .Property(x => x.FirstName)
                .HasConversion(x => x.Value, v => FirstName.Create(v).Value)
                .HasMaxLength(FirstName.MaxLength);

            builder
                .Property(x => x.LastName)
                .HasConversion(x => x.Value, v => LastName.Create(v).Value)
                .HasMaxLength(LastName.MaxLength);

            builder.HasIndex(x => x.NationalCode).IsUnique();

        }
    }
}
