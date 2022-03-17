using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Infra.Configuration
{
    public class TradeMapping : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder
                .HasKey(t => t.Id);
        }
    }
}