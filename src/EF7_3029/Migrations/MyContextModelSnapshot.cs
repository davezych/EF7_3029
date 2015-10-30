using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using EF7_3029.Data;

namespace EF7_3029.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16147")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EF7_3029.Data.Forum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 80);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("EF7_3029.Data.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Counter");

                    b.Property<int>("ForumId");

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 80);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("EF7_3029.Data.Topic", b =>
                {
                    b.HasOne("EF7_3029.Data.Forum")
                        .WithMany()
                        .HasForeignKey("ForumId");
                });
        }
    }
}
