using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "grpc_data",
                columns: table => new
                {
                    packet_seq_num = table.Column<int>(type: "integer", nullable: false),
                    record_seq_num = table.Column<int>(type: "integer", nullable: false),
                    packet_timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    decimal1 = table.Column<string>(type: "text", nullable: false),
                    decimal2 = table.Column<string>(type: "text", nullable: false),
                    decimal3 = table.Column<string>(type: "text", nullable: false),
                    decimal4 = table.Column<string>(type: "text", nullable: false),
                    record_timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grpc_data", x => new { x.packet_seq_num, x.record_seq_num });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "grpc_data");
        }
    }
}
