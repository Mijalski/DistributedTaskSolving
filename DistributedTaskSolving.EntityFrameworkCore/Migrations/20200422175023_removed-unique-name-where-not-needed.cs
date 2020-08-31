using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class removeduniquenamewherenotneeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_App.Tenants_Name",
                table: "App.Tenants");

            migrationBuilder.DropIndex(
                name: "IX_App.ProgrammingLanguages_Name",
                table: "App.ProgrammingLanguages");

            migrationBuilder.DropIndex(
                name: "IX_App.JobSystem.WorkUnits_Name",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.DropIndex(
                name: "IX_App.JobSystem.JobType_Name",
                table: "App.JobSystem.JobType");

            migrationBuilder.DropIndex(
                name: "IX_App.JobSystem.Algorithms_Name",
                table: "App.JobSystem.Algorithms");

            migrationBuilder.DropIndex(
                name: "IX_App.ApiLogs_Name",
                table: "App.ApiLogs");

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("e414249c-5801-4c5d-ae24-1e3d19e4b0d0"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "App.ApiLogs");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("d8b508ab-152d-4e3f-9a27-b9d3e7784d7c"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "App.JobSystem.WorkUnits",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Name",
                table: "App.ApiLogs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[] { new Guid("e414249c-5801-4c5d-ae24-1e3d19e4b0d0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Given a hash of a password, guess the password", false, null, null, "Password Brute Forcing" });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 4, 7, 21, 40, 3, 656, DateTimeKind.Utc).AddTicks(8921));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 4, 7, 21, 40, 3, 656, DateTimeKind.Utc).AddTicks(9715));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 4, 7, 21, 40, 3, 656, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.CreateIndex(
                name: "IX_App.Tenants_Name",
                table: "App.Tenants",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App.ProgrammingLanguages_Name",
                table: "App.ProgrammingLanguages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.WorkUnits_Name",
                table: "App.JobSystem.WorkUnits",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.JobType_Name",
                table: "App.JobSystem.JobType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.Algorithms_Name",
                table: "App.JobSystem.Algorithms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App.ApiLogs_Name",
                table: "App.ApiLogs",
                column: "Name",
                unique: true);
        }
    }
}
