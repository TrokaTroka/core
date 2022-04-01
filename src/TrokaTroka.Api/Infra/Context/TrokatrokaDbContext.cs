using Microsoft.EntityFrameworkCore;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Infra.Context
{
    public class TrokatrokaDbContext : DbContext
    {
        public TrokatrokaDbContext(DbContextOptions<TrokatrokaDbContext> options) 
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<PhotosBook> PhotosBooks { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrokatrokaDbContext).Assembly);
        }
    }
}