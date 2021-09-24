﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NumberDecompose.Data.Context;

namespace NumberDecompose.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210924162511_initDataDocker")]
    partial class initDataDocker
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NumberDecompose.Domain.Number", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("BIT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATETIME");

                    b.Property<int>("Value")
                        .HasColumnType("INT");

                    b.Property<int>("Version")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.ToTable("Number");
                });
#pragma warning restore 612, 618
        }
    }
}