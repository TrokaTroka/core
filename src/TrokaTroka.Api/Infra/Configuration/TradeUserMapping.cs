using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Infra.Configuration
{
    public class TradeUserMapping : IEntityTypeConfiguration<TradeUser>
    {
        public void Configure(EntityTypeBuilder<TradeUser> builder)
        {
            builder
                .HasKey(tu => new { tu.IdUser, tu.IdTrade });
        }
    }
}