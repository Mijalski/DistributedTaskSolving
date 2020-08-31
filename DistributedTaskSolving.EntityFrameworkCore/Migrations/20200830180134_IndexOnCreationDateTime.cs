using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class IndexOnCreationDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("4c0bec7b-e370-46de-970c-5d314c7a97da"), new DateTime(2020, 8, 30, 18, 1, 34, 15, DateTimeKind.Utc).AddTicks(5580), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("0bac6d93-209c-4146-8d2d-20795c0c8e4c"), new DateTime(2020, 8, 30, 18, 1, 34, 15, DateTimeKind.Utc).AddTicks(6150), null, null, null, false, null, null, "MonteCarlo" },
                    { new Guid("934f8b64-30ea-45d7-b6e2-68a50c688405"), new DateTime(2020, 8, 30, 18, 1, 34, 15, DateTimeKind.Utc).AddTicks(6170), null, null, null, false, null, null, "Sequencing" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 30, 18, 1, 34, 16, DateTimeKind.Utc).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 30, 18, 1, 34, 16, DateTimeKind.Utc).AddTicks(8590));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 30, 18, 1, 34, 16, DateTimeKind.Utc).AddTicks(8610));

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.WorkUnits_CreationDateTime",
                table: "App.JobSystem.WorkUnits",
                column: "CreationDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_App.JobSystem.WorkUnits_CreationDateTime",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("0bac6d93-209c-4146-8d2d-20795c0c8e4c"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("4c0bec7b-e370-46de-970c-5d314c7a97da"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("934f8b64-30ea-45d7-b6e2-68a50c688405"));

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
        }
    }
}
