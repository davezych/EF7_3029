using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using EF7_3029.Data;

namespace EF7_3029.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20151007223046_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-rc1-15886")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EF7_3029.Data.Forum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .Annotation("MaxLength", 80);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("EF7_3029.Data.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ForumId");

                    b.Property<string>("Title")
                        .Annotation("MaxLength", 80);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("EF7_3029.Data.Topic", b =>
                {
                    b.HasOne("EF7_3029.Data.Forum")
                        .WithMany()
                        .ForeignKey("ForumId");
                });
        }
    }
}
