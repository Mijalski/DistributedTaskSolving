using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class submitWorkUnitDateNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("41343821-4843-4538-ada7-d7f0bb2f13bc"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("df931f86-6734-42b3-8340-d990270b9248"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmitDateTime",
                table: "App.JobSystem.WorkUnits",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("1562a24d-1df1-415f-ac6b-d0c01a1ad6f3"), new DateTime(2020, 5, 10, 17, 27, 35, 671, DateTimeKind.Utc).AddTicks(6115), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("d8457ccb-4497-4f81-b218-578ce2873e4a"), new DateTime(2020, 5, 10, 17, 27, 35, 671, DateTimeKind.Utc).AddTicks(6593), null, null, null, false, null, null, "MonteCarlo" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 17, 27, 35, 672, DateTimeKind.Utc).AddTicks(6559));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 17, 27, 35, 672, DateTimeKind.Utc).AddTicks(7379));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 17, 27, 35, 672, DateTimeKind.Utc).AddTicks(7398));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("1562a24d-1df1-415f-ac6b-d0c01a1ad6f3"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("d8457ccb-4497-4f81-b218-578ce2873e4a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmitDateTime",
                table: "App.JobSystem.WorkUnits",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("df931f86-6734-42b3-8340-d990270b9248"), new DateTime(2020, 5, 10, 14, 16, 30, 945, DateTimeKind.Utc).AddTicks(1799), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("41343821-4843-4538-ada7-d7f0bb2f13bc"), new DateTime(2020, 5, 10, 14, 16, 30, 945, DateTimeKind.Utc).AddTicks(2286), null, null, null, false, null, null, "MonteCarlo" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 14, 16, 30, 946, DateTimeKind.Utc).AddTicks(2495));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 14, 16, 30, 946, DateTimeKind.Utc).AddTicks(3337));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 14, 16, 30, 946, DateTimeKind.Utc).AddTicks(3357));
        }
    }
}
