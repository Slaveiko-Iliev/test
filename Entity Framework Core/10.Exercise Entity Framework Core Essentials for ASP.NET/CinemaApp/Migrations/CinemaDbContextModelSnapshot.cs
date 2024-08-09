﻿// <auto-generated />
using System;
using CinemaApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CinemaApp.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    partial class CinemaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CinemaApp.Data.Models.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cinemas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Mladost 4, Sofia",
                            Name = "Arena Maladost"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Stara Zagora Mall",
                            Name = "Arena Stara Zagora"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Mall of Sofia",
                            Name = "Cinema City"
                        });
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("Halls");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CinemaId = 1,
                            Name = "IMAX Hall 1"
                        },
                        new
                        {
                            Id = 2,
                            CinemaId = 1,
                            Name = "IMAX Hall 1"
                        },
                        new
                        {
                            Id = 3,
                            CinemaId = 1,
                            Name = "3D  Hall"
                        },
                        new
                        {
                            Id = 4,
                            CinemaId = 2,
                            Name = "VIP Hall"
                        },
                        new
                        {
                            Id = 5,
                            CinemaId = 2,
                            Name = "IMAX"
                        },
                        new
                        {
                            Id = 6,
                            CinemaId = 3,
                            Name = "3D Ultra Vip IMAX"
                        });
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Genre = 0,
                            Title = "Snatch"
                        },
                        new
                        {
                            Id = 2,
                            Genre = 0,
                            Title = "Lock, Stock And Two Smoking Barrels"
                        },
                        new
                        {
                            Id = 3,
                            Genre = 0,
                            Title = "Rock n Rolla"
                        });
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("HallId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.HasIndex("MovieId");

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Duration = new TimeSpan(0, 1, 38, 0, 0),
                            HallId = 1,
                            MovieId = 1,
                            Start = new DateTime(2024, 7, 23, 20, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Duration = new TimeSpan(0, 1, 38, 0, 0),
                            HallId = 4,
                            MovieId = 2,
                            Start = new DateTime(2024, 7, 23, 20, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Duration = new TimeSpan(0, 1, 38, 0, 0),
                            HallId = 2,
                            MovieId = 3,
                            Start = new DateTime(2024, 7, 23, 20, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HallId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.ToTable("Seats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HallId = 1,
                            Number = 1,
                            Row = 1
                        },
                        new
                        {
                            Id = 2,
                            HallId = 1,
                            Number = 2,
                            Row = 1
                        },
                        new
                        {
                            Id = 3,
                            HallId = 1,
                            Number = 3,
                            Row = 1
                        },
                        new
                        {
                            Id = 4,
                            HallId = 1,
                            Number = 1,
                            Row = 2
                        },
                        new
                        {
                            Id = 5,
                            HallId = 1,
                            Number = 2,
                            Row = 2
                        },
                        new
                        {
                            Id = 6,
                            HallId = 1,
                            Number = 3,
                            Row = 2
                        },
                        new
                        {
                            Id = 7,
                            HallId = 1,
                            Number = 1,
                            Row = 3
                        },
                        new
                        {
                            Id = 8,
                            HallId = 1,
                            Number = 2,
                            Row = 3
                        },
                        new
                        {
                            Id = 9,
                            HallId = 1,
                            Number = 3,
                            Row = 3
                        });
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Tariff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Factor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tariffs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Factor = 1m,
                            Name = "Adult"
                        },
                        new
                        {
                            Id = 2,
                            Factor = 0.8m,
                            Name = "Student"
                        },
                        new
                        {
                            Id = 3,
                            Factor = 0.7m,
                            Name = "Senior"
                        },
                        new
                        {
                            Id = 4,
                            Factor = 0.5m,
                            Name = "SofUni Corporate Discount"
                        });
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<int>("TariffId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("SeatId");

                    b.HasIndex("TariffId");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BasePrice = 20m,
                            ScheduleId = 1,
                            SeatId = 1,
                            TariffId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BasePrice = 20m,
                            ScheduleId = 3,
                            SeatId = 2,
                            TariffId = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            BasePrice = 20m,
                            ScheduleId = 2,
                            SeatId = 3,
                            TariffId = 2,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("CinemaApp.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Pesho",
                            LastName = "Petrov",
                            Username = "pesho123"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Pesho",
                            LastName = "Ivan",
                            Username = "pesho987"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Ivan",
                            LastName = "Ivanov",
                            Username = "vankata89"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Maria  ",
                            LastName = "Petrova",
                            Username = "maria12312"
                        });
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Hall", b =>
                {
                    b.HasOne("CinemaApp.Data.Models.Cinema", "Cinema")
                        .WithMany("Halls")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Schedule", b =>
                {
                    b.HasOne("CinemaApp.Data.Models.Hall", "Hall")
                        .WithMany("Schedules")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaApp.Data.Models.Movie", "Movie")
                        .WithMany("Schedules")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hall");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Seat", b =>
                {
                    b.HasOne("CinemaApp.Data.Models.Hall", "Hall")
                        .WithMany("Seats")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hall");
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Ticket", b =>
                {
                    b.HasOne("CinemaApp.Data.Models.Schedule", "Schedule")
                        .WithMany("Tickets")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaApp.Data.Models.Seat", "Seat")
                        .WithMany("Tickets")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CinemaApp.Data.Models.Tariff", "Tariff")
                        .WithMany("Tickets")
                        .HasForeignKey("TariffId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CinemaApp.Data.Models.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");

                    b.Navigation("Seat");

                    b.Navigation("Tariff");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Cinema", b =>
                {
                    b.Navigation("Halls");
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Hall", b =>
                {
                    b.Navigation("Schedules");

                    b.Navigation("Seats");
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Movie", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Schedule", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Seat", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Tariff", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("CinemaApp.Data.Models.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}