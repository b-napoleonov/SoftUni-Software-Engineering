SELECT FirstName + ' ' + LastName AS FullName
	, COUNT(DISTINCT UserId) AS UsersCount
	FROM Reports r
	RIGHT JOIN Employees e ON e.Id = r.EmployeeId
GROUP BY EmployeeId, FirstName, LastName
ORDER BY UsersCount DESC, FullName