using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class removeJobInstanceParameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App.JobSystem.JobInstanceParameters");

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("17bdee0e-d842-4bad-9a45-e56c56cb3c24"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("8b284120-cb53-41c2-94ff-69473853d000"));

            migrationBuilder.DeleteData(
                table: "App.JobSystem.JobType",
                keyColumn: "Id",
                keyValue: new Guid("91bcea42-3515-4c16-aa3a-41a89e1a3fb7"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "App.JobSystem.JobInstanceParameters",
                columns: table => new
                {
                    JobInstanceId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<string>(type: "text", nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App.JobSystem.JobInstanceParameters", x => x.JobInstanceId);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.JobInstanceParameters_AspNetUsers_CreatorUser~",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.JobInstanceParameters_App.JobSystem.JobInstan~",
                        column: x => x.JobInstanceId,
                        principalTable: "App.JobSystem.JobInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.JobInstanceParameters_AspNetUsers_LastModifie~",
                        column: x => x.LastModifierUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { new Guid("91bcea42-3515-4c16-aa3a-41a89e1a3fb7"), new DateTime(2020, 8, 25, 19, 27, 29, 570, DateTimeKind.Utc).AddTicks(7750), null, null, null, false, null, null, "PasswordBruteForcing" },
                    { new Guid("17bdee0e-d842-4bad-9a45-e56c56cb3c24"), new DateTime(2020, 8, 25, 19, 27, 29, 570, DateTimeKind.Utc).AddTicks(8090), null, null, null, false, null, null, "MonteCarlo" },
                    { new Guid("8b284120-cb53-41c2-94ff-69473853d000"), new DateTime(2020, 8, 25, 19, 27, 29, 570, DateTimeKind.Utc).AddTicks(8101), null, null, null, false, null, null, "Sequencing" }
                });

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 25, 19, 27, 29, 571, DateTimeKind.Utc).AddTicks(6846));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 25, 19, 27, 29, 571, DateTimeKind.Utc).AddTicks(7395));

            migrationBuilder.UpdateData(
                table: "App.ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDateTime",
                value: new DateTime(2020, 8, 25, 19, 27, 29, 571, DateTimeKind.Utc).AddTicks(7421));

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.JobInstanceParameters_CreatorUserId",
                table: "App.JobSystem.JobInstanceParameters",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.JobInstanceParameters_LastModifierUserId",
                table: "App.JobSystem.JobInstanceParameters",
                column: "LastModifierUserId");
        }
    }
}
