using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Infra.Configuration
{
    public class PhotoMapping : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Path)
                .IsRequired();
            builder
                .Property(p => p.Name)
                .IsRequired();
            builder
                .Property(p => p.IdBook)
                .IsRequired();

            builder
                 .HasOne(p => p.Book)
                 .WithMany(b => b.Photos)
                 .HasForeignKey(p => p.IdBook)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
