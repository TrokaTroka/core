using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Infra.Configuration
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder
                .Property(b => b.Title)
                .IsRequired();
            builder
                .Property(b => b.Author)
                .IsRequired();
            builder
                .Property(b => b.Isbn)
                .IsRequired();
            builder
                .Property(b => b.Publisher)
                .IsRequired();
            builder
                .Property(b => b.Model)
                .IsRequired();
            builder
                .Property(b => b.Language)
                .IsRequired();
            builder
                .Property(b => b.Reason)
                .IsRequired();
            builder
                .Property(b => b.BuyPrice)
                .IsRequired();
            builder
                .Property(b => b.BuyDate)
                .IsRequired();
            builder
                .Property(b => b.IdUser)
                .IsRequired();

            builder
                 .HasOne(b => b.Owner)
                 .WithMany(u => u.Books)
                 .HasForeignKey(b => b.IdUser)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}