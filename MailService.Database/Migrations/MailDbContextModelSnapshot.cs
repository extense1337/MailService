﻿// <auto-generated />
using System;
using MailService.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MailService.Database.Migrations
{
    [DbContext(typeof(MailDbContext))]
    partial class MailDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MailService.Database.MailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("body");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<string>("FailedMessage")
                        .HasColumnType("text")
                        .HasColumnName("failed_message");

                    b.Property<string>("Recipients")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("recipients");

                    b.Property<byte>("Result")
                        .HasColumnType("smallint")
                        .HasColumnName("result");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("subject");

                    b.HasKey("Id")
                        .HasName("pk_mails");

                    b.ToTable("mails", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
