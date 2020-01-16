using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using var ctx = new BlogContext();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
        }
    }

    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseNpgsql("Host=localhost;Database=test;Username=npgsql_tests;Password=npgsql_tests")
                .UseSnakeCaseNamingConvention();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }

    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
