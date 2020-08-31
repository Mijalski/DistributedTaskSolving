using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class datesForJobInstancesFinish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("701edbfc-5a10-49e2-aa48-5916f20fad77"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("8f50e03a-a192-4bc5-b233-91390ff04f9d"));

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmitDateTime",
                table: "App.JobSystem.WorkUnits",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDateTime",
                table: "App.JobSystem.JobInstances",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("caf8a468-3028-4bd6-9643-2d11ab2844d1"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("feeb1670-25ad-4da7-8159-112729f07079"));

            migrationBuilder.DropColumn(
                name: "SubmitDateTime",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.DropColumn(
                name: "FinishDateTime",
                table: "App.JobSystem.JobInstances");

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("8f50e03a-a192-4bc5-b233-91390ff04f9d"), new DateTime(2020, 5, 10, 12, 37, 37, 823, DateTimeKind.Utc).AddTicks(550), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("701edbfc-5a10-49e2-aa48-5916f20fad77"), new DateTime(2020, 5, 10, 12, 37, 37, 823, DateTimeKind.Utc).AddTicks(1111), null, null, null, false, null, null, "MonteCarlo" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 12, 37, 37, 824, DateTimeKind.Utc).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 12, 37, 37, 824, DateTimeKind.Utc).AddTicks(2359));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 12, 37, 37, 824, DateTimeKind.Utc).AddTicks(2381));
        }
    }
}
