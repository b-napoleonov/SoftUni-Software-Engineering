CREATE PROCEDURE usp_GetHoldersFullName
AS
	SELECT CONCAT(FirstName, ' ', LastName)
		FROM AccountHolders