﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMusicDbData.Models;

#nullable disable

namespace MyMusicDbData.Migrations
{
    [DbContext(typeof(MyMusicDbContext))]
    [Migration("20230426165635_migration3")]
    partial class migration3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlbumArtist", b =>
                {
                    b.Property<int>("AlbumsId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistsId")
                        .HasColumnType("int");

                    b.HasKey("AlbumsId", "ArtistsId");

                    b.HasIndex("ArtistsId");

                    b.ToTable("AlbumArtist");
                });

            modelBuilder.Entity("ArtistBand", b =>
                {
                    b.Property<int>("BandsId")
                        .HasColumnType("int");

                    b.Property<int>("MembersId")
                        .HasColumnType("int");

                    b.HasKey("BandsId", "MembersId");

                    b.HasIndex("MembersId");

                    b.ToTable("ArtistBand");
                });

            modelBuilder.Entity("ArtistTrack", b =>
                {
                    b.Property<int>("ArtistsId")
                        .HasColumnType("int");

                    b.Property<int>("SinglesId")
                        .HasColumnType("int");

                    b.HasKey("ArtistsId", "SinglesId");

                    b.HasIndex("SinglesId");

                    b.ToTable("ArtistTrack");
                });

            modelBuilder.Entity("MyMusicDbData.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BandId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("MyMusicDbData.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("MyMusicDbData.Models.Band", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("MyMusicDbData.Models.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int?>("BandId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("BandId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("AlbumArtist", b =>
                {
                    b.HasOne("MyMusicDbData.Models.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyMusicDbData.Models.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArtistBand", b =>
                {
                    b.HasOne("MyMusicDbData.Models.Band", null)
                        .WithMany()
                        .HasForeignKey("BandsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyMusicDbData.Models.Artist", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArtistTrack", b =>
                {
                    b.HasOne("MyMusicDbData.Models.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyMusicDbData.Models.Track", null)
                        .WithMany()
                        .HasForeignKey("SinglesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyMusicDbData.Models.Album", b =>
                {
                    b.HasOne("MyMusicDbData.Models.Band", "Band")
                        .WithMany("Albums")
                        .HasForeignKey("BandId");

                    b.Navigation("Band");
                });

            modelBuilder.Entity("MyMusicDbData.Models.Track", b =>
                {
                    b.HasOne("MyMusicDbData.Models.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumId");

                    b.HasOne("MyMusicDbData.Models.Band", "Band")
                        .WithMany("Singles")
                        .HasForeignKey("BandId");

                    b.Navigation("Album");

                    b.Navigation("Band");
                });

            modelBuilder.Entity("MyMusicDbData.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("MyMusicDbData.Models.Band", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Singles");
                });
#pragma warning restore 612, 618
        }
    }
}
