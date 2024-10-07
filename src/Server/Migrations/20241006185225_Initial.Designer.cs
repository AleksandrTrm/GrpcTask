﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Server.Database;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241006185225_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Server.Models.GrpcData", b =>
                {
                    b.Property<int>("PacketSeqNum")
                        .HasColumnType("integer")
                        .HasColumnName("packet_seq_num");

                    b.Property<int>("RecordSeqNum")
                        .HasColumnType("integer")
                        .HasColumnName("record_seq_num");

                    b.Property<string>("Decimal1")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("decimal1");

                    b.Property<string>("Decimal2")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("decimal2");

                    b.Property<string>("Decimal3")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("decimal3");

                    b.Property<string>("Decimal4")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("decimal4");

                    b.Property<DateTime>("PacketTimestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("packet_timestamp");

                    b.Property<DateTime>("RecordTimestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("record_timestamp");

                    b.HasKey("PacketSeqNum", "RecordSeqNum")
                        .HasName("pk_grpc_data");

                    b.ToTable("grpc_data", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
