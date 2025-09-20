using System;
using System.Collections.Generic;
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

    public virtual DbSet<FavouriteList> FavouriteList { get; set; }

    public virtual DbSet<Media> Media { get; set; }

    public virtual DbSet<MediaType> MediaType { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FavouriteList>(entity =>
        {
            entity.HasKey(e => e.FavouritesId).HasName("PK__Favourit__26550E0C5E304D9A");

            entity.Property(e => e.FavouritesId).ValueGeneratedNever();

            entity.HasOne(d => d.Media).WithMany(p => p.FavouriteList)
                .HasForeignKey(d => d.MediaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MediaFavourite");

            entity.HasOne(d => d.Type).WithMany(p => p.FavouriteList)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_TypeFavourite");

            entity.HasOne(d => d.User).WithMany(p => p.FavouriteList)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserFavourite");
        });

        modelBuilder.Entity<Media>(entity =>
        {
            entity.HasKey(e => e.MediaId).HasName("PK__Media__B2C2B5CFB526BC5A");

            entity.Property(e => e.MediaId).ValueGeneratedNever();
            entity.Property(e => e.BackdropPath)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MediaType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OriginalLanguage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OriginalTitle).HasMaxLength(255);
            entity.Property(e => e.PosterPath)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Type).WithMany(p => p.Media)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_TypeMedia");
        });

        modelBuilder.Entity<MediaType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__MediaTyp__516F03B5F80483F0");

            entity.Property(e => e.TypeId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C7B91C1AB");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
