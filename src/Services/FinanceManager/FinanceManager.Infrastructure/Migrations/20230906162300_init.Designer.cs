﻿// <auto-generated />
using System;
using FinanceManager.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    [DbContext(typeof(FinanceManagerContext))]
    [Migration("20230906162300_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinanceManager.Domain.AggregatesModel.ExpenseAggregate.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ExpenseAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ExpenseDate");

                    b.Property<string>("IdentityId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("_expenseVarietyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId")
                        .IsUnique();

                    b.ToTable("expense", (string)null);
                });

            modelBuilder.Entity("FinanceManager.Domain.AggregatesModel.ExpenseAggregate.ExpenseType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("expensetype", (string)null);
                });

            modelBuilder.Entity("FinanceManager.Domain.AggregatesModel.ExpenseAggregate.ExpenseVariety", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("_expenseTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("_expenseTypeId");

                    b.ToTable("expensevariety", (string)null);
                });

            modelBuilder.Entity("FinanceManager.Domain.AggregatesModel.RevenueAggregate.Revenue", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdentityId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("RevenueAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RevenueDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("RevenueDate");

                    b.Property<Guid>("_revenueVarietyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId")
                        .IsUnique();

                    b.ToTable("revenue", (string)null);
                });

            modelBuilder.Entity("FinanceManager.Domain.AggregatesModel.RevenueAggregate.RevenueType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("revenuetype", (string)null);
                });

            modelBuilder.Entity("FinanceManager.Domain.AggregatesModel.RevenueAggregate.RevenueVariety", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("_revenueTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("_revenueTypeId");

                    b.ToTable("revenuevariety", (string)null);
                });

            modelBuilder.Entity("FinanceManager.Domain.AggregatesModel.ExpenseAggregate.Expense", b =>
                {
                    b.HasOne("FinanceManager.Domain.AggregatesModel.ExpenseAggregate.ExpenseVariety", "ExpenseVariety")
                        .WithMany("Expenses")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpenseVariety");
                });

            modelBuilder.Entity("FinanceManager.Domain.AggregatesModel.ExpenseAggregate.ExpenseVariety", b =>
                {
                    b.HasOne("FinanceManager.Domain.AggregatesModel.ExpenseAggregate.ExpenseType", "ExpenseType")
                        .WithMany()
                        .HasForeignKey("_expenseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpenseType");
                });

            modelBuilder.Entity("FinanceManager.Domain.AggregatesModel.RevenueAggregate.Revenue", b =>
                {
                    b.HasOne("FinanceManager.Domain.AggregatesModel.RevenueAggregate.RevenueVariety", "RevenueVariety")
                        .WithMany("Revenues")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RevenueVariety");
                });

            modelBuilder.Entity("FinanceManager.Domain.AggregatesModel.RevenueAggregate.RevenueVariety", b =>
                {
                    b.HasOne("FinanceManager.Domain.AggregatesModel.RevenueAggregate.RevenueType", "RevenueType")
                        .WithMany()
                        .HasForeignKey("_revenueTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RevenueType");
                });

            modelBuilder.Entity("FinanceManager.Domain.AggregatesModel.ExpenseAggregate.ExpenseVariety", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("FinanceManager.Domain.AggregatesModel.RevenueAggregate.RevenueVariety", b =>
                {
                    b.Navigation("Revenues");
                });
#pragma warning restore 612, 618
        }
    }
}
