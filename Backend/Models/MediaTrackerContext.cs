using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public partial class MediaTrackerContext : DbContext
{
    public MediaTrackerContext()
    {
    }

    public MediaTrackerContext(DbContextOptions<MediaTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MediaType> MediaTypes { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Show> Shows { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WatchedList> WatchedLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MediaType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__MediaTyp__516F03B5B41776A5");

            entity.ToTable("MediaType");

            entity.HasIndex(e => e.Name, "UQ__MediaTyp__737584F6A3A3FBF9").IsUnique();

            entity.Property(e => e.TypeId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasKey(e => e.MediaId).HasName("PK__Media__B2C2B5CFCE110AC1");

            entity.Property(e => e.MediaId).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(120)
                .IsUnicode(false);

            entity.HasOne(d => d.Type).WithMany(p => p.Media)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Media__TypeId__4F7CD00D");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MediaId).HasName("PK__Movies__B2C2B5CF5DE7E0CC");

            entity.Property(e => e.MediaId).ValueGeneratedNever();
            entity.Property(e => e.ImdbId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Media).WithOne(p => p.Movie)
                .HasForeignKey<Movie>(d => d.MediaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movies__MediaId__52593CB8");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79CE69891D0F");

            entity.HasIndex(e => new { e.UserId, e.MediaId }, "UQ__Reviews__FCA4E71185113B00").IsUnique();

            entity.Property(e => e.ReviewId).ValueGeneratedNever();
            entity.Property(e => e.Rating).HasColumnType("decimal(2, 1)");
            entity.Property(e => e.Review1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Review");
            entity.Property(e => e.ReviewedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Media).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.MediaId)
                .HasConstraintName("FK__Reviews__MediaId__60A75C0F");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reviews__UserId__5FB337D6");
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.HasKey(e => e.MediaId).HasName("PK__Shows__B2C2B5CFC9CF33C1");

            entity.Property(e => e.MediaId).ValueGeneratedNever();
            entity.Property(e => e.ImdbId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Media).WithOne(p => p.Show)
                .HasForeignKey<Show>(d => d.MediaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Shows__MediaId__5535A963");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CC913A152");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WatchedList>(entity =>
        {
            entity.HasKey(e => e.WatchedId).HasName("PK__WatchedL__C5F08D4597C49377");

            entity.ToTable("WatchedList");

            entity.HasIndex(e => new { e.UserId, e.MediaId }, "UQ__WatchedL__FCA4E711E1CCAD7A").IsUnique();

            entity.Property(e => e.WatchedId).ValueGeneratedNever();

            entity.HasOne(d => d.Media).WithMany(p => p.WatchedLists)
                .HasForeignKey(d => d.MediaId)
                .HasConstraintName("FK__WatchedLi__Media__59FA5E80");

            entity.HasOne(d => d.User).WithMany(p => p.WatchedLists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__WatchedLi__UserI__59063A47");
        });
        //modelBuilder.Entity<AppUser>();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
