using MyClinic.Domain.Entities;
using MyClinic.Domain.Primitives;
using MyClinic.Persistence.Constants;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyClinic.Domain.ValueObjects;

namespace MyClinic.Persistence.Configurations
{
    internal sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable(TableNames.Doctor);

            builder.HasKey(x => x.Id);

            
            builder
                .Property(x => x.FirstName)
                .HasConversion(x => x.Value, v => FirstName.Create(v).Value)
                .HasMaxLength(FirstName.MaxLength);

            builder
                .Property(x => x.LastName)
                .HasConversion(x => x.Value, v => LastName.Create(v).Value)
                .HasMaxLength(LastName.MaxLength);

        }
    }

}
