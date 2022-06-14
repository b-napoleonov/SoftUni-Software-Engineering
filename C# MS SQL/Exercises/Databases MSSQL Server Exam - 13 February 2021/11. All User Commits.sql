CREATE FUNCTION udf_AllUserCommits (@username VARCHAR(30))
RETURNS INT
AS
BEGIN

	DECLARE @id INT = (SELECT Id
							FROM Users
						  WHERE Username = @username) 

	DECLARE @commitsCount INT = (SELECT COUNT(*)
								FROM Commits
							  WHERE ContributorId = @id)
	
	RETURN @commitsCount
END