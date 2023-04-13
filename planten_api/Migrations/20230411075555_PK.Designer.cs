﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using planten_api;

#nullable disable

namespace planten_api.Migrations
{
    [DbContext(typeof(SoilMoistureContext))]
    [Migration("20230411075555_pk")]
    partial class pk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("planten_api.SoilMoisture", b =>
                {
                    b.Property<int>("SoilMoistureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SoilMoistureId"));

                    b.Property<int>("Moisture")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("SoilMoistureId");

                    b.ToTable("SoilMoistures");
                });
#pragma warning restore 612, 618
        }
    }
}