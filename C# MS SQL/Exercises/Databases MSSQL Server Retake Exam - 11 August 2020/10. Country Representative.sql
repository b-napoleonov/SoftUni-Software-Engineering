SELECT 
	k.CountryName, 
	k.DistributorName
	FROM(
		SELECT
		c.Name AS CountryName,
		d.Name AS DistributorName,
		COUNT(i.Id) AS [Counter],
		DENSE_RANK() OVER (PARTITION BY c.[Name] ORDER BY COUNT(i.Id) DESC) AS [Rank]
		FROM Distributors d 
		LEFT JOIN Ingredients i ON i.DistributorId = d.Id 
		JOIN Countries c ON c.Id = d.CountryId
		GROUP BY c.[Name], d.[Name]
		) AS k
	WHERE k.[Rank] = 1
	ORDER BY k.CountryName, k.DistributorName