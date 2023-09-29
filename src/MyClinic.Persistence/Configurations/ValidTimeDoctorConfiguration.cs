
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyClinic.Domain.Entities;
using MyClinic.Domain.ValueObjects;
using MyClinic.Persistence.Constants;

namespace MyClinic.Persistence.Configurations
{
    internal sealed class ValidTimeDoctorConfiguration : IEntityTypeConfiguration<ValidTimeDoctor>
    {
        public void Configure(EntityTypeBuilder<ValidTimeDoctor> builder)
        {
            builder.ToTable(TableNames.ValidTimeDoctor);

            builder.HasKey(x => x.Id);

        }
    }

}
