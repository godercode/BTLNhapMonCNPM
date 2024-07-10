﻿// <auto-generated />
using System;
using BTLNhapMonCNPM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BTLNhapMonCNPM.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BTLNhapMonCNPM.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("Total")
                        .IsRequired()
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("BTLNhapMonCNPM.Models.BillDetail", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<int>("BillId")
                        .HasColumnType("integer");

                    b.Property<int>("DrinkId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<double?>("SubTotal")
                        .IsRequired()
                        .HasColumnType("double precision");

                    b.Property<double?>("SubTotalCompared")
                        .IsRequired()
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("DrinkId");

                    b.ToTable("BillDetails");
                });

            modelBuilder.Entity("BTLNhapMonCNPM.Models.Drink", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<int?>("ComparedPrice")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<double?>("Price")
                        .IsRequired()
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("BTLNhapMonCNPM.Models.DrinkImage", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<int>("DrinkId")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("DrinkId");

                    b.ToTable("DrinkImages");
                });

            modelBuilder.Entity("BTLNhapMonCNPM.Models.BillDetail", b =>
                {
                    b.HasOne("BTLNhapMonCNPM.Models.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLNhapMonCNPM.Models.Drink", "Drink")
                        .WithMany("BillDetails")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Drink");
                });

            modelBuilder.Entity("BTLNhapMonCNPM.Models.DrinkImage", b =>
                {
                    b.HasOne("BTLNhapMonCNPM.Models.Drink", "Drink")
                        .WithMany("Images")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");
                });

            modelBuilder.Entity("BTLNhapMonCNPM.Models.Bill", b =>
                {
                    b.Navigation("BillDetails");
                });

            modelBuilder.Entity("BTLNhapMonCNPM.Models.Drink", b =>
                {
                    b.Navigation("BillDetails");

                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
