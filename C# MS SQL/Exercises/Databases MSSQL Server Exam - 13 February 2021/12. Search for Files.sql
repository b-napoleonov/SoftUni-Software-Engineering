CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(50))
AS
BEGIN
	SELECT Id, Name, CONVERT(VARCHAR(50), Size) + 'KB' AS Size
		FROM Files
	  WHERE Name LIKE '%' + @fileExtension
	ORDER BY Id, Name, Size DESC
END

--EXEC usp_SearchForFiles 'txt'