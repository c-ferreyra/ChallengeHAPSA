using ChallengeHAPSA.Domain.Horses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeHAPSA.Repository.EFCore.Context.Configurations
{
    public class HorseConfiguration : IEntityTypeConfiguration<Horse>
    {
        public void Configure(EntityTypeBuilder<Horse> builder)
        {
            _ = builder.ToTable("Horses");

            _ = builder.HasKey(h => h.Id);

            // el Id lo genera el dominio
            _ = builder.Property(h => h.Id).ValueGeneratedNever();

            _ = builder.Property(h => h.Name)
                .IsRequired()
                .HasMaxLength(100);

            _ = builder.Property(h => h.Birthday)
                .IsRequired()
                .HasColumnType("datetime2");

            _ = builder.Property(h => h.Status)
                .IsRequired()
                .HasDefaultValue(true);

            _ = builder.Property(h => h.Type)
                .IsRequired();

            // respalda IHorseRepository.NameInUse
            _ = builder.HasIndex(h => h.Name).IsUnique();
        }
    }
}
