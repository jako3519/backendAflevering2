using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Experiences_ExperienceID",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Experiences_ExperienceID_FK",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestSharedExperiences_SharedExperiences_ShareExperienceID",
                table: "GuestSharedExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestSharedExperiences_SharedExperiences_SharedExperienceShareExperienceID",
                table: "GuestSharedExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Experiences_ExperienceID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Experiences_ExperienceID_FK",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_SharedExperiences_Experiences_ExperienceID",
                table: "SharedExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_SharedExperiences_Experiences_ExperienceID_FK",
                table: "SharedExperiences");

            migrationBuilder.DropIndex(
                name: "IX_SharedExperiences_ExperienceID",
                table: "SharedExperiences");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ExperienceID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_GuestSharedExperiences_SharedExperienceShareExperienceID",
                table: "GuestSharedExperiences");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_ExperienceID",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "ExperienceID",
                table: "SharedExperiences");

            migrationBuilder.DropColumn(
                name: "ExperienceID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "SharedExperienceShareExperienceID",
                table: "GuestSharedExperiences");

            migrationBuilder.DropColumn(
                name: "ExperienceID",
                table: "Discounts");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Experiences_ExperienceID_FK",
                table: "Discounts",
                column: "ExperienceID_FK",
                principalTable: "Experiences",
                principalColumn: "ExperienceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestSharedExperiences_SharedExperiences_ShareExperienceID",
                table: "GuestSharedExperiences",
                column: "ShareExperienceID",
                principalTable: "SharedExperiences",
                principalColumn: "ShareExperienceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Experiences_ExperienceID_FK",
                table: "Reservations",
                column: "ExperienceID_FK",
                principalTable: "Experiences",
                principalColumn: "ExperienceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SharedExperiences_Experiences_ExperienceID_FK",
                table: "SharedExperiences",
                column: "ExperienceID_FK",
                principalTable: "Experiences",
                principalColumn: "ExperienceID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Experiences_ExperienceID_FK",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestSharedExperiences_SharedExperiences_ShareExperienceID",
                table: "GuestSharedExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Experiences_ExperienceID_FK",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_SharedExperiences_Experiences_ExperienceID_FK",
                table: "SharedExperiences");

            migrationBuilder.AddColumn<int>(
                name: "ExperienceID",
                table: "SharedExperiences",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceID",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SharedExperienceShareExperienceID",
                table: "GuestSharedExperiences",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceID",
                table: "Discounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SharedExperiences_ExperienceID",
                table: "SharedExperiences",
                column: "ExperienceID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ExperienceID",
                table: "Reservations",
                column: "ExperienceID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestSharedExperiences_SharedExperienceShareExperienceID",
                table: "GuestSharedExperiences",
                column: "SharedExperienceShareExperienceID");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ExperienceID",
                table: "Discounts",
                column: "ExperienceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Experiences_ExperienceID",
                table: "Discounts",
                column: "ExperienceID",
                principalTable: "Experiences",
                principalColumn: "ExperienceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Experiences_ExperienceID_FK",
                table: "Discounts",
                column: "ExperienceID_FK",
                principalTable: "Experiences",
                principalColumn: "ExperienceID");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestSharedExperiences_SharedExperiences_ShareExperienceID",
                table: "GuestSharedExperiences",
                column: "ShareExperienceID",
                principalTable: "SharedExperiences",
                principalColumn: "ShareExperienceID");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestSharedExperiences_SharedExperiences_SharedExperienceShareExperienceID",
                table: "GuestSharedExperiences",
                column: "SharedExperienceShareExperienceID",
                principalTable: "SharedExperiences",
                principalColumn: "ShareExperienceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Experiences_ExperienceID",
                table: "Reservations",
                column: "ExperienceID",
                principalTable: "Experiences",
                principalColumn: "ExperienceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Experiences_ExperienceID_FK",
                table: "Reservations",
                column: "ExperienceID_FK",
                principalTable: "Experiences",
                principalColumn: "ExperienceID");

            migrationBuilder.AddForeignKey(
                name: "FK_SharedExperiences_Experiences_ExperienceID",
                table: "SharedExperiences",
                column: "ExperienceID",
                principalTable: "Experiences",
                principalColumn: "ExperienceID");

            migrationBuilder.AddForeignKey(
                name: "FK_SharedExperiences_Experiences_ExperienceID_FK",
                table: "SharedExperiences",
                column: "ExperienceID_FK",
                principalTable: "Experiences",
                principalColumn: "ExperienceID");
        }
    }
}
