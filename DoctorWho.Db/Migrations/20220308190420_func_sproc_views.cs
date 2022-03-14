using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    public partial class func_sproc_views : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION dbo.fnEnemies(@EpisodeID AS INT)
                                RETURNS TABLE AS 
	                            RETURN SELECT DISTINCT EN.EnemyName FROM Enemies EN
				                JOIN EpisodeEnemy EE
				                ON EN.EnemyId = EE.EnemyID
				                JOIN Episodes E
     			                ON EE.EpisodeID = E.EpisodeId
				                WHERE E.EpisodeId = @EpisodeID
                                ");
            migrationBuilder.Sql(@"CREATE FUNCTION dbo.fnCompanion (@EpisodeID AS INT)
                                  RETURNS TABLE AS
	                              RETURN 
		                          SELECT C.CompanionName FROM Companions C
			                      JOIN EpisodeCompanion EC 
			                      ON C.CompanionId = EC.CompanionID
			                      JOIN Episodes E
     		                      ON EC.EpisodeID = E.EpisodeId
			                      WHERE E.EpisodeId = @EpisodeID
                                 ");
            migrationBuilder.Sql(@"CREATE FUNCTION dbo.fnEnemiesConcatenated (@EpisodeID AS INT)
                                   RETURNS VARCHAR(MAX) AS
                                   BEGIN
                                   DECLARE @Companions AS VARCHAR(MAX)
                                   Select @Companions = SUBSTRING( 
                                   ( 
                                       select ',' + EnemyName AS 'data()'  from dbo.fnEnemies(@EpisodeID) FOR XML PATH('')
                                   ), 2 , 9999) 
                                   RETURN @Companions	 
                                   END
                                   ");
            migrationBuilder.Sql(@"CREATE FUNCTION dbo.fnCompanionConcatenated (@EpisodeID AS INT)
                                   RETURNS VARCHAR(MAX) AS
                                   BEGIN
                                   DECLARE @Companions AS VARCHAR(MAX)
                                   Select @Companions = SUBSTRING( 
                                   ( 
                                       select ',' + CompanionName AS 'data()'  from dbo.fnCompanion(@EpisodeID) FOR XML PATH('')
                                   ), 2 , 9999) 
                                   RETURN @Companions	 
                                   END
                                   ");
            migrationBuilder.Sql(@"CREATE PROCEDURE spSummariseEpisodes
                                AS BEGIN
                                SELECT TOP(3) COUNT(CompanionID) AS [Companion Count], CompanionID FROM EpisodeCompanion 
                                GROUP BY CompanionID 
                                ORDER BY [Companion Count] DESC;

                                SELECT TOP(3) COUNT(EnemyID) AS [Enemies Count], EnemyID FROM EpisodeEnemy
                                GROUP BY EnemyID 
                                ORDER BY [Enemies Count] DESC;
                                END;
                                  ");
            migrationBuilder.Sql(@"CREATE VIEW viewEpisodes AS
                                SELECT  E.EpisodeId, E.Title AS [Episode Title], A.AuthorName AS [Author Name], D.DoctorName AS [Doctor Name], 
		                        dbo.fnCompanionConcatenated(E.EpisodeId) AS Companions,
		                        dbo.fnEnemiesConcatenated(E.EpisodeId) AS Enemies
		                        FROM  
		                        Episodes E JOIN Doctors D
		                        ON E.DoctorID = D.DoctorID
		                        JOIN Authors A
		                        ON E.AuthorID = A.AuthorID;
                                  ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.spSummariseEpisodes");
            migrationBuilder.Sql("DROP VIEW dbo.viewEpisodes");
            migrationBuilder.Sql("DROP FUNCTION dbo.fnCompanionConcatenated");
            migrationBuilder.Sql("DROP FUNCTION dbo.fnEnemiesConcatenated");
            migrationBuilder.Sql("DROP FUNCTION dbo.fnCompanion");
            migrationBuilder.Sql("DROP FUNCTION dbo.fnEnemies");
        }
    }
}
