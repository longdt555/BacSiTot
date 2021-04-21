﻿// <auto-generated />
using System;
using Lib.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lib.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210421081136_InititalDb")]
    partial class InititalDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lib.Data.Entity.DiseasesModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("Lib.Data.Entity.FacilityReviewModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("HealthFacilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<float>("Question1Score")
                        .HasColumnType("real");

                    b.Property<float>("Question2Score")
                        .HasColumnType("real");

                    b.Property<float>("Question3Score")
                        .HasColumnType("real");

                    b.Property<float>("Question4Score")
                        .HasColumnType("real");

                    b.Property<bool>("RecommendUsing")
                        .HasColumnType("bit");

                    b.Property<string>("TimeVisited")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HealthFacilityId");

                    b.ToTable("FacilityReview");
                });

            modelBuilder.Entity("Lib.Data.Entity.FacilityTypeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacilityClassificationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FacilityType");
                });

            modelBuilder.Entity("Lib.Data.Entity.HealthFacilityModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BannerUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Commune")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FanPage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThumbnailImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkingTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HealthFacility");
                });

            modelBuilder.Entity("Lib.Data.Entity.HealthFacilityServiceModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DiseasesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HealthFacilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DiseasesId");

                    b.HasIndex("HealthFacilityId");

                    b.ToTable("HealthFacilityService");
                });

            modelBuilder.Entity("Lib.Data.Entity.HealthFacilityTypeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FacilityTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HealthFacilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FacilityTypeId");

                    b.HasIndex("HealthFacilityId");

                    b.ToTable("HealthFacilityType");
                });

            modelBuilder.Entity("Lib.Data.Entity.FacilityReviewModel", b =>
                {
                    b.HasOne("Lib.Data.Entity.HealthFacilityModel", "HealthFacility")
                        .WithMany("FacilityReviews")
                        .HasForeignKey("HealthFacilityId");
                });

            modelBuilder.Entity("Lib.Data.Entity.HealthFacilityServiceModel", b =>
                {
                    b.HasOne("Lib.Data.Entity.DiseasesModel", "Diseases")
                        .WithMany("HealthFacilityServices")
                        .HasForeignKey("DiseasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lib.Data.Entity.HealthFacilityModel", "HealthFacility")
                        .WithMany("HealthFacilityServices")
                        .HasForeignKey("HealthFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entity.HealthFacilityTypeModel", b =>
                {
                    b.HasOne("Lib.Data.Entity.FacilityTypeModel", "FacilityType")
                        .WithMany("HealthFacilityTypes")
                        .HasForeignKey("FacilityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lib.Data.Entity.HealthFacilityModel", "HealthFacility")
                        .WithMany("HealthFacilityTypes")
                        .HasForeignKey("HealthFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
