using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Anis.Purchases.Data.Migrations
{
    public partial class InitializeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventStore",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AggregateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniqueReferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniqueReferences", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventStore_AggregateId_Sequence",
                table: "EventStore",
                columns: new[] { "AggregateId", "Sequence" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UniqueReferences_CustomerId_Reference",
                table: "UniqueReferences",
                columns: new[] { "CustomerId", "Reference" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventStore");

            migrationBuilder.DropTable(
                name: "UniqueReferences");
        }
    }
}
