SELECT p.Name, COUNT(*) AS [Journey Count]
	FROM Planets AS p
	JOIN Spaceports AS sp ON sP.PlanetId = p.Id
	JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id
GROUP BY p.Name
ORDER BY [Journey Count] DESC, p.Name