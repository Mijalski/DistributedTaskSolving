using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.JobInstances_CreationDateTime",
                table: "App.JobSystem.JobInstances",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.JobInstances_IsSolved",
                table: "App.JobSystem.JobInstances",
                column: "IsSolved");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_App.JobSystem.JobInstances_CreationDateTime",
                table: "App.JobSystem.JobInstances");

            migrationBuilder.DropIndex(
                name: "IX_App.JobSystem.JobInstances_IsSolved",
                table: "App.JobSystem.JobInstances");

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
        }
    }
}
