using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class AddIsAbandonedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("18c551d2-0178-499b-a68b-8b3c08a1b351"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("32427488-6a3f-4e02-a515-382c7bfb5131"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("c7027645-2829-485f-ac66-8cc1fa9bfb37"));

            migrationBuilder.AddColumn<bool>(
                name: "IsAbandoned",
                table: "App.JobSystem.WorkUnits",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("e7c94636-f8d6-4f34-87c8-b44635e2ce84"), new DateTime(2020, 8, 26, 20, 23, 34, 556, DateTimeKind.Utc).AddTicks(2610), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("05e65cdd-01dd-413c-9af7-e117e7b03350"), new DateTime(2020, 8, 26, 20, 23, 34, 556, DateTimeKind.Utc).AddTicks(3110), null, null, null, false, null, null, "MonteCarlo" },
                    { new Guid("427f0b43-659b-417e-9c52-74e6c13b58a8"), new DateTime(2020, 8, 26, 20, 23, 34, 556, DateTimeKind.Utc).AddTicks(3120), null, null, null, false, null, null, "Sequencing" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 26, 20, 23, 34, 557, DateTimeKind.Utc).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 26, 20, 23, 34, 557, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 26, 20, 23, 34, 557, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.WorkUnits_IsAbandoned",
                table: "App.JobSystem.WorkUnits",
                column: "IsAbandoned");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_App.JobSystem.WorkUnits_IsAbandoned",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("05e65cdd-01dd-413c-9af7-e117e7b03350"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("427f0b43-659b-417e-9c52-74e6c13b58a8"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("e7c94636-f8d6-4f34-87c8-b44635e2ce84"));

            migrationBuilder.DropColumn(
                name: "IsAbandoned",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("18c551d2-0178-499b-a68b-8b3c08a1b351"), new DateTime(2020, 8, 26, 20, 6, 4, 163, DateTimeKind.Utc).AddTicks(1090), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("c7027645-2829-485f-ac66-8cc1fa9bfb37"), new DateTime(2020, 8, 26, 20, 6, 4, 163, DateTimeKind.Utc).AddTicks(1590), null, null, null, false, null, null, "MonteCarlo" },
                    { new Guid("32427488-6a3f-4e02-a515-382c7bfb5131"), new DateTime(2020, 8, 26, 20, 6, 4, 163, DateTimeKind.Utc).AddTicks(1600), null, null, null, false, null, null, "Sequencing" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 26, 20, 6, 4, 164, DateTimeKind.Utc).AddTicks(1390));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 26, 20, 6, 4, 164, DateTimeKind.Utc).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 26, 20, 6, 4, 164, DateTimeKind.Utc).AddTicks(2180));
        }
    }
}
