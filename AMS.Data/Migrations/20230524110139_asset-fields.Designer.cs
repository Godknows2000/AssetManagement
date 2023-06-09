﻿// <auto-generated />
using System;
using AMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AMS.Data.Migrations
{
    [DbContext(typeof(AssetManagementContext))]
    [Migration("20230524110139_asset-fields")]
    partial class assetfields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AMS.Data.Asset", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("AssetId")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("AssetID");

                    b.Property<string>("AssetReceipt")
                        .HasColumnType("character varying");

                    b.Property<string>("Barcode")
                        .HasColumnType("character varying");

                    b.Property<string>("Category")
                        .HasColumnType("character varying");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("character varying");

                    b.Property<string>("ImageFile")
                        .HasColumnType("character varying");

                    b.Property<string>("Model")
                        .HasColumnType("character varying");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("SupplierId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("Asset_pkey");

                    b.HasIndex(new[] { "DepartmentId" }, "IX_Asset_DepartmentId");

                    b.HasIndex(new[] { "SupplierId" }, "IX_Asset_SupplierId");

                    b.ToTable("Asset", (string)null);
                });

            modelBuilder.Entity("AMS.Data.AssetRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AssetId")
                        .HasColumnType("uuid");

                    b.Property<string>("AssetLocation")
                        .HasColumnType("character varying");

                    b.Property<string>("AttachmentsJson")
                        .HasColumnType("character varying");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("NotesJson")
                        .HasColumnType("character varying");

                    b.Property<string>("Number")
                        .HasColumnType("character varying");

                    b.Property<string>("RequestComments")
                        .HasColumnType("character varying");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("AssetRequest_pkey");

                    b.HasIndex("AssetId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("AssetRequest", (string)null);
                });

            modelBuilder.Entity("AMS.Data.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Container")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Extension")
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NotesJson")
                        .HasColumnType("text");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.Property<Guid?>("UniqueId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CreatorId" }, "IX_Attachment_CreatorId");

                    b.ToTable("Attachment", (string)null);
                });

            modelBuilder.Entity("AMS.Data.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("character varying");

                    b.HasKey("Id")
                        .HasName("Department_pkey");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("AMS.Data.EmailConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<bool>("EnableSsl")
                        .HasColumnType("boolean");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("Port")
                        .HasColumnType("integer");

                    b.Property<string>("SenderDisplayName")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("SenderId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<int>("TargetId")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CreatorId" }, "IX_EmailConfig_CreatorId");

                    b.ToTable("EmailConfig", (string)null);
                });

            modelBuilder.Entity("AMS.Data.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id ");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("AttachmentsJson")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("EcNumber")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<string>("NotesJson")
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasDefaultValueSql("''::character varying");

                    b.Property<Guid?>("ProfilePictureId")
                        .HasColumnType("uuid");

                    b.Property<int>("ProfileStatusId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<int>("TitleId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("Employee_pkey");

                    b.HasIndex(new[] { "DepartmentId" }, "IX_Employee_DepartmentId");

                    b.HasIndex(new[] { "ProfilePictureId" }, "IX_Employee_ProfilePictureId");

                    b.HasIndex(new[] { "TitleId" }, "IX_Employee_TitleId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("AMS.Data.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("character varying");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("character varying");

                    b.Property<string>("Name")
                        .HasColumnType("character varying");

                    b.Property<string>("Phone")
                        .HasColumnType("character varying");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("Id")
                        .HasName("Supplier_pkey");

                    b.ToTable("Supplier", (string)null);
                });

            modelBuilder.Entity("AMS.Data.Title", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("character varying");

                    b.HasKey("Id")
                        .HasName("Title_pkey");

                    b.ToTable("Title", (string)null);
                });

            modelBuilder.Entity("AMS.Data.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ActivationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("AuthRecoveryCodes")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("AuthenticatorKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("LockoutExpiryDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LoginId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Mobile")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("SecurityStamp")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("TwoFactorAuthEnabled")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CreatorId" }, "IX_User_CreatorId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("AMS.Data.Asset", b =>
                {
                    b.HasOne("AMS.Data.Department", "Department")
                        .WithMany("Assets")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("Deparment");

                    b.HasOne("AMS.Data.Supplier", "Supplier")
                        .WithMany("Assets")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("Supplier");

                    b.Navigation("Department");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("AMS.Data.AssetRequest", b =>
                {
                    b.HasOne("AMS.Data.Asset", "Asset")
                        .WithMany("AssetRequests")
                        .HasForeignKey("AssetId")
                        .HasConstraintName("Asset");

                    b.HasOne("AMS.Data.User", "Creator")
                        .WithMany("AssetRequests")
                        .HasForeignKey("CreatorId")
                        .HasConstraintName("Creator");

                    b.HasOne("AMS.Data.Department", "Department")
                        .WithMany("AssetRequests")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("Department");

                    b.HasOne("AMS.Data.Employee", "Employee")
                        .WithMany("AssetRequests")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("Employee");

                    b.Navigation("Asset");

                    b.Navigation("Creator");

                    b.Navigation("Department");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("AMS.Data.Attachment", b =>
                {
                    b.HasOne("AMS.Data.User", "Creator")
                        .WithMany("Attachments")
                        .HasForeignKey("CreatorId")
                        .IsRequired()
                        .HasConstraintName("Attachment_CreatorId_fkey");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("AMS.Data.EmailConfig", b =>
                {
                    b.HasOne("AMS.Data.User", "Creator")
                        .WithMany("EmailConfigs")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_EmailConfig_User");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("AMS.Data.Employee", b =>
                {
                    b.HasOne("AMS.Data.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("Employee_Department");

                    b.HasOne("AMS.Data.User", "IdNavigation")
                        .WithOne("Employee")
                        .HasForeignKey("AMS.Data.Employee", "Id")
                        .IsRequired()
                        .HasConstraintName("Employee_User");

                    b.HasOne("AMS.Data.Attachment", "ProfilePicture")
                        .WithMany("Employees")
                        .HasForeignKey("ProfilePictureId")
                        .HasConstraintName("Employee_ProfilePictureId_fkey");

                    b.HasOne("AMS.Data.Title", "Title")
                        .WithMany("Employees")
                        .HasForeignKey("TitleId")
                        .IsRequired()
                        .HasConstraintName("Employee_TitleId_fkey");

                    b.Navigation("Department");

                    b.Navigation("IdNavigation");

                    b.Navigation("ProfilePicture");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("AMS.Data.User", b =>
                {
                    b.HasOne("AMS.Data.User", "Creator")
                        .WithMany("InverseCreator")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("User_CreatorId_fkey");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("AMS.Data.Asset", b =>
                {
                    b.Navigation("AssetRequests");
                });

            modelBuilder.Entity("AMS.Data.Attachment", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("AMS.Data.Department", b =>
                {
                    b.Navigation("AssetRequests");

                    b.Navigation("Assets");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("AMS.Data.Employee", b =>
                {
                    b.Navigation("AssetRequests");
                });

            modelBuilder.Entity("AMS.Data.Supplier", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("AMS.Data.Title", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("AMS.Data.User", b =>
                {
                    b.Navigation("AssetRequests");

                    b.Navigation("Attachments");

                    b.Navigation("EmailConfigs");

                    b.Navigation("Employee");

                    b.Navigation("InverseCreator");
                });
#pragma warning restore 612, 618
        }
    }
}
