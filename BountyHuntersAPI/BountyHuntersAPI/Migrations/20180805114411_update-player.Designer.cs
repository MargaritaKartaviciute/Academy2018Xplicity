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
    [Migration("20180805114411_update-player")]
    partial class updateplayer
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

                    b.Property<int>("WhichMatch");

                    b.Property<int?>("WinnerPlayerId");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.HasIndex("WinnerPlayerId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("BountyHuntersAPI.Models.MatchEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MatchPlayerPlayerId");

                    b.Property<int?>("ParentMatchId");

                    b.Property<int>("Score");

                    b.HasKey("Id");

                    b.HasIndex("MatchPlayerPlayerId");

                    b.HasIndex("ParentMatchId");

                    b.ToTable("MatchEntry");
                });

            modelBuilder.Entity("BountyHuntersAPI.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("TournamentId");

                    b.Property<string>("Username");

                    b.HasKey("PlayerId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BountyHuntersAPI.Models.Tournament", b =>
                {
                    b.Property<int>("TournamentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentMatch");

                    b.Property<int>("MatchesCount");

                    b.Property<string>("Name");

                    b.HasKey("TournamentId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("BountyHuntersAPI.Models.Match", b =>
                {
                    b.HasOne("BountyHuntersAPI.Models.Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId");

                    b.HasOne("BountyHuntersAPI.Models.Player", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerPlayerId");
                });

            modelBuilder.Entity("BountyHuntersAPI.Models.MatchEntry", b =>
                {
                    b.HasOne("BountyHuntersAPI.Models.Player", "MatchPlayer")
                        .WithMany()
                        .HasForeignKey("MatchPlayerPlayerId");

                    b.HasOne("BountyHuntersAPI.Models.Match", "ParentMatch")
                        .WithMany("Entries")
                        .HasForeignKey("ParentMatchId");
                });

            modelBuilder.Entity("BountyHuntersAPI.Models.Player", b =>
                {
                    b.HasOne("BountyHuntersAPI.Models.Tournament")
                        .WithMany("Players")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
