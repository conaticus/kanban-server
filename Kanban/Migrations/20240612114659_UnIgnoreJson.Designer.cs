﻿// <auto-generated />
using System;
using Kanban.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kanban.Migrations
{
    [DbContext(typeof(KanbanContext))]
    [Migration("20240612114659_UnIgnoreJson")]
    partial class UnIgnoreJson
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Kanban.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContainerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContainerId");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("Kanban.Models.Container", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContainerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContainerId");

                    b.ToTable("Container");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Todo"
                        },
                        new
                        {
                            Id = 2,
                            Title = "In Progress"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Done"
                        });
                });

            modelBuilder.Entity("Kanban.Models.Card", b =>
                {
                    b.HasOne("Kanban.Models.Container", "Container")
                        .WithMany()
                        .HasForeignKey("ContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Container");
                });

            modelBuilder.Entity("Kanban.Models.Container", b =>
                {
                    b.HasOne("Kanban.Models.Container", null)
                        .WithMany("Containers")
                        .HasForeignKey("ContainerId");
                });

            modelBuilder.Entity("Kanban.Models.Container", b =>
                {
                    b.Navigation("Containers");
                });
#pragma warning restore 612, 618
        }
    }
}
