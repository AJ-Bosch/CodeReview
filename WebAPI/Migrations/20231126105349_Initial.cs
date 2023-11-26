using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COMPANY",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "INSPECTIONCLASS",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSPECTIONCLASS", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "ROLE",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessLevel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "PROJECT",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyCode = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_PROJECT_COMPANY_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "COMPANY",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    CompanyCode = table.Column<int>(type: "int", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_USER_COMPANY_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "COMPANY",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_ROLE_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ROLE",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "ASSETS",
                columns: table => new
                {
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(10,8)", precision: 10, scale: 8, nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(11,8)", precision: 11, scale: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSETS", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_ASSETS_PROJECT_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "PROJECT",
                        principalColumn: "ProjectId");
                });

            migrationBuilder.CreateTable(
                name: "INSPECTIONTYPE",
                columns: table => new
                {
                    InspectionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSPECTIONTYPE", x => x.InspectionTypeId);
                    table.ForeignKey(
                        name: "FK_INSPECTIONTYPE_PROJECT_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "PROJECT",
                        principalColumn: "ProjectId");
                });

            migrationBuilder.CreateTable(
                name: "PROJECTSETTINGS",
                columns: table => new
                {
                    SettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    GpsAssetSearch = table.Column<bool>(type: "bit", nullable: true),
                    Maps = table.Column<bool>(type: "bit", nullable: true),
                    LocationTracking = table.Column<bool>(type: "bit", nullable: true),
                    MaxDistanceFromAsset = table.Column<int>(type: "int", nullable: true),
                    TrackingStartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    TrackingEndTime = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECTSETTINGS", x => x.SettingId);
                    table.ForeignKey(
                        name: "FK_PROJECTSETTINGS_PROJECT_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "PROJECT",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INSPECTIONHEADER",
                columns: table => new
                {
                    HeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    InspectionTypeId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(10,8)", precision: 10, scale: 8, nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(11,8)", precision: 11, scale: 8, nullable: true),
                    Pass = table.Column<bool>(type: "bit", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSPECTIONHEADER", x => x.HeaderId);
                    table.ForeignKey(
                        name: "FK_INSPECTIONHEADER_COMPANY_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "COMPANY",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INSPECTIONHEADER_INSPECTIONTYPE_InspectionTypeId",
                        column: x => x.InspectionTypeId,
                        principalTable: "INSPECTIONTYPE",
                        principalColumn: "InspectionTypeId");
                    table.ForeignKey(
                        name: "FK_INSPECTIONHEADER_PROJECT_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "PROJECT",
                        principalColumn: "ProjectId");
                    table.ForeignKey(
                        name: "FK_INSPECTIONHEADER_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "INSPECTIONS",
                columns: table => new
                {
                    InspectionCheckId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionTypeId = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    InspectionClassClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSPECTIONS", x => x.InspectionCheckId);
                    table.ForeignKey(
                        name: "FK_INSPECTIONS_INSPECTIONCLASS_InspectionClassClassId",
                        column: x => x.InspectionClassClassId,
                        principalTable: "INSPECTIONCLASS",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INSPECTIONS_INSPECTIONTYPE_InspectionTypeId",
                        column: x => x.InspectionTypeId,
                        principalTable: "INSPECTIONTYPE",
                        principalColumn: "InspectionTypeId");
                });

            migrationBuilder.CreateTable(
                name: "INSPECTIONLINE",
                columns: table => new
                {
                    LineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderId = table.Column<int>(type: "int", nullable: true),
                    CheckId = table.Column<int>(type: "int", nullable: true),
                    ResultBoolean = table.Column<bool>(type: "bit", nullable: true),
                    ResultText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultDropdown = table.Column<int>(type: "int", nullable: true),
                    InspectionHeaderHeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSPECTIONLINE", x => x.LineId);
                    table.ForeignKey(
                        name: "FK_INSPECTIONLINE_INSPECTIONHEADER_InspectionHeaderHeaderId",
                        column: x => x.InspectionHeaderHeaderId,
                        principalTable: "INSPECTIONHEADER",
                        principalColumn: "HeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ASSETS_ProjectId",
                table: "ASSETS",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTIONHEADER_CompanyId",
                table: "INSPECTIONHEADER",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTIONHEADER_InspectionTypeId",
                table: "INSPECTIONHEADER",
                column: "InspectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTIONHEADER_ProjectId",
                table: "INSPECTIONHEADER",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTIONHEADER_UserId",
                table: "INSPECTIONHEADER",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTIONLINE_InspectionHeaderHeaderId",
                table: "INSPECTIONLINE",
                column: "InspectionHeaderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTIONS_InspectionClassClassId",
                table: "INSPECTIONS",
                column: "InspectionClassClassId");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTIONS_InspectionTypeId",
                table: "INSPECTIONS",
                column: "InspectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTIONTYPE_ProjectId",
                table: "INSPECTIONTYPE",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_CompanyId",
                table: "PROJECT",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECTSETTINGS_ProjectId",
                table: "PROJECTSETTINGS",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_CompanyId",
                table: "USER",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_RoleId",
                table: "USER",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ASSETS");

            migrationBuilder.DropTable(
                name: "INSPECTIONLINE");

            migrationBuilder.DropTable(
                name: "INSPECTIONS");

            migrationBuilder.DropTable(
                name: "PROJECTSETTINGS");

            migrationBuilder.DropTable(
                name: "INSPECTIONHEADER");

            migrationBuilder.DropTable(
                name: "INSPECTIONCLASS");

            migrationBuilder.DropTable(
                name: "INSPECTIONTYPE");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "PROJECT");

            migrationBuilder.DropTable(
                name: "ROLE");

            migrationBuilder.DropTable(
                name: "COMPANY");
        }
    }
}
