using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class workUnitClientRam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("6fc6c86b-8fcf-42d4-8de8-afdd5890f7bd"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("7f831d52-37c0-4675-b978-64d234576f91"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("a20db55e-5094-4511-b2f8-45ee370a065f"));

            migrationBuilder.AddColumn<string>(
                name: "RamSize",
                table: "App.JobSystem.WorkUnitClients",
                nullable: true);

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("5191adae-d7a1-4c5e-abae-91fbecbab66f"), new DateTime(2020, 8, 25, 18, 38, 8, 900, DateTimeKind.Utc).AddTicks(4917), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("e0e79b2c-4369-4e94-bdcf-8e7292919545"), new DateTime(2020, 8, 25, 18, 38, 8, 900, DateTimeKind.Utc).AddTicks(5251), null, null, null, false, null, null, "MonteCarlo" },
                    { new Guid("13fa662c-19bc-4a38-87ee-b3de4501a971"), new DateTime(2020, 8, 25, 18, 38, 8, 900, DateTimeKind.Utc).AddTicks(5263), null, null, null, false, null, null, "Sequencing" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 25, 18, 38, 8, 901, DateTimeKind.Utc).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 25, 18, 38, 8, 901, DateTimeKind.Utc).AddTicks(5152));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 25, 18, 38, 8, 901, DateTimeKind.Utc).AddTicks(5175));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("13fa662c-19bc-4a38-87ee-b3de4501a971"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("5191adae-d7a1-4c5e-abae-91fbecbab66f"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("e0e79b2c-4369-4e94-bdcf-8e7292919545"));

            migrationBuilder.DropColumn(
                name: "RamSize",
                table: "App.JobSystem.WorkUnitClients");

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("a20db55e-5094-4511-b2f8-45ee370a065f"), new DateTime(2020, 8, 23, 12, 24, 18, 452, DateTimeKind.Utc).AddTicks(7474), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("7f831d52-37c0-4675-b978-64d234576f91"), new DateTime(2020, 8, 23, 12, 24, 18, 452, DateTimeKind.Utc).AddTicks(7800), null, null, null, false, null, null, "MonteCarlo" },
                    { new Guid("6fc6c86b-8fcf-42d4-8de8-afdd5890f7bd"), new DateTime(2020, 8, 23, 12, 24, 18, 452, DateTimeKind.Utc).AddTicks(7811), null, null, null, false, null, null, "Sequencing" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 23, 12, 24, 18, 453, DateTimeKind.Utc).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 23, 12, 24, 18, 453, DateTimeKind.Utc).AddTicks(6872));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 23, 12, 24, 18, 453, DateTimeKind.Utc).AddTicks(6894));
        }
    }
}
