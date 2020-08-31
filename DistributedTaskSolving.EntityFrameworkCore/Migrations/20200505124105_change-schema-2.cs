using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class changeschema2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_App.JobSystem.JobInstances_App.JobSystem.JobType_JobTypeId",
                table: "App.JobSystem.JobInstances");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "JobTypeId",
                table: "App.JobSystem.JobInstances",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
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
                name: "FK_App.JobSystem.JobInstances_App.JobSystem.JobType_JobTypeId",
                table: "App.JobSystem.JobInstances",
                column: "JobTypeId",
                principalTable: "App.JobSystem.JobType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_App.JobSystem.JobInstances_App.JobSystem.JobType_JobTypeId",
                table: "App.JobSystem.JobInstances");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "JobTypeId",
                table: "App.JobSystem.JobInstances",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

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

            migrationBuilder.AddForeignKey(
                name: "FK_App.JobSystem.JobInstances_App.JobSystem.JobType_JobTypeId",
                table: "App.JobSystem.JobInstances",
                column: "JobTypeId",
                principalTable: "App.JobSystem.JobType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
