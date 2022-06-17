SELECT TOP(5) c.Name, COUNT(*) AS ReportsNumber
	FROM Categories AS c
	JOIN Reports AS r ON c.Id = r.CategoryId
GROUP BY c.Name
ORDER BY ReportsNumber DESC, c.Name