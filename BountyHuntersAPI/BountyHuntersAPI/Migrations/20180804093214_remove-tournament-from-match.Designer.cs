﻿// <auto-generated />
using System;
using BountyHuntersAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BountyHuntersAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180804093214_remove-tournament-from-match")]
    partial class removetournamentfrommatch
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BountyHuntersAPI.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlayerAScore");

                    b.Property<int>("PlayerBScore");

                    b.Property<int?>("TournamentId");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("BountyHuntersAPI.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int?>("TournamentId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BountyHuntersAPI.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("BountyHuntersAPI.Models.Match", b =>
                {
                    b.HasOne("BountyHuntersAPI.Models.Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("BountyHuntersAPI.Models.Player", b =>
                {
                    b.HasOne("BountyHuntersAPI.Models.Tournament")
                        .WithMany("Players")
                        .HasForeignKey("TournamentId");
                });
#pragma warning restore 612, 618
        }
    }
}
