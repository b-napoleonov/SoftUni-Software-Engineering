CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan @balance MONEY
AS
	SELECT ah.FirstName, ah.LastName
		FROM AccountHolders AS ah
		JOIN Accounts AS a ON ah.Id = a.AccountHolderId
		 GROUP BY a.AccountHolderId, ah.FirstName, ah.LastName
		  HAVING SUM(Balance) > @balance
		  ORDER BY ah.FirstName, ah.LastName