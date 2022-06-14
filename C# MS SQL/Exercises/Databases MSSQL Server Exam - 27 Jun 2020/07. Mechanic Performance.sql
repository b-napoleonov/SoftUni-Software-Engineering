SELECT m.FirstName + ' ' + m.LastName
	, AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate))
	FROM Mechanics AS m
	JOIN Jobs AS j ON m.MechanicId = j.MechanicId
GROUP BY m.FirstName + ' ' + m.LastName, m.MechanicId
ORDER BY m.MechanicId