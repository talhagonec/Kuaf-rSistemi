﻿// <auto-generated />
using System;
using KuaforIsletmeYonetim.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KuaforIsletmeYonetim.Migrations
{
    [DbContext(typeof(KuaforContext))]
    [Migration("20241201142912_AddRandevu")]
    partial class AddRandevu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KuaforIsletmeYonetim.Models.Calisan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SalonId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SalonId");

                    b.ToTable("Calisanlar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ad = "Ahmet Yılmaz",
                            SalonId = 1
                        },
                        new
                        {
                            Id = 2,
                            Ad = "Ayşe Demir",
                            SalonId = 1
                        });
                });

            modelBuilder.Entity("KuaforIsletmeYonetim.Models.Randevu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BaslangicSaati")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("BitisSaati")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CalisanId")
                        .HasColumnType("integer");

                    b.Property<string>("Islem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MusteriAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Ucret")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CalisanId");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("KuaforIsletmeYonetim.Models.Salon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Salonlar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ad = "Kuaför A",
                            Adres = "Adres A",
                            Telefon = "0123456789"
                        });
                });

            modelBuilder.Entity("KuaforYonetim.Models.Islem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .HasColumnType("text");

                    b.Property<int>("Sure")
                        .HasColumnType("integer");

                    b.Property<double>("Ucret")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Islemler");
                });

            modelBuilder.Entity("KuaforIsletmeYonetim.Models.Calisan", b =>
                {
                    b.HasOne("KuaforIsletmeYonetim.Models.Salon", "Salon")
                        .WithMany("Calisanlar")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("KuaforIsletmeYonetim.Models.Randevu", b =>
                {
                    b.HasOne("KuaforIsletmeYonetim.Models.Calisan", "Calisan")
                        .WithMany()
                        .HasForeignKey("CalisanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Calisan");
                });

            modelBuilder.Entity("KuaforIsletmeYonetim.Models.Salon", b =>
                {
                    b.Navigation("Calisanlar");
                });
#pragma warning restore 612, 618
        }
    }
}
