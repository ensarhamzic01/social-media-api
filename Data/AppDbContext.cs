﻿using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Data.Models;

namespace SocialMediaAPI.Data
{
    public class AppDbContext : DbContext
    {
        private IConfiguration configuration;

        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username).IsUnique();

            modelBuilder.Entity<Post>()
                .HasOne<User>(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne<User>(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
                .HasIndex(l => new { l.UserId, l.PostId }).IsUnique();

            modelBuilder.Entity<Follow>()
                .HasIndex(f => new { f.UserId, f.FollowingId }).IsUnique();

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.User)
                .WithMany(u => u.Following)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Following)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowingId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Verification>()
               .HasIndex(v => v.UserId).IsUnique();

            modelBuilder.Entity<Verification>()
               .HasIndex(v => v.Token).IsUnique();

            modelBuilder.Entity<PasswordReset>()
               .HasIndex(v => v.UserId).IsUnique();

            modelBuilder.Entity<PasswordReset>()
               .HasIndex(v => v.Token).IsUnique();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Verification> Verifications { get; set; }
        public DbSet<PasswordReset> PasswordResets { get; set; }

    }
}
