using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class changeschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_App.JobSystem.Algorithms_App.ProgrammingLanguages_Programmi~",
                table: "App.JobSystem.Algorithms");

            migrationBuilder.DropForeignKey(
                name: "FK_App.JobSystem.JobInstances_App.JobSystem.Algorithms_Algorit~",
                table: "App.JobSystem.JobInstances");

            migrationBuilder.DropIndex(
                name: "IX_App.JobSystem.JobInstances_AlgorithmId",
                table: "App.JobSystem.JobInstances");

            migrationBuilder.DropIndex(
                name: "IX_App.JobSystem.Algorithms_ProgrammingLanguageId",
                table: "App.JobSystem.Algorithms");

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

            migrationBuilder.DropColumn(
                name: "AlgorithmId",
                table: "App.JobSystem.JobInstances");

            migrationBuilder.DropColumn(
                name: "ProgrammingLanguageId",
                table: "App.JobSystem.Algorithms");

            migrationBuilder.AddColumn<long>(
                name: "AlgorithmId",
                table: "App.JobSystem.WorkUnits",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ProgrammingLanguageId",
                table: "App.JobSystem.WorkUnits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("0ea0bb29-6a0c-409e-a634-aeb6eaa1d185"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("9eec628d-6dd6-4de6-964c-0fbd59a4de8b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, null, null, "MonteCarlo" },
                    { new Guid("b1f60d2a-f9cd-4004-9873-34fb3d6751ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, null, null, "WordGuessing" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 5, 10, 2, 21, 99, DateTimeKind.Utc).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 5, 10, 2, 21, 99, DateTimeKind.Utc).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 5, 10, 2, 21, 99, DateTimeKind.Utc).AddTicks(3301));

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.WorkUnits_AlgorithmId",
                table: "App.JobSystem.WorkUnits",
                column: "AlgorithmId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.WorkUnits_ProgrammingLanguageId",
                table: "App.JobSystem.WorkUnits",
                column: "ProgrammingLanguageId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_App.JobSystem.WorkUnits_App.JobSystem.Algorithms_AlgorithmId",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_App.JobSystem.WorkUnits_App.ProgrammingLanguages_Programmin~",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.DropIndex(
                name: "IX_App.JobSystem.WorkUnits_AlgorithmId",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.DropIndex(
                name: "IX_App.JobSystem.WorkUnits_ProgrammingLanguageId",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("0ea0bb29-6a0c-409e-a634-aeb6eaa1d185"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("9eec628d-6dd6-4de6-964c-0fbd59a4de8b"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("b1f60d2a-f9cd-4004-9873-34fb3d6751ff"));

            migrationBuilder.DropColumn(
                name: "AlgorithmId",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.DropColumn(
                name: "ProgrammingLanguageId",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.AddColumn<long>(
                name: "AlgorithmId",
                table: "App.JobSystem.JobInstances",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ProgrammingLanguageId",
                table: "App.JobSystem.Algorithms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_App.JobSystem.JobInstances_AlgorithmId",
                table: "App.JobSystem.JobInstances",
                column: "AlgorithmId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.Algorithms_ProgrammingLanguageId",
                table: "App.JobSystem.Algorithms",
                column: "ProgrammingLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_App.JobSystem.Algorithms_App.ProgrammingLanguages_Programmi~",
                table: "App.JobSystem.Algorithms",
                column: "ProgrammingLanguageId",
                principalTable: "App.ProgrammingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_App.JobSystem.JobInstances_App.JobSystem.Algorithms_Algorit~",
                table: "App.JobSystem.JobInstances",
                column: "AlgorithmId",
                principalTable: "App.JobSystem.Algorithms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
