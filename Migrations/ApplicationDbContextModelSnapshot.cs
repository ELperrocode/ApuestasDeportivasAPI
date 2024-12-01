﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApuestasDeportivasAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsValidated")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<decimal>("Odds")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Potential")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("Partido", b =>
                {
                    b.Property<string>("IdEvent")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DateEvent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("IntAwayScore")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("IntHomeScore")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Odds")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("StrAwayTeam")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StrAwayTeamBadge")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StrEvent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StrHomeTeam")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StrHomeTeamBadge")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StrLeague")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StrStatus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StrThumb")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StrTime")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdEvent");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Wallet")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
