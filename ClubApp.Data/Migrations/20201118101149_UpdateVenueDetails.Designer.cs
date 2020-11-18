﻿// <auto-generated />
using System;
using ClubApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClubApp.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20201118101149_UpdateVenueDetails")]
    partial class UpdateVenueDetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ClubApp.Data.Entities.ApiClient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<int>("AccessTokenLifeTimeMin")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsSecured")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("RefreshTokenLifeTimeMin")
                        .HasColumnType("int");

                    b.Property<string>("Secret")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Secret")
                        .IsUnique();

                    b.ToTable("ApiClient");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.ApiRefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid>("ApiClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IssuedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserTenantApplicationRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("ApiClientId");

                    b.HasIndex("UserTenantApplicationRoleId");

                    b.HasIndex("Value")
                        .IsUnique();

                    b.ToTable("ApiRefreshToken");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<bool>("VIP")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.Guest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guest");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.TableBookingDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<DateTime>("BookingDateTimeFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BookingDateTimeTo")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberOfBookedTable")
                        .HasColumnType("int");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TableNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VenueId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("TableBookingDetails");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<bool>("IsVerified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.UserAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserAttribute");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.UserInvitation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex("Value")
                        .IsUnique();

                    b.ToTable("UserInvitation");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.UserPasswordReset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("RequestedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("Value")
                        .IsUnique();

                    b.ToTable("UserPasswordReset");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.UserTenantApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "TenantId", "ApplicationId")
                        .IsUnique();

                    b.ToTable("UserTenantApplicationRole");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.VenueDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("VenueAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VenueLatitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VenueLocation")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("VenueLongitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VenueName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("VenuePhone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("VenueDetails");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.ApiRefreshToken", b =>
                {
                    b.HasOne("ClubApp.Data.Entities.ApiClient", "ApiClient")
                        .WithMany("ApiRefreshTokens")
                        .HasForeignKey("ApiClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClubApp.Data.Entities.UserTenantApplicationRole", null)
                        .WithMany("ApiRefreshTokens")
                        .HasForeignKey("UserTenantApplicationRoleId");

                    b.Navigation("ApiClient");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.UserAttribute", b =>
                {
                    b.HasOne("ClubApp.Data.Entities.User", "User")
                        .WithOne("UserAttribute")
                        .HasForeignKey("ClubApp.Data.Entities.UserAttribute", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.UserInvitation", b =>
                {
                    b.HasOne("ClubApp.Data.Entities.User", "User")
                        .WithOne("UserInvitation")
                        .HasForeignKey("ClubApp.Data.Entities.UserInvitation", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.UserPasswordReset", b =>
                {
                    b.HasOne("ClubApp.Data.Entities.User", "User")
                        .WithMany("UserPasswordResets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.UserTenantApplicationRole", b =>
                {
                    b.HasOne("ClubApp.Data.Entities.User", "User")
                        .WithMany("UserTenantApplicationRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.ApiClient", b =>
                {
                    b.Navigation("ApiRefreshTokens");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.User", b =>
                {
                    b.Navigation("UserAttribute");

                    b.Navigation("UserInvitation");

                    b.Navigation("UserPasswordResets");

                    b.Navigation("UserTenantApplicationRoles");
                });

            modelBuilder.Entity("ClubApp.Data.Entities.UserTenantApplicationRole", b =>
                {
                    b.Navigation("ApiRefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
