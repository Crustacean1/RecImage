﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecImage.Repositories;

#nullable disable

namespace RecImage.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220118204942_FixedRelations4")]
    partial class FixedRelations4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RecImage.Models.MetaData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImageHash")
                        .HasColumnType("longtext");

                    b.Property<string>("ModifiedFile")
                        .HasColumnType("longtext");

                    b.Property<string>("OriginalFile")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MetaData");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Creation = new DateTime(2022, 1, 18, 21, 49, 42, 487, DateTimeKind.Local).AddTicks(770),
                            ImageHash = "hashhashhash",
                            ModifiedFile = "cockroach_shop.jpg",
                            OriginalFile = "ladybug_shop.jpg",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Creation = new DateTime(2022, 1, 18, 21, 49, 42, 487, DateTimeKind.Local).AddTicks(801),
                            ImageHash = "hashhashhash",
                            ModifiedFile = "duck_shop.jpg",
                            OriginalFile = "frog_shop.jpg",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Creation = new DateTime(2022, 1, 18, 21, 49, 42, 487, DateTimeKind.Local).AddTicks(804),
                            ImageHash = "hashhashhash",
                            ModifiedFile = "pepe_the_duck.jpg",
                            OriginalFile = "pepe_the_frog.jpg",
                            UserId = 2
                        });
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

            modelBuilder.Entity("RecImage.Models.MetaData", b =>
                {
                    b.HasOne("RecImage.Models.User", "ImageUser")
                        .WithMany("Images")
                        .HasForeignKey("UserId")
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
