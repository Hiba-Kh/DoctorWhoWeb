using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    public partial class EpisodeCompanionRelationshipUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EpisodeCompanion_CompanionId",
                table: "EpisodeCompanion");

            migrationBuilder.DropIndex(
                name: "IX_EpisodeCompanion_EpisodeId",
                table: "EpisodeCompanion");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeCompanion_EpisodeId",
                table: "EpisodeCompanion",
                column: "EpisodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EpisodeCompanion_EpisodeId",
                table: "EpisodeCompanion");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeCompanion_CompanionId",
                table: "EpisodeCompanion",
                column: "CompanionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeCompanion_EpisodeId",
                table: "EpisodeCompanion",
                column: "EpisodeId",
                unique: true);
        }
    }
}
