using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class WorkUnitConnectionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("2f000a4c-a398-4456-bff4-a5565783ff3e"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("3c359c8a-e911-4144-b28f-f9edff77f10b"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("5de77542-1c37-4c1b-b17f-8428160d5a26"));

            migrationBuilder.AddColumn<string>(
                name: "ConnectionId",
                table: "App.JobSystem.WorkUnits",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.WorkUnits_ConnectionId",
                table: "App.JobSystem.WorkUnits",
                column: "ConnectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_App.JobSystem.WorkUnits_ConnectionId",
                table: "App.JobSystem.WorkUnits");

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

            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("5de77542-1c37-4c1b-b17f-8428160d5a26"), new DateTime(2020, 8, 26, 19, 46, 26, 524, DateTimeKind.Utc).AddTicks(3303), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("2f000a4c-a398-4456-bff4-a5565783ff3e"), new DateTime(2020, 8, 26, 19, 46, 26, 524, DateTimeKind.Utc).AddTicks(3795), null, null, null, false, null, null, "MonteCarlo" },
                    { new Guid("3c359c8a-e911-4144-b28f-f9edff77f10b"), new DateTime(2020, 8, 26, 19, 46, 26, 524, DateTimeKind.Utc).AddTicks(3808), null, null, null, false, null, null, "Sequencing" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 26, 19, 46, 26, 525, DateTimeKind.Utc).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 26, 19, 46, 26, 525, DateTimeKind.Utc).AddTicks(5520));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 26, 19, 46, 26, 525, DateTimeKind.Utc).AddTicks(5540));
        }
    }
}
