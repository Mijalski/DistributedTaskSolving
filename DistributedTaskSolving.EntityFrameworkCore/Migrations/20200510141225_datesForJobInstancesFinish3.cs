using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class datesForJobInstancesFinish3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("128718f9-2893-4430-bfda-d1c61545f16d"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("bc4d0cc5-f437-4686-be16-f853028015f1"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("544565b2-c73c-422f-8978-0e912ee73270"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("5861d2d6-ae20-4ab2-a95a-cfc9aaa541cd"));

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("bc4d0cc5-f437-4686-be16-f853028015f1"), new DateTime(2020, 5, 10, 13, 57, 10, 634, DateTimeKind.Utc).AddTicks(1185), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("128718f9-2893-4430-bfda-d1c61545f16d"), new DateTime(2020, 5, 10, 13, 57, 10, 634, DateTimeKind.Utc).AddTicks(1686), null, null, null, false, null, null, "MonteCarlo" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 13, 57, 10, 635, DateTimeKind.Utc).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 13, 57, 10, 635, DateTimeKind.Utc).AddTicks(2760));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 13, 57, 10, 635, DateTimeKind.Utc).AddTicks(2778));
        }
    }
}
