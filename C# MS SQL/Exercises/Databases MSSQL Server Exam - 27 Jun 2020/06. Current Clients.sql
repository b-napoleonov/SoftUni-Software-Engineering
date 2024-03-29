SELECT c.FirstName + ' ' + c.LastName
	, DATEDIFF(DAY, j.IssueDate, '04/24/2017') AS [Days going]
	, j.Status
	FROM Clients AS c
	JOIN Jobs AS j ON c.ClientId = j.ClientId
  WHERE j.Status <> 'Finished'
ORDER BY [Days going] DESC, c.ClientId