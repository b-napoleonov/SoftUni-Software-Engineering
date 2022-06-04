CREATE PROCEDURE usp_GetTownsStartingWith @parameter VARCHAR(10)
AS
	SELECT [Name]
		FROM Towns
	 WHERE [Name] LIKE @parameter + '%'