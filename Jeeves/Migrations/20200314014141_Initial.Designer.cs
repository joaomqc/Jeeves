﻿// <auto-generated />
using Jeeves.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jeeves.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200314014141_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("Jeeves.Domain.MediaResource", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.Property<int>("ResourceType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Name");

                    b.ToTable("MediaResources");
                });
#pragma warning restore 612, 618
        }
    }
}