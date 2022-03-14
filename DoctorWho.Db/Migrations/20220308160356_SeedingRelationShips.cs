using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    public partial class SeedingRelationShips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"INSERT INTO EpisodeCompanion
								(EpisodeId, CompanionId)
								Values
								(3,1),
								(4,5),
								(2,2),
								(1,3),
								(5,4);
								");

			migrationBuilder.Sql(@"INSERT INTO EpisodeEnemy
                                (EpisodeId, EnemyId)
                                 VALUES
	                             (3, 2),
	                             (1, 4),
	                             (4, 3),
	                             (5, 5),
	                             (2, 1);
                                 ");
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
