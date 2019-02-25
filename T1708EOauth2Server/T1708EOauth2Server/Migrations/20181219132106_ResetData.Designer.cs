﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using T1708EOauth2Server.Data;

namespace T1708EOauth2Server.Migrations
{
    [DbContext(typeof(T1708EOauth2ServerContext))]
    [Migration("20181219132106_ResetData")]
    partial class ResetData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("T1708EOauth2Server.Models.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DeletedAt");

                    b.Property<string>("Email");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Salt");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("T1708EOauth2Server.Models.Credential", b =>
                {
                    b.Property<string>("AccessToken")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("ExpiredAt");

                    b.Property<long>("OwnerId");

                    b.Property<string>("RefreshToken");

                    b.Property<int>("Scope");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("AccessToken");

                    b.ToTable("Credential");
                });

            modelBuilder.Entity("T1708EOauth2Server.Models.RegisterApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DeletedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.Property<string>("RedirectUrl");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("RegisterApplication");
                });

            modelBuilder.Entity("T1708EOauth2Server.Models.UserInformation", b =>
                {
                    b.Property<long>("AccountId");

                    b.Property<string>("Address");

                    b.Property<string>("Avatar");

                    b.Property<DateTime>("Dob");

                    b.Property<string>("FullName");

                    b.Property<string>("Phone");

                    b.HasKey("AccountId");

                    b.ToTable("UserInformation");
                });

            modelBuilder.Entity("T1708EOauth2Server.Models.UserInformation", b =>
                {
                    b.HasOne("T1708EOauth2Server.Models.Account", "Account")
                        .WithOne("UserInformation")
                        .HasForeignKey("T1708EOauth2Server.Models.UserInformation", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
