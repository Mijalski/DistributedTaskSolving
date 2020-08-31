using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class workUnitClientWithDetailsForWorkUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("1562a24d-1df1-415f-ac6b-d0c01a1ad6f3"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("d8457ccb-4497-4f81-b218-578ce2873e4a"));

            migrationBuilder.AddColumn<long>(
                name: "WorkUnitClientId",
                table: "App.JobSystem.WorkUnits",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "App.JobSystem.WorkUnitClients",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorUserId = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    UserAgent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App.JobSystem.WorkUnitClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.WorkUnitClients_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                columns: new[] { "CreationDateTime", "Name" },
                values: new object[] { new DateTime(2020, 8, 23, 12, 24, 18, 453, DateTimeKind.Utc).AddTicks(6894), "C++" });

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.WorkUnits_WorkUnitClientId",
                table: "App.JobSystem.WorkUnits",
                column: "WorkUnitClientId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.WorkUnitClients_CreatorUserId",
                table: "App.JobSystem.WorkUnitClients",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.WorkUnitClients_Id",
                table: "App.JobSystem.WorkUnitClients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_App.JobSystem.WorkUnits_App.JobSystem.WorkUnitClients_WorkU~",
                table: "App.JobSystem.WorkUnits",
                column: "WorkUnitClientId",
                principalTable: "App.JobSystem.WorkUnitClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_App.JobSystem.WorkUnits_App.JobSystem.WorkUnitClients_WorkU~",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.DropTable(
                name: "App.JobSystem.WorkUnitClients");

            migrationBuilder.DropIndex(
                name: "IX_App.JobSystem.WorkUnits_WorkUnitClientId",
                table: "App.JobSystem.WorkUnits");

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

            migrationBuilder.DropColumn(
                name: "WorkUnitClientId",
                table: "App.JobSystem.WorkUnits");

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("1562a24d-1df1-415f-ac6b-d0c01a1ad6f3"), new DateTime(2020, 5, 10, 17, 27, 35, 671, DateTimeKind.Utc).AddTicks(6115), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("d8457ccb-4497-4f81-b218-578ce2873e4a"), new DateTime(2020, 5, 10, 17, 27, 35, 671, DateTimeKind.Utc).AddTicks(6593), null, null, null, false, null, null, "MonteCarlo" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 17, 27, 35, 672, DateTimeKind.Utc).AddTicks(6559));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 5, 10, 17, 27, 35, 672, DateTimeKind.Utc).AddTicks(7379));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDateTime", "Name" },
                values: new object[] { new DateTime(2020, 5, 10, 17, 27, 35, 672, DateTimeKind.Utc).AddTicks(7398), "Rust" });
        }
    }
}
