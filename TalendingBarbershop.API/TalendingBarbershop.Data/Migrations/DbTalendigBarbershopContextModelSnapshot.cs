﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TalendingBarbershop.Data.Models;

namespace TalendingBarbershop.Data.Migrations
{
    [DbContext(typeof(DbTalendigBarbershopContext))]
    partial class DbTalendigBarbershopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TalendingBarbershop.Data.Models.TblOrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderId")
                        .HasColumnName("order_id")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceId")
                        .HasColumnName("service_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("tblOrderDetails");
                });

            modelBuilder.Entity("TalendingBarbershop.Data.Models.TblOrders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("int");

                    b.Property<bool?>("IsPaid")
                        .HasColumnName("is_paid")
                        .HasColumnType("bit");

                    b.Property<int?>("PaidTypeId")
                        .HasColumnName("paid_type_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaidTypeId");

                    b.ToTable("tblOrders");
                });

            modelBuilder.Entity("TalendingBarbershop.Data.Models.TblPaidTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("tblPaidTypes");
                });

            modelBuilder.Entity("TalendingBarbershop.Data.Models.TblQuotes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Time")
                        .HasColumnName("time")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("tblQuotes");
                });

            modelBuilder.Entity("TalendingBarbershop.Data.Models.TblRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("tblRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Barbero"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cliente"
                        });
                });

            modelBuilder.Entity("TalendingBarbershop.Data.Models.TblServices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<decimal?>("Price")
                        .HasColumnName("price")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("Id");

                    b.ToTable("tblServices");
                });

            modelBuilder.Entity("TalendingBarbershop.Data.Models.TblUsers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<int?>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("date");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("tblUsers");
                });

            modelBuilder.Entity("TalendingBarbershop.Data.Models.TblOrderDetails", b =>
                {
                    b.HasOne("TalendingBarbershop.Data.Models.TblOrders", "Order")
                        .WithMany("TblOrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_order_id_tblOrderDetails");
                });

            modelBuilder.Entity("TalendingBarbershop.Data.Models.TblOrders", b =>
                {
                    b.HasOne("TalendingBarbershop.Data.Models.TblPaidTypes", "PaidType")
                        .WithMany("TblOrders")
                        .HasForeignKey("PaidTypeId")
                        .HasConstraintName("FK_paid_type_id_tblPaidTypes");
                });

            modelBuilder.Entity("TalendingBarbershop.Data.Models.TblQuotes", b =>
                {
                    b.HasOne("TalendingBarbershop.Data.Models.TblUsers", "User")
                        .WithMany("TblQuotes")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_user_id_tblQuotes");
                });

            modelBuilder.Entity("TalendingBarbershop.Data.Models.TblUsers", b =>
                {
                    b.HasOne("TalendingBarbershop.Data.Models.TblRoles", "Role")
                        .WithMany("TblUsers")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_role_id_tblRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
