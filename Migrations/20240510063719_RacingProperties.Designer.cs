﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using indy_microservice.Data;

#nullable disable

namespace indy_microservice.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240510063719_RacingProperties")]
    partial class RacingProperties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BotPilotCharacteristic", b =>
                {
                    b.Property<int>("BotPilotsId")
                        .HasColumnType("int");

                    b.Property<int>("CharacteristicsId")
                        .HasColumnType("int");

                    b.HasKey("BotPilotsId", "CharacteristicsId");

                    b.HasIndex("CharacteristicsId");

                    b.ToTable("BotPilotCharacteristic");
                });

            modelBuilder.Entity("indy_microservice.Models.BotPilot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Downforce")
                        .HasColumnType("int");

                    b.Property<int>("Luck")
                        .HasColumnType("int");

                    b.Property<int>("Model")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Podiums")
                        .HasColumnType("int");

                    b.Property<int>("Racing")
                        .HasColumnType("int");

                    b.Property<int>("Skill")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BotPilots");
                });

            modelBuilder.Entity("indy_microservice.Models.Characteristic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Boost")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characteristics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Boost = 7,
                            Name = "DRS"
                        },
                        new
                        {
                            Id = 2,
                            Boost = 8,
                            Name = "Wide Spoiler"
                        },
                        new
                        {
                            Id = 3,
                            Boost = 6,
                            Name = "IA Suspension"
                        },
                        new
                        {
                            Id = 4,
                            Boost = 7,
                            Name = "Carbon Fiber Brakes"
                        });
                });

            modelBuilder.Entity("indy_microservice.Models.Tire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BotPilotId")
                        .HasColumnType("int");

                    b.Property<int>("Grip")
                        .HasColumnType("int");

                    b.Property<int>("Life")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BotPilotId")
                        .IsUnique();

                    b.ToTable("Tires");
                });

            modelBuilder.Entity("indy_microservice.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BotPilotCharacteristic", b =>
                {
                    b.HasOne("indy_microservice.Models.BotPilot", null)
                        .WithMany()
                        .HasForeignKey("BotPilotsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("indy_microservice.Models.Characteristic", null)
                        .WithMany()
                        .HasForeignKey("CharacteristicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("indy_microservice.Models.BotPilot", b =>
                {
                    b.HasOne("indy_microservice.Models.User", "User")
                        .WithMany("BotPilots")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("indy_microservice.Models.Tire", b =>
                {
                    b.HasOne("indy_microservice.Models.BotPilot", "BotPilot")
                        .WithOne("Tire")
                        .HasForeignKey("indy_microservice.Models.Tire", "BotPilotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BotPilot");
                });

            modelBuilder.Entity("indy_microservice.Models.BotPilot", b =>
                {
                    b.Navigation("Tire")
                        .IsRequired();
                });

            modelBuilder.Entity("indy_microservice.Models.User", b =>
                {
                    b.Navigation("BotPilots");
                });
#pragma warning restore 612, 618
        }
    }
}