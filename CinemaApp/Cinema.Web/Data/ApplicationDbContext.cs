using Cinema.Web.Models.Domain;
using Cinema.Web.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<CinemaAppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<MovieInShoppingCart> MovieInShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Adding random ID
            builder.Entity<Movie>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<ShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            //ManyToMany relation
            builder.Entity<MovieInShoppingCart>()
                .HasKey(z => new { z.MovieId, z.ShoppingCartId });

            builder.Entity<MovieInShoppingCart>()
                .HasOne(z => z.Movie)
                .WithMany(z => z.MovieInShoppingCarts)
                .HasForeignKey(z => z.ShoppingCartId);

            builder.Entity<MovieInShoppingCart>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.MovieInShoppingCarts)
                .HasForeignKey(z => z.MovieId);

            //OneToOne relation
            builder.Entity<ShoppingCart>()
                .HasOne<CinemaAppUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z => z.OwnerId);


            builder.Entity<MovieInOrder>()
                .HasKey(z => new { z.MovieId, z.OrderId });

            builder.Entity<MovieInOrder>()
               .HasOne(z => z.SelectedMovie)
               .WithMany(z => z.Orders)
               .HasForeignKey(z => z.MovieId);

            builder.Entity<MovieInOrder>()
                .HasOne(z => z.UserOrder)
                .WithMany(z => z.Movies)
                .HasForeignKey(z => z.OrderId);
        }
    }
}
