using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class uniquenamejobtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("d8b508ab-152d-4e3f-9a27-b9d3e7784d7c"));

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("6e1963ae-aa5f-4be0-bded-f222e6c11f2d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("8e1f73f8-cbef-4762-a3d3-0dd5ac74f018"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, null, null, "MonteCarlo" },
                    { new Guid("392b07c5-cf88-4e05-ba6b-6a73d93b032b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, null, null, "WordGuessing" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 4, 23, 12, 25, 52, 918, DateTimeKind.Utc).AddTicks(5643));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 4, 23, 12, 25, 52, 918, DateTimeKind.Utc).AddTicks(6490));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 4, 23, 12, 25, 52, 918, DateTimeKind.Utc).AddTicks(6510));

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.JobType_Name",
                table: "App.JobSystem.JobType",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_App.JobSystem.JobType_Name",
                table: "App.JobSystem.JobType");

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("392b07c5-cf88-4e05-ba6b-6a73d93b032b"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("6e1963ae-aa5f-4be0-bded-f222e6c11f2d"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("8e1f73f8-cbef-4762-a3d3-0dd5ac74f018"));

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[] { new Guid("d8b508ab-152d-4e3f-9a27-b9d3e7784d7c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Given a hash of a password, guess the password", false, null, null, "Password Brute Forcing" });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 4, 22, 17, 50, 23, 331, DateTimeKind.Utc).AddTicks(7776));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 4, 22, 17, 50, 23, 331, DateTimeKind.Utc).AddTicks(8717));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 4, 22, 17, 50, 23, 331, DateTimeKind.Utc).AddTicks(8732));
        }
    }
}
