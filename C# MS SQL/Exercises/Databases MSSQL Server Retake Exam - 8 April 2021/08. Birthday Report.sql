SELECT Username, c.Name
	FROM Reports AS r
	JOIN Users AS u ON u.Id = r.UserId
	JOIN Categories AS c ON c.Id = r.CategoryId
  WHERE
  DATEPART(MONTH, r.OpenDate) = DATEPART(MONTH, u.Birthdate) AND
  DATEPART(DAY, r.OpenDate) = DATEPART(DAY, u.Birthdate)
ORDER BY Username, c.Name