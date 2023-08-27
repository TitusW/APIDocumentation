using System;
using APIService.Models;
using Microsoft.EntityFrameworkCore;

namespace APIService.Data
{
    public class APIServiceContext : DbContext
    {
        public DbSet<APIDefinition> APIDefinitions { get; set; }

        public DbSet<APIField> APIFields { get; set; }

        public DbSet<User> Users { get; set; }

        public APIServiceContext(DbContextOptions<APIServiceContext> options) : base(options)
        {
        }
    }
}

