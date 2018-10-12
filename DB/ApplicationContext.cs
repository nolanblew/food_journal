using System;
using Food_Journal.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Journal.DB
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
                });

            modelBuilder.Entity<Location>(
                locationRecords =>
                {
                    locationRecords.HasKey(u => u.Id);

                    locationRecords.HasIndex(u => u.GoogleMapsId)
                        .IsUnique();
                });

            modelBuilder.Entity<Entry>(
                entityRecords =>
                {
                    entityRecords.HasKey(u => u.Id);
                });

            modelBuilder.Entity<FoodItemEntry>(
                foodItemEntryRecords =>
                {
                    foodItemEntryRecords.HasKey(u => u.Id);

                    foodItemEntryRecords.HasOne(u => u.Entry)
                        .WithMany(e => e.FoodEntries)
                        .HasForeignKey(e => e.EntryId);
                });
        }
    }
}
