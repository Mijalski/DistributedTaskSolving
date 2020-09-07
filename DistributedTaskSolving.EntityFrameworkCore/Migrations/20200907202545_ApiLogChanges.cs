using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class ApiLogChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("689939f8-0163-47e9-80b0-6fbb05759f16"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("a65892a0-50b2-4ff4-8cc1-e120fd4a1254"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("d6062a98-8f25-4e1f-8003-1268fcc111cf"));

            migrationBuilder.DropColumn(
                name: "DeletionDateTime",
                table: "App.ApiLogs");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "App.ApiLogs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "App.ApiLogs");

            migrationBuilder.DropColumn(
                name: "Method",
                table: "App.ApiLogs");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "App.ApiLogs");

            migrationBuilder.DropColumn(
                name: "QueryString",
                table: "App.ApiLogs");

            migrationBuilder.DropColumn(
                name: "RequestBody",
                table: "App.ApiLogs");

            migrationBuilder.DropColumn(
                name: "RequestTime",
                table: "App.ApiLogs");

            migrationBuilder.DropColumn(
                name: "ResponseMillis",
                table: "App.ApiLogs");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "App.ApiLogs");

            migrationBuilder.AddColumn<string>(
                name: "Exception",
                table: "App.ApiLogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "App.ApiLogs",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logger",
                table: "App.ApiLogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "App.ApiLogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestMethod",
                table: "App.ApiLogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestUrl",
                table: "App.ApiLogs",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponseCode",
                table: "App.ApiLogs",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TraceIdentifier",
                table: "App.ApiLogs",
                nullable: true);

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("d47dd1ab-291f-4979-b9d1-9b2416728911"), new DateTime(2020, 9, 7, 20, 25, 44, 883, DateTimeKind.Utc).AddTicks(3521), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("2bc335a2-90de-46b2-b634-9d815a12c578"), new DateTime(2020, 9, 7, 20, 25, 44, 883, DateTimeKind.Utc).AddTicks(4029), null, null, null, false, null, null, "MonteCarlo" },
                    { new Guid("296a7658-936c-4781-a903-ee6455b0f746"), new DateTime(2020, 9, 7, 20, 25, 44, 883, DateTimeKind.Utc).AddTicks(4041), null, null, null, false, null, null, "Sequencing" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("296a7658-936c-4781-a903-ee6455b0f746"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("2bc335a2-90de-46b2-b634-9d815a12c578"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("d47dd1ab-291f-4979-b9d1-9b2416728911"));

            migrationBuilder.DropColumn(
                name: "Exception",
                table: "App.ApiLogs");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "App.ApiLogs");

            migrationBuilder.DropColumn(
                name: "Logger",
                table: "App.ApiLogs");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "App.ApiLogs");

            migrationBuilder.DropColumn(
                name: "RequestMethod",
                table: "App.ApiLogs");

            migrationBuilder.DropColumn(
                name: "RequestUrl",
                table: "App.ApiLogs");

            migrationBuilder.DropColumn(
                name: "ResponseCode",
                table: "App.ApiLogs");

            migrationBuilder.DropColumn(
                name: "TraceIdentifier",
                table: "App.ApiLogs");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDateTime",
                table: "App.ApiLogs",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "App.ApiLogs",
                type: "character varying(45)",
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "App.ApiLogs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Method",
                table: "App.ApiLogs",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "App.ApiLogs",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QueryString",
                table: "App.ApiLogs",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestBody",
                table: "App.ApiLogs",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestTime",
                table: "App.ApiLogs",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "ResponseMillis",
                table: "App.ApiLogs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "App.ApiLogs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("689939f8-0163-47e9-80b0-6fbb05759f16"), new DateTime(2020, 8, 31, 18, 45, 39, 660, DateTimeKind.Utc).AddTicks(6180), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("d6062a98-8f25-4e1f-8003-1268fcc111cf"), new DateTime(2020, 8, 31, 18, 45, 39, 660, DateTimeKind.Utc).AddTicks(6680), null, null, null, false, null, null, "MonteCarlo" },
                    { new Guid("a65892a0-50b2-4ff4-8cc1-e120fd4a1254"), new DateTime(2020, 8, 31, 18, 45, 39, 660, DateTimeKind.Utc).AddTicks(6690), null, null, null, false, null, null, "Sequencing" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 31, 18, 45, 39, 661, DateTimeKind.Utc).AddTicks(6890));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 31, 18, 45, 39, 661, DateTimeKind.Utc).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 31, 18, 45, 39, 661, DateTimeKind.Utc).AddTicks(7820));
        }
    }
}
