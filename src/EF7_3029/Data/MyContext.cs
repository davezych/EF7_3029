using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace EF7_3029.Data
{
    public partial class MyContext : DbContext
    {
        public MyContext()
        {

        }
        
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=EF7_3029.AspNet5;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
    
    public class Forum
    {
        public Forum()
        {
            Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Topic> Topics { get; set; }
    }

    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ForumId { get; set; }
        public int Counter { get; set; }

        [ForeignKey(nameof(ForumId))]
        [InverseProperty("Topics")]
        public Forum Forum { get; set; }
    }
}
