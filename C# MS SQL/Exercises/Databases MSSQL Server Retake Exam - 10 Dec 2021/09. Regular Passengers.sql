SELECT FullName
	, COUNT(*) AS CountOfAircraft
	, SUM(fd.TicketPrice) AS TotalPayed
	FROM Passengers AS p
	JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
	JOIN Aircraft AS a ON fd.AircraftId = a.Id
GROUP BY FullName
HAVING COUNT(*) > 1 AND FullName LIKE '_a%'
ORDER BY FullName 