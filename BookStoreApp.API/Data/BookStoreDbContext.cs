using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStoreApp.API.Data
{
    public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
    {
        public BookStoreDbContext()
        {
        }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Bio).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA2998F741")
                    .IsUnique();

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Summary).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Books_ToTable");
            });

            modelBuilder.Entity<IdentityRole>().HasData(

                    new IdentityRole
                    {
                        Name = "User",
                        NormalizedName = "USER",
                        Id = "8acb30bc-cf06-47cf-a56a-ef717a689615"
                    },

                    new IdentityRole
                    {
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR",
                        Id = "1ee2dac6-cd92-47df-926b-434bbbb6c224"

                    }
                );
            var hasher = new PasswordHasher<ApiUser>();

            modelBuilder.Entity<ApiUser>().HasData(

                    new ApiUser
                    {
                        Id = "e5119dd6-28c1-4f43-9dd6-f49f03f0fd69",
                        Email = "admin@bookstore.com",
                        NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                        UserName = "admin@bookstore.com",
                        NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                        FirstName = "System",
                        LastName = "Admin",
                        PasswordHash = hasher.HashPassword(null, "P@ssword1")
                    },
                    new ApiUser
                    {
                        Id = "bd11bb2f-f7c7-493c-8ccd-fca9db465d16",
                        Email = "user@bookstore.com",
                        NormalizedEmail = "USER@BOOKSTORE.COM",
                        UserName = "user@bookstore.com",
                        NormalizedUserName = "USER@BOOKSTORE.COM",
                        FirstName = "System",
                        LastName = "User",
                        PasswordHash = hasher.HashPassword(null, "P@ssword1")
                    }
                );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                
                    new IdentityUserRole<string>
                    {
                        RoleId = "8acb30bc-cf06-47cf-a56a-ef717a689615",
                        UserId = "bd11bb2f-f7c7-493c-8ccd-fca9db465d16"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "1ee2dac6-cd92-47df-926b-434bbbb6c224",
                        UserId = "e5119dd6-28c1-4f43-9dd6-f49f03f0fd69"
                    }
                );



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
