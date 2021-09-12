﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Infrastructure.Migrations
{
    [DbContext(typeof(VideoGameSalesDbContext))]
    partial class VideoGameSalesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VideoGameSales.Domain.Entities.Conectors.GamesToPlataform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Games_id")
                        .HasColumnType("int");

                    b.Property<int>("Platform_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Games_id");

                    b.HasIndex("Platform_id");

                    b.ToTable("GamesToPlataform");
                });

            modelBuilder.Entity("VideoGameSales.Domain.Entities.Conectors.PublishersToGames", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Games_id")
                        .HasColumnType("int");

                    b.Property<int>("Publishers_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Publishers_id")
                        .IsUnique();

                    b.ToTable("PublishersToGames");
                });

            modelBuilder.Entity("VideoGameSales.Domain.Entities.Games.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ranks")
                        .HasColumnType("int");

                    b.Property<int>("Release_year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("VideoGameSales.Domain.Entities.Platforms.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Platform");
                });

            modelBuilder.Entity("VideoGameSales.Domain.Entities.Publishers.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("VideoGameSales.Domain.Entities.Sales.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GamesToPlatforms_id")
                        .HasColumnType("int");

                    b.Property<float>("Sales_Eu")
                        .HasColumnType("real");

                    b.Property<float>("Sales_Global")
                        .HasColumnType("real");

                    b.Property<float>("Sales_Jp")
                        .HasColumnType("real");

                    b.Property<float>("Sales_Na")
                        .HasColumnType("real");

                    b.Property<float>("Sales_Other")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("VideoGameSales.Domain.Entities.Conectors.GamesToPlataform", b =>
                {
                    b.HasOne("VideoGameSales.Domain.Entities.Games.Game", "Games")
                        .WithMany("Platform")
                        .HasForeignKey("Games_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoGameSales.Domain.Entities.Platforms.Platform", "Platform")
                        .WithMany("GameToPlatform")
                        .HasForeignKey("Platform_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Games");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("VideoGameSales.Domain.Entities.Conectors.PublishersToGames", b =>
                {
                    b.HasOne("VideoGameSales.Domain.Entities.Games.Game", "Games")
                        .WithOne("Publisher")
                        .HasForeignKey("VideoGameSales.Domain.Entities.Conectors.PublishersToGames", "Publishers_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoGameSales.Domain.Entities.Publishers.Publisher", "Publisher")
                        .WithMany("GamesToPublisher")
                        .HasForeignKey("Publishers_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Games");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("VideoGameSales.Domain.Entities.Games.Game", b =>
                {
                    b.Navigation("Platform");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("VideoGameSales.Domain.Entities.Platforms.Platform", b =>
                {
                    b.Navigation("GameToPlatform");
                });

            modelBuilder.Entity("VideoGameSales.Domain.Entities.Publishers.Publisher", b =>
                {
                    b.Navigation("GamesToPublisher");
                });
#pragma warning restore 612, 618
        }
    }
}
