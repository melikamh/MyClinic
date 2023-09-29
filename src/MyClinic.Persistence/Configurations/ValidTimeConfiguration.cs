using MyClinic.Domain.Entities;
using MyClinic.Persistence.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyClinic.Domain.ValueObjects;

namespace MyClinic.Persistence.Configurations
{
    internal sealed class ValidTimeConfiguration : IEntityTypeConfiguration<ValidTime>
    {
        public void Configure(EntityTypeBuilder<ValidTime> builder)
        {
            builder.ToTable(TableNames.Patient);

            builder.HasKey(x => x.Id);

        }
    }
}
