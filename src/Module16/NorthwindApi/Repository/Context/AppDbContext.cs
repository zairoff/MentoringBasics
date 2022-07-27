﻿using Microsoft.EntityFrameworkCore;
using NorthwindApi.Models;

namespace NorthwindApi.Repository.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
