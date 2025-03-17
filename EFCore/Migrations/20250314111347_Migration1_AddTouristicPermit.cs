using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Migration1_AddTouristicPermit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestID);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TouristicPermit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessPhysicalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderID);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    ExperienceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProviderID_FK = table.Column<int>(type: "int", nullable: false),
                    ProviderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.ExperienceID);
                    table.ForeignKey(
                        name: "FK_Experiences_Providers_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Providers",
                        principalColumn: "ProviderID");
                    table.ForeignKey(
                        name: "FK_Experiences_Providers_ProviderID_FK",
                        column: x => x.ProviderID_FK,
                        principalTable: "Providers",
                        principalColumn: "ProviderID");
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    ExperienceID_FK = table.Column<int>(type: "int", nullable: false),
                    GroupSize = table.Column<int>(type: "int", nullable: false),
                    PriceAfterDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExperienceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => new { x.ExperienceID_FK, x.GroupSize });
                    table.ForeignKey(
                        name: "FK_Discounts_Experiences_ExperienceID",
                        column: x => x.ExperienceID,
                        principalTable: "Experiences",
                        principalColumn: "ExperienceID");
                    table.ForeignKey(
                        name: "FK_Discounts_Experiences_ExperienceID_FK",
                        column: x => x.ExperienceID_FK,
                        principalTable: "Experiences",
                        principalColumn: "ExperienceID");
                });

            migrationBuilder.CreateTable(
                name: "SharedExperiences",
                columns: table => new
                {
                    ShareExperienceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExperienceID_FK = table.Column<int>(type: "int", nullable: false),
                    ExperienceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedExperiences", x => x.ShareExperienceID);
                    table.ForeignKey(
                        name: "FK_SharedExperiences_Experiences_ExperienceID",
                        column: x => x.ExperienceID,
                        principalTable: "Experiences",
                        principalColumn: "ExperienceID");
                    table.ForeignKey(
                        name: "FK_SharedExperiences_Experiences_ExperienceID_FK",
                        column: x => x.ExperienceID_FK,
                        principalTable: "Experiences",
                        principalColumn: "ExperienceID");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestID = table.Column<int>(type: "int", nullable: false),
                    ExperienceID_FK = table.Column<int>(type: "int", nullable: false),
                    GroupSize_FK = table.Column<int>(type: "int", nullable: false),
                    PriceAfterDiscount_PK = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExperienceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_Reservations_Discounts_ExperienceID_FK_GroupSize_FK",
                        columns: x => new { x.ExperienceID_FK, x.GroupSize_FK },
                        principalTable: "Discounts",
                        principalColumns: new[] { "ExperienceID_FK", "GroupSize" });
                    table.ForeignKey(
                        name: "FK_Reservations_Experiences_ExperienceID",
                        column: x => x.ExperienceID,
                        principalTable: "Experiences",
                        principalColumn: "ExperienceID");
                    table.ForeignKey(
                        name: "FK_Reservations_Experiences_ExperienceID_FK",
                        column: x => x.ExperienceID_FK,
                        principalTable: "Experiences",
                        principalColumn: "ExperienceID");
                    table.ForeignKey(
                        name: "FK_Reservations_Guests_GuestID",
                        column: x => x.GuestID,
                        principalTable: "Guests",
                        principalColumn: "GuestID");
                });

            migrationBuilder.CreateTable(
                name: "GuestSharedExperiences",
                columns: table => new
                {
                    ShareExperienceID = table.Column<int>(type: "int", nullable: false),
                    GuestID = table.Column<int>(type: "int", nullable: false),
                    SharedExperienceShareExperienceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestSharedExperiences", x => new { x.ShareExperienceID, x.GuestID });
                    table.ForeignKey(
                        name: "FK_GuestSharedExperiences_Guests_GuestID",
                        column: x => x.GuestID,
                        principalTable: "Guests",
                        principalColumn: "GuestID");
                    table.ForeignKey(
                        name: "FK_GuestSharedExperiences_SharedExperiences_ShareExperienceID",
                        column: x => x.ShareExperienceID,
                        principalTable: "SharedExperiences",
                        principalColumn: "ShareExperienceID");
                    table.ForeignKey(
                        name: "FK_GuestSharedExperiences_SharedExperiences_SharedExperienceShareExperienceID",
                        column: x => x.SharedExperienceShareExperienceID,
                        principalTable: "SharedExperiences",
                        principalColumn: "ShareExperienceID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ExperienceID",
                table: "Discounts",
                column: "ExperienceID");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ProviderID",
                table: "Experiences",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ProviderID_FK",
                table: "Experiences",
                column: "ProviderID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_GuestSharedExperiences_GuestID",
                table: "GuestSharedExperiences",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestSharedExperiences_SharedExperienceShareExperienceID",
                table: "GuestSharedExperiences",
                column: "SharedExperienceShareExperienceID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ExperienceID",
                table: "Reservations",
                column: "ExperienceID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ExperienceID_FK_GroupSize_FK",
                table: "Reservations",
                columns: new[] { "ExperienceID_FK", "GroupSize_FK" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_GuestID",
                table: "Reservations",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_SharedExperiences_ExperienceID",
                table: "SharedExperiences",
                column: "ExperienceID");

            migrationBuilder.CreateIndex(
                name: "IX_SharedExperiences_ExperienceID_FK",
                table: "SharedExperiences",
                column: "ExperienceID_FK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestSharedExperiences");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "SharedExperiences");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
