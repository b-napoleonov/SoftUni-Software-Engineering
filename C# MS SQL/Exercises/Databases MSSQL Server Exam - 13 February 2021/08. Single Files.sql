SELECT f1.Id, f1.Name, CONVERT(VARCHAR(50), f1.Size) + 'KB' AS Size
	FROM Files AS f1
	LEFT JOIN Files AS f2 ON f2.ParentId = f1.Id
  WHERE f2.ParentId IS NULL
ORDER BY Id, Name, Size DESC