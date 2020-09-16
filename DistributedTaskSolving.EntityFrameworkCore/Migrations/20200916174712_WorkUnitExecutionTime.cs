using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class WorkUnitExecutionTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ExecutionTimeInMs",
                table: "App.JobSystem.WorkUnits",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("296a7658-936c-4781-a903-ee6455b0f746"),
                column: "CreationDateTime",
                value: new DateTime(2020, 9, 16, 17, 47, 11, 892, DateTimeKind.Utc).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("2bc335a2-90de-46b2-b634-9d815a12c578"),
                column: "CreationDateTime",
                value: new DateTime(2020, 9, 16, 17, 47, 11, 892, DateTimeKind.Utc).AddTicks(7221));

            migrationBuilder.UpdateData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("d47dd1ab-291f-4979-b9d1-9b2416728911"),
                column: "CreationDateTime",
                value: new DateTime(2020, 9, 16, 17, 47, 11, 892, DateTimeKind.Utc).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 9, 16, 17, 47, 11, 893, DateTimeKind.Utc).AddTicks(7264));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 9, 16, 17, 47, 11, 893, DateTimeKind.Utc).AddTicks(8074));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 9, 16, 17, 47, 11, 893, DateTimeKind.Utc).AddTicks(8095));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExecutionTimeInMs",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.UpdateData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("296a7658-936c-4781-a903-ee6455b0f746"),
                column: "CreationDateTime",
                value: new DateTime(2020, 9, 7, 20, 25, 44, 883, DateTimeKind.Utc).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("2bc335a2-90de-46b2-b634-9d815a12c578"),
                column: "CreationDateTime",
                value: new DateTime(2020, 9, 7, 20, 25, 44, 883, DateTimeKind.Utc).AddTicks(4029));

            migrationBuilder.UpdateData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("d47dd1ab-291f-4979-b9d1-9b2416728911"),
                column: "CreationDateTime",
                value: new DateTime(2020, 9, 7, 20, 25, 44, 883, DateTimeKind.Utc).AddTicks(3521));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 9, 7, 20, 25, 44, 884, DateTimeKind.Utc).AddTicks(6546));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 9, 7, 20, 25, 44, 884, DateTimeKind.Utc).AddTicks(7464));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 9, 7, 20, 25, 44, 884, DateTimeKind.Utc).AddTicks(7484));
        }
    }
}
