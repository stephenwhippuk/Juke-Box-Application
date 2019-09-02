﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyJukeBox.Models;

namespace MyJukeBox.Migrations
{
    [DbContext(typeof(JukeBoxContext))]
    partial class JukeBoxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyJukeBox.Models.Release", b =>
                {
                    b.Property<int>("ReleaseID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoverUrl");

                    b.Property<string>("ThumbnailURL");

                    b.Property<int>("performanceType");

                    b.Property<DateTime>("releaseDate");

                    b.Property<int>("releaseType");

                    b.HasKey("ReleaseID");

                    b.ToTable("Releases");
                });

            modelBuilder.Entity("MyJukeBox.Models.Track", b =>
                {
                    b.Property<int>("TrackID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Artist");

                    b.Property<string>("Description");

                    b.Property<float>("Duration");

                    b.Property<string>("ImageURL");

                    b.Property<int?>("ReleaseID");

                    b.Property<string>("Title");

                    b.HasKey("TrackID");

                    b.HasIndex("ReleaseID");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("MyJukeBox.Models.Track", b =>
                {
                    b.HasOne("MyJukeBox.Models.Release")
                        .WithMany("Tracks")
                        .HasForeignKey("ReleaseID");
                });
#pragma warning restore 612, 618
        }
    }
}
