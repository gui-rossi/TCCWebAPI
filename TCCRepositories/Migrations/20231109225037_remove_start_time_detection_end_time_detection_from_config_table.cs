using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCCRepositories.Migrations
{
    public partial class remove_start_time_detection_end_time_detection_from_config_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTimeLight",
                table: "Config",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "EndTimeLight",
                table: "Config",
                newName: "EndTime");

            migrationBuilder.DropColumn(
                name: "StartTimeDetection",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "EndTimeDetection",
                table: "Config");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
