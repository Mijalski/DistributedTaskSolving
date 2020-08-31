using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class jobInstanceAddedParameters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "App.JobSystem.JobInstanceParameters",
                columns: table => new
                {
                    JobInstanceId = table.Column<long>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    CreatorUserId = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    LastModifierUserId = table.Column<string>(nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
