using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class changeschema3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_App.JobSystem.WorkUnits_App.JobSystem.Algorithms_AlgorithmId",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_App.JobSystem.WorkUnits_App.ProgrammingLanguages_Programmin~",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("0ab463d6-2216-44bf-b578-f01a490cf7a0"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("71ac9ce1-0d1a-4889-903f-5a8521dc4c86"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("78dbffb0-2ec4-4538-9209-502ebd4ee53b"));

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammingLanguageId",
                table: "App.JobSystem.WorkUnits",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "AlgorithmId",
                table: "App.JobSystem.WorkUnits",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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

            migrationBuilder.AddForeignKey(
                name: "FK_App.JobSystem.WorkUnits_App.JobSystem.Algorithms_AlgorithmId",
                table: "App.JobSystem.WorkUnits",
                column: "AlgorithmId",
                principalTable: "App.JobSystem.Algorithms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_App.JobSystem.WorkUnits_App.ProgrammingLanguages_Programmin~",
                table: "App.JobSystem.WorkUnits",
                column: "ProgrammingLanguageId",
                principalTable: "App.ProgrammingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_App.JobSystem.WorkUnits_App.JobSystem.Algorithms_AlgorithmId",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_App.JobSystem.WorkUnits_App.ProgrammingLanguages_Programmin~",
                table: "App.JobSystem.WorkUnits");

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

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammingLanguageId",
                table: "App.JobSystem.WorkUnits",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AlgorithmId",
                table: "App.JobSystem.WorkUnits",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("0ab463d6-2216-44bf-b578-f01a490cf7a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("78dbffb0-2ec4-4538-9209-502ebd4ee53b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, null, null, "MonteCarlo" },
                    { new Guid("71ac9ce1-0d1a-4889-903f-5a8521dc4c86"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, null, null, "WordGuessing" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 5, 12, 41, 4, 713, DateTimeKind.Utc).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 5, 12, 41, 4, 713, DateTimeKind.Utc).AddTicks(3212));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 5, 12, 41, 4, 713, DateTimeKind.Utc).AddTicks(3237));

            migrationBuilder.AddForeignKey(
                name: "FK_App.JobSystem.WorkUnits_App.JobSystem.Algorithms_AlgorithmId",
                table: "App.JobSystem.WorkUnits",
                column: "AlgorithmId",
                principalTable: "App.JobSystem.Algorithms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_App.JobSystem.WorkUnits_App.ProgrammingLanguages_Programmin~",
                table: "App.JobSystem.WorkUnits",
                column: "ProgrammingLanguageId",
                principalTable: "App.ProgrammingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
