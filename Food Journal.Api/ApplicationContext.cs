using System;
using Food_Journal.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Journal.Api
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<FoodItemEntry> FoodItemEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Constants.Secrets.MySecrets.DbConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(
                userRecords =>
                {
                    userRecords.HasKey(u => u.Id);

                    userRecords.HasIndex(u => u.Username)
                        .IsUnique();

                    userRecords.Property(u => u.Username)
                        .IsRequired();
                    userRecords.Property(u => u.Password)
                        .IsRequired();
                });

            modelBuilder.Entity<Location>(
                locationRecords =>
                {
                    locationRecords.HasKey(l => l.Id);

                    locationRecords.HasIndex(l => l.GoogleMapsId)
                        .IsUnique();

                    locationRecords.Property(l => l.Name)
                        .IsRequired();
                });

            modelBuilder.Entity<Entry>(
                entityRecords =>
                {
                    entityRecords.HasKey(e => e.Id);

                    entityRecords.HasOne(e => e.User)
                        .WithMany(u => u.JournalEntries)
                        .IsRequired();

                    entityRecords.HasOne(e => e.Location)
                        .WithMany(l => l.Entries)
                        .HasForeignKey(e => e.LocationId)
                        .IsRequired();

                    entityRecords.Property(e => e.Title)
                        .IsRequired();
                });

            modelBuilder.Entity<FoodItemEntry>(
                foodItemEntryRecords =>
                {
                    foodItemEntryRecords.HasKey(e => e.Id);

                    foodItemEntryRecords.HasOne(e => e.Entry)
                        .WithMany(e => e.FoodEntries)
                        .HasForeignKey(e => e.EntryId)
                        .IsRequired();

                    foodItemEntryRecords.Property(e => e.Name)
                        .IsRequired();
                });
        }
    }
}
