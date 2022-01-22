﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecImage.Repositories;

#nullable disable

namespace RecImage.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220122132600_ImageInfoReduction2")]
    partial class ImageInfoReduction2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RecImage.Models.ImageInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Extension")
                        .HasColumnType("longtext");

                    b.Property<int>("ImageUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsUploaded")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ImageUserId");

                    b.ToTable("ImageInfo");
                });

            modelBuilder.Entity("RecImage.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Login = "kamil@crustacean.pl"
                        },
                        new
                        {
                            UserId = 2,
                            Login = "limak@naecatsurc.lp"
                        });
                });

            modelBuilder.Entity("RecImage.Models.ImageInfo", b =>
                {
                    b.HasOne("RecImage.Models.User", "ImageUser")
                        .WithMany("Images")
                        .HasForeignKey("ImageUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImageUser");
                });

            modelBuilder.Entity("RecImage.Models.User", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
