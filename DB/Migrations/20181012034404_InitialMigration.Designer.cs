﻿// <auto-generated />
using System;
using Food_Journal.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Food_Journal.DB.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20181012034404_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Food_Journal.DB.Models.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("LocationId");

                    b.Property<string>("Notes");

                    b.Property<double>("Rating");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("UserId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("Food_Journal.DB.Models.FoodItemEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<int>("EntryId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<double>("Rating");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.ToTable("FoodItemEntries");
                });

            modelBuilder.Entity("Food_Journal.DB.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("GoogleMapsId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Region");

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("GoogleMapsId")
                        .IsUnique()
                        .HasFilter("[GoogleMapsId] IS NOT NULL");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Food_Journal.DB.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<DateTimeOffset>("LastLoggedIn");

                    b.Property<string>("Name");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTimeOffset>("UpdatedAt");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Food_Journal.DB.Models.Entry", b =>
                {
                    b.HasOne("Food_Journal.DB.Models.Location", "Location")
                        .WithMany("Entries")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Food_Journal.DB.Models.User", "User")
                        .WithMany("JournalEntries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Food_Journal.DB.Models.FoodItemEntry", b =>
                {
                    b.HasOne("Food_Journal.DB.Models.Entry", "Entry")
                        .WithMany("FoodEntries")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}