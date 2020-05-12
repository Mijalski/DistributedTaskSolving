using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class workunitsolve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("d3b3c065-dd09-406f-89e0-320c6e13b1db"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("e63c5e76-0b69-41e1-9b66-98e469ec86d0"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("f5493337-0781-42a6-8620-e6d6f44ca2c2"));

            migrationBuilder.AddColumn<bool>(
                name: "IsSolved",
                table: "App.JobSystem.WorkUnits",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("701edbfc-5a10-49e2-aa48-5916f20fad77"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("8f50e03a-a192-4bc5-b233-91390ff04f9d"));

            migrationBuilder.DropColumn(
                name: "IsSolved",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("f5493337-0781-42a6-8620-e6d6f44ca2c2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("e63c5e76-0b69-41e1-9b66-98e469ec86d0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, null, null, "MonteCarlo" },
                    { new Guid("d3b3c065-dd09-406f-89e0-320c6e13b1db"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, null, null, "WordGuessing" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 5, 12, 43, 36, 802, DateTimeKind.Utc).AddTicks(7193));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 5, 12, 43, 36, 802, DateTimeKind.Utc).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 5, 12, 43, 36, 802, DateTimeKind.Utc).AddTicks(8057));
        }
    }
}
