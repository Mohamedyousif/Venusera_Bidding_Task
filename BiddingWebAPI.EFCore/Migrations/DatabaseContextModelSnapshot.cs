﻿// <auto-generated />
using System;
using BiddingWebAPI.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BiddingWebAPI.EFCore.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BiddingWebAPI.EFCore.Model.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BiddingWebAPI.EFCore.Model.Request", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("BiddingWebAPI.EFCore.Model.RequestAttachement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RequestID");

                    b.ToTable("RequestAttachements");
                });

            modelBuilder.Entity("BiddingWebAPI.EFCore.Model.RequestComment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestID")
                        .HasColumnType("int");

                    b.Property<int>("ServiceProviderID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RequestID");

                    b.HasIndex("ServiceProviderID");

                    b.ToTable("RequestComments");
                });

            modelBuilder.Entity("BiddingWebAPI.EFCore.Model.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BiddingWebAPI.EFCore.Model.ServiceProvider", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("ServiceProviders");
                });

            modelBuilder.Entity("BiddingWebAPI.EFCore.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BiddingWebAPI.EFCore.Model.Client", b =>
                {
                    b.HasOne("BiddingWebAPI.EFCore.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BiddingWebAPI.EFCore.Model.Request", b =>
                {
                    b.HasOne("BiddingWebAPI.EFCore.Model.Client", "Client")
                        .WithMany("Requests")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BiddingWebAPI.EFCore.Model.RequestAttachement", b =>
                {
                    b.HasOne("BiddingWebAPI.EFCore.Model.Request", "Request")
                        .WithMany("RequestAttachements")
                        .HasForeignKey("RequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BiddingWebAPI.EFCore.Model.RequestComment", b =>
                {
                    b.HasOne("BiddingWebAPI.EFCore.Model.Request", "Request")
                        .WithMany("RequestComments")
                        .HasForeignKey("RequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BiddingWebAPI.EFCore.Model.ServiceProvider", "ServiceProvider")
                        .WithMany("RequestComments")
                        .HasForeignKey("ServiceProviderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BiddingWebAPI.EFCore.Model.ServiceProvider", b =>
                {
                    b.HasOne("BiddingWebAPI.EFCore.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BiddingWebAPI.EFCore.Model.User", b =>
                {
                    b.HasOne("BiddingWebAPI.EFCore.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
