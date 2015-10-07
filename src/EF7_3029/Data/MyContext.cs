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

        public MyContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Forum>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(80);
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(80);
            });
        }

        public class Forum
        {
            public int Id { get; set; }
            public string Title { get; set; }
            
            public ICollection<Topic> Topics { get; set; }
        }

        public class Topic
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int ForumId { get; set; }

            [ForeignKey(nameof(ForumId))]
            [InverseProperty("Topics")]
            public Forum Forum { get; set; }
        }
    }
}
