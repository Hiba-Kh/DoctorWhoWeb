using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    public partial class EpisodeEnemyRelationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EpisodeEnemy_EnemyId",
                table: "EpisodeEnemy");

            migrationBuilder.DropIndex(
                name: "IX_EpisodeEnemy_EpisodeId",
                table: "EpisodeEnemy");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeEnemy_EnemyId",
                table: "EpisodeEnemy",
                column: "EnemyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EpisodeEnemy_EnemyId",
                table: "EpisodeEnemy");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeEnemy_EnemyId",
                table: "EpisodeEnemy",
                column: "EnemyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeEnemy_EpisodeId",
                table: "EpisodeEnemy",
                column: "EpisodeId",
                unique: true);
        }
    }
}
