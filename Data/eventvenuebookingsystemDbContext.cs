using System;
using System.Collections.Generic;
using EventVenueBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventVenueBookingSystem.Data;

public partial class eventvenuebookingsystemDbContext : DbContext
{
    public eventvenuebookingsystemDbContext()
    {
    }

    public eventvenuebookingsystemDbContext(DbContextOptions<eventvenuebookingsystemDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking1> Booking1s { get; set; }

    public virtual DbSet<Event1> Event1s { get; set; }

    public virtual DbSet<Venue1> Venue1s { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Booking1__3214EC07F1F45827");

            entity.ToTable("Booking1");

            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<Event1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Event1__3214EC07507F4ED9");

            entity.ToTable("Event1");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Venue1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Venue1__3214EC0720F1C727");

            entity.ToTable("Venue1");

            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
