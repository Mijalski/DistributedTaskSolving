using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class datesForJobInstancesFinish4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("544565b2-c73c-422f-8978-0e912ee73270"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("5861d2d6-ae20-4ab2-a95a-cfc9aaa541cd"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishDateTime",
                table: "App.JobSystem.JobInstances",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FinishDateTime",
                table: "App.JobSystem.JobInstances",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("5861d2d6-ae20-4ab2-a95a-cfc9aaa541cd"), new DateTime(2020, 5, 10, 14, 12, 24, 692, DateTimeKind.Utc).AddTicks(1351), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("544565b2-c73c-422f-8978-0e912ee73270"), new DateTime(2020, 5, 10, 14, 12, 24, 692, DateTimeKind.Utc).AddTicks(1842), null, null, null, false, null, null, "MonteCarlo" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 14, 12, 24, 693, DateTimeKind.Utc).AddTicks(1904));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 14, 12, 24, 693, DateTimeKind.Utc).AddTicks(2723));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 14, 12, 24, 693, DateTimeKind.Utc).AddTicks(2744));
        }
    }
}
