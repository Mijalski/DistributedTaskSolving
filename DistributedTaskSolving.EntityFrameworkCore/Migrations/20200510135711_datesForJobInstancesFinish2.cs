using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class datesForJobInstancesFinish2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("caf8a468-3028-4bd6-9643-2d11ab2844d1"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("feeb1670-25ad-4da7-8159-112729f07079"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("caf8a468-3028-4bd6-9643-2d11ab2844d1"), new DateTime(2020, 5, 10, 13, 46, 57, 148, DateTimeKind.Utc).AddTicks(4526), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("feeb1670-25ad-4da7-8159-112729f07079"), new DateTime(2020, 5, 10, 13, 46, 57, 148, DateTimeKind.Utc).AddTicks(5236), null, null, null, false, null, null, "MonteCarlo" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 13, 46, 57, 149, DateTimeKind.Utc).AddTicks(6463));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 13, 46, 57, 149, DateTimeKind.Utc).AddTicks(7278));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 13, 46, 57, 149, DateTimeKind.Utc).AddTicks(7297));
        }
    }
}
