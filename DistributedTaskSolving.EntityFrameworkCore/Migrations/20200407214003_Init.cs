using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DistributedTaskSolving.EntityFrameworkCore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App.ApiLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorUserId = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    RequestTime = table.Column<DateTime>(nullable: false),
                    ResponseMillis = table.Column<long>(nullable: false),
                    StatusCode = table.Column<int>(nullable: false),
                    Method = table.Column<string>(maxLength: 2048, nullable: true),
                    Path = table.Column<string>(maxLength: 2048, nullable: true),
                    QueryString = table.Column<string>(maxLength: 2048, nullable: true),
                    RequestBody = table.Column<string>(maxLength: 2048, nullable: true),
                    ResponseBody = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(maxLength: 45, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App.ApiLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App.ApiLogs_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "App.JobSystem.JobType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatorUserId = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    LastModifierUserId = table.Column<string>(nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App.JobSystem.JobType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.JobType_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.JobType_AspNetUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "App.ProgrammingLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorUserId = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App.ProgrammingLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App.ProgrammingLanguages_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "App.Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorUserId = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    LastModifierUserId = table.Column<string>(nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    ApiKeyHash = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App.Tenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App.Tenants_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_App.Tenants_AspNetUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App.JobSystem.Algorithms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorUserId = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    LastModifierUserId = table.Column<string>(nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<byte[]>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    JobTypeId = table.Column<Guid>(nullable: false),
                    ProgrammingLanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App.JobSystem.Algorithms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.Algorithms_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.Algorithms_App.JobSystem.JobType_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "App.JobSystem.JobType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.Algorithms_AspNetUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.Algorithms_App.ProgrammingLanguages_Programmi~",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "App.ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App.JobSystem.JobInstances",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorUserId = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    LastModifierUserId = table.Column<string>(nullable: true),
                    LastModificationDateTime = table.Column<DateTime>(nullable: true),
                    Key = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    IsSolved = table.Column<bool>(nullable: false),
                    AlgorithmId = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionDateTime = table.Column<DateTime>(nullable: true),
                    JobTypeId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App.JobSystem.JobInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.JobInstances_App.JobSystem.Algorithms_Algorit~",
                        column: x => x.AlgorithmId,
                        principalTable: "App.JobSystem.Algorithms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.JobInstances_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.JobInstances_App.JobSystem.JobType_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "App.JobSystem.JobType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.JobInstances_AspNetUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.JobInstances_App.Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "App.Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "App.JobSystem.WorkUnits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorUserId = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    JobInstanceId = table.Column<long>(nullable: false),
                    DataIn = table.Column<string>(nullable: true),
                    DataOut = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App.JobSystem.WorkUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.WorkUnits_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_App.JobSystem.WorkUnits_App.JobSystem.JobInstances_JobInsta~",
                        column: x => x.JobInstanceId,
                        principalTable: "App.JobSystem.JobInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "App.JobSystem.JobType",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "Description", "IsDeleted", "LastModificationDateTime", "LastModifierUserId", "Name" },
                values: new object[] { new Guid("e414249c-5801-4c5d-ae24-1e3d19e4b0d0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Given a hash of a password, guess the password", false, null, null, "Password Brute Forcing" });

            migrationBuilder.InsertData(
                table: "App.ProgrammingLanguages",
                columns: new[] { "Id", "CreationDateTime", "CreatorUserId", "DeletionDateTime", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 4, 7, 21, 40, 3, 656, DateTimeKind.Utc).AddTicks(8921), null, null, false, "C#" },
                    { 2, new DateTime(2020, 4, 7, 21, 40, 3, 656, DateTimeKind.Utc).AddTicks(9715), null, null, false, "JavaScript" },
                    { 3, new DateTime(2020, 4, 7, 21, 40, 3, 656, DateTimeKind.Utc).AddTicks(9730), null, null, false, "Rust" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_App.ApiLogs_CreatorUserId",
                table: "App.ApiLogs",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_App.ApiLogs_Id",
                table: "App.ApiLogs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_App.ApiLogs_Name",
                table: "App.ApiLogs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.Algorithms_CreatorUserId",
                table: "App.JobSystem.Algorithms",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.Algorithms_Id",
                table: "App.JobSystem.Algorithms",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.Algorithms_JobTypeId",
                table: "App.JobSystem.Algorithms",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.Algorithms_LastModifierUserId",
                table: "App.JobSystem.Algorithms",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.Algorithms_Name",
                table: "App.JobSystem.Algorithms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.Algorithms_ProgrammingLanguageId",
                table: "App.JobSystem.Algorithms",
                column: "ProgrammingLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.JobInstances_AlgorithmId",
                table: "App.JobSystem.JobInstances",
                column: "AlgorithmId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.JobInstances_CreatorUserId",
                table: "App.JobSystem.JobInstances",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.JobInstances_Id",
                table: "App.JobSystem.JobInstances",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.JobInstances_JobTypeId",
                table: "App.JobSystem.JobInstances",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.JobInstances_LastModifierUserId",
                table: "App.JobSystem.JobInstances",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.JobInstances_TenantId",
                table: "App.JobSystem.JobInstances",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.JobType_CreatorUserId",
                table: "App.JobSystem.JobType",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.JobType_Id",
                table: "App.JobSystem.JobType",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.JobType_LastModifierUserId",
                table: "App.JobSystem.JobType",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.JobType_Name",
                table: "App.JobSystem.JobType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.WorkUnits_CreatorUserId",
                table: "App.JobSystem.WorkUnits",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.WorkUnits_Id",
                table: "App.JobSystem.WorkUnits",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.WorkUnits_JobInstanceId",
                table: "App.JobSystem.WorkUnits",
                column: "JobInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_App.JobSystem.WorkUnits_Name",
                table: "App.JobSystem.WorkUnits",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App.ProgrammingLanguages_CreatorUserId",
                table: "App.ProgrammingLanguages",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_App.ProgrammingLanguages_Id",
                table: "App.ProgrammingLanguages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_App.ProgrammingLanguages_Name",
                table: "App.ProgrammingLanguages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App.Tenants_CreatorUserId",
                table: "App.Tenants",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_App.Tenants_Id",
                table: "App.Tenants",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_App.Tenants_LastModifierUserId",
                table: "App.Tenants",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_App.Tenants_Name",
                table: "App.Tenants",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App.ApiLogs");

            migrationBuilder.DropTable(
                name: "App.JobSystem.WorkUnits");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "App.JobSystem.JobInstances");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "App.JobSystem.Algorithms");

            migrationBuilder.DropTable(
                name: "App.Tenants");

            migrationBuilder.DropTable(
                name: "App.JobSystem.JobType");

            migrationBuilder.DropTable(
                name: "App.ProgrammingLanguages");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
