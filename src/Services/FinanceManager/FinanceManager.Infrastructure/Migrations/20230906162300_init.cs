using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "expensetype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expensetype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "revenuetype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_revenuetype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "expensevariety",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    _expenseTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expensevariety", x => x.Id);
                    table.ForeignKey(
                        name: "FK_expensevariety_expensetype__expenseTypeId",
                        column: x => x._expenseTypeId,
                        principalTable: "expensetype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "revenuevariety",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    _revenueTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_revenuevariety", x => x.Id);
                    table.ForeignKey(
                        name: "FK_revenuevariety_revenuetype__revenueTypeId",
                        column: x => x._revenueTypeId,
                        principalTable: "revenuetype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "expense",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpenseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentityId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    _expenseVarietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_expense_expensevariety_Id",
                        column: x => x.Id,
                        principalTable: "expensevariety",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "revenue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RevenueAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RevenueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentityId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    _revenueVarietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_revenue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_revenue_revenuevariety_Id",
                        column: x => x.Id,
                        principalTable: "revenuevariety",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_expense_IdentityId",
                table: "expense",
                column: "IdentityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_expensevariety__expenseTypeId",
                table: "expensevariety",
                column: "_expenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_revenue_IdentityId",
                table: "revenue",
                column: "IdentityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_revenuevariety__revenueTypeId",
                table: "revenuevariety",
                column: "_revenueTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "expense");

            migrationBuilder.DropTable(
                name: "revenue");

            migrationBuilder.DropTable(
                name: "expensevariety");

            migrationBuilder.DropTable(
                name: "revenuevariety");

            migrationBuilder.DropTable(
                name: "expensetype");

            migrationBuilder.DropTable(
                name: "revenuetype");
        }
    }
}
