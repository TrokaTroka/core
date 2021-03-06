// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrokaTroka.Api.Infra.Context;

namespace TrokaTroka.Api.Migrations
{
    [DbContext(typeof(TrokatrokaDbContext))]
    partial class TrokatrokaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("TrokaTroka.Api.Models.Book", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("BuyDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("IdTrade")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("IdUser")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("TrokaTroka.Api.Models.BookCategory", b =>
                {
                    b.Property<byte[]>("IdBook")
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("IdCategory")
                        .HasColumnType("varbinary(16)");

                    b.HasKey("IdBook", "IdCategory");

                    b.ToTable("BookCategories");
                });

            modelBuilder.Entity("TrokaTroka.Api.Models.Category", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TrokaTroka.Api.Models.PhotosBook", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("IdBook")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdBook");

                    b.ToTable("PhotosBooks");
                });

            modelBuilder.Entity("TrokaTroka.Api.Models.Rating", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<byte[]>("IdRated")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("IdRater")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdRated");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("TrokaTroka.Api.Models.RefreshToken", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("Token")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("TrokaTroka.Api.Models.Trade", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("TradeDate")
                        .HasColumnType("datetime");

                    b.Property<int>("TradeStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Trades");
                });

            modelBuilder.Entity("TrokaTroka.Api.Models.TradeUser", b =>
                {
                    b.Property<byte[]>("IdUser")
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("IdTrade")
                        .HasColumnType("varbinary(16)");

                    b.HasKey("IdUser", "IdTrade");

                    b.ToTable("TradeUser");
                });

            modelBuilder.Entity("TrokaTroka.Api.Models.User", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("AvatarName")
                        .HasColumnType("text");

                    b.Property<string>("AvatarPath")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Document")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TrokaTroka.Api.Models.Book", b =>
                {
                    b.HasOne("TrokaTroka.Api.Models.User", "Owner")
                        .WithMany("Books")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("TrokaTroka.Api.Models.PhotosBook", b =>
                {
                    b.HasOne("TrokaTroka.Api.Models.Book", "Book")
                        .WithMany("PhotosBooks")
                        .HasForeignKey("IdBook")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("TrokaTroka.Api.Models.Rating", b =>
                {
                    b.HasOne("TrokaTroka.Api.Models.User", "RatedUser")
                        .WithMany("Ratings")
                        .HasForeignKey("IdRated")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RatedUser");
                });

            modelBuilder.Entity("TrokaTroka.Api.Models.Book", b =>
                {
                    b.Navigation("PhotosBooks");
                });

            modelBuilder.Entity("TrokaTroka.Api.Models.User", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
