using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    public partial class SeedingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"INSERT INTO Authors
                                 (AuthorName)
                                 VALUES
                                 ('Ben Aaronovitch'), ('Douglas Adams'), ('David Agnew'), ('Bob Baker'), ('Kevin Clarke ');
                                ");

			migrationBuilder.Sql(@"INSERT INTO Enemies
			                    (EnemyName, [Description])
			                    VALUES
			                    ('The Master', 'An old friend, and an old foe, The Master has faced the Doctor throughout several lifecycles'), 
			                    ('The Daleks', 'The Daleks are a perennial threat to our dual-hearted hero, and are the only villain so far to have faced every version of the Doctor'),
			                    ('The Cybermen', 'First introduced way back in 1966, they were a part of the First Doctor William Hartnells final serial'),
			                    ('The Weeping Angels', 'One of the most frightening Doctor Who villains on this list, at least for younger viewers, are the Weeping Angels'),
			                    ('Sontarans', 'This race of warrior potatoes are a threat much bigger than their stature suggests. Round, brown, and great with butter, the Sontarans aren’t to be messed with');
                                ");
			migrationBuilder.Sql(@"INSERT INTO Doctors
                               (DoctorNumber, DoctorName, BirthDate, FirstEpisodeDate, LastEpisodeDate)
                               VALUES
                               (565, 'Jo Martin','Jan 1, 1953', 'Sep 9, 1973', 'Nov 1, 1973' ),
		                       (176, 'John Hurt', 'Mar 3, 1950', 'Apr 15, 1980', 'June 1, 1980'),
		                       (789, 'David Tennant', 'May 20, 1945', 'Jul 15, 1992', 'Oct 1, 1992'), 
		                       (538, 'Tom Baker', 'May 3, 1960', 'Nov 11, 1995', 'Dec 1, 1995'),
		                       (743, ' William Hartnell', 'Aug 3, 1970', 'Sep 15, 1998', 'Dec 31, 1998');
                               ");
			migrationBuilder.Sql(@"INSERT INTO Episodes
                                 (SeriesNumber, EpisodeNumber, EpisodeType, Title, EpisodeDate, AuthorId, DoctorId)
                                 VALUES
	                             (13, 1, 'historical', 'The End of the World', 'Sep 9, 1973', 1, 1 ),
	                             (164, 5, 'musical', 'The Doctor Dances', 'Apr 25, 1980', 4, 2 ),
	                             (160, 4, 'Capaldi', 'Aliens of London', 'Oct 9, 1992', 1, 3),
	                             (50, 10, 'domestic', 'The Unquiet Dead', 'Nov 30, 1995', 5, 4),
	                             (120, 20, 'historical', 'World War Three', 'Oct 3, 1998',2, 5 );
                                 ");

			migrationBuilder.Sql(@"INSERT INTO Companions
			                    (CompanionName, WhoPlayed)
			                    VALUES
			                    ('Martha Jones', 'Freema Agyeman'),
			                    ('Captain Jack Harkness', 'John Barrowman'),
			                    ('Astrid Peth', 'Kylie Minogue'),
			                    ('Sarah Jane Smith', 'lisabeth Sladen'),
			                    ('Jackson Lake', 'David Morrissey');
                                ");
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
