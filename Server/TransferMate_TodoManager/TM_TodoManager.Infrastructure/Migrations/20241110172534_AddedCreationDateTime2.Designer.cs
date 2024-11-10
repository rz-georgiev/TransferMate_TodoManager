﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TM_TodoManager.Infrastructure;

#nullable disable

namespace TM_TodoManager.Infrastructure.Migrations
{
    [DbContext(typeof(TransferMateDbContext))]
    [Migration("20241110172534_AddedCreationDateTime2")]
    partial class AddedCreationDateTime2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TM_TodoManager.Core.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ToDo"
                        },
                        new
                        {
                            Id = 2,
                            Name = "InProgress"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Done"
                        });
                });

            modelBuilder.Entity("TM_TodoManager.Core.Entities.UserTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("UserTasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDateTime = new DateTime(2024, 11, 12, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7366),
                            DueDate = new DateTime(2024, 11, 11, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7357),
                            Name = "Task1",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDateTime = new DateTime(2024, 11, 13, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7368),
                            DueDate = new DateTime(2024, 11, 12, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7368),
                            Name = "Task2",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedDateTime = new DateTime(2024, 11, 14, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7370),
                            DueDate = new DateTime(2024, 11, 9, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7370),
                            Name = "Task3",
                            StatusId = 2
                        },
                        new
                        {
                            Id = 4,
                            CreatedDateTime = new DateTime(2024, 11, 5, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7372),
                            DueDate = new DateTime(2024, 11, 8, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7372),
                            Name = "Task4",
                            StatusId = 2
                        },
                        new
                        {
                            Id = 5,
                            CreatedDateTime = new DateTime(2024, 11, 4, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7374),
                            DueDate = new DateTime(2024, 11, 7, 17, 25, 34, 408, DateTimeKind.Utc).AddTicks(7373),
                            Name = "Task5",
                            StatusId = 2
                        });
                });

            modelBuilder.Entity("TM_TodoManager.Core.Entities.UserTask", b =>
                {
                    b.HasOne("TM_TodoManager.Core.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
