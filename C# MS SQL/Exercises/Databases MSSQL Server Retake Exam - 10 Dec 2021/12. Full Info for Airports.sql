CREATE PROC usp_SearchByAirportName @airportName VARCHAR(70)
AS
BEGIN
	
	SELECT a.AirportName
		, p.FullName
		, CASE
			WHEN fd.TicketPrice <= 400 THEN 'Low'
			WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
			WHEN fd.TicketPrice >= 1501 THEN 'High'
		  END AS LevelOfTickerPrice
		, ac.Manufacturer
		, ac.Condition
		, aty.TypeName
		FROM Airports AS a
		JOIN FlightDestinations AS fD ON a.Id = fd.AirportId
		JOIN Passengers AS p ON fd.PassengerId = p.Id
		JOIN Aircraft AS ac ON fd.AircraftId = ac.Id
		JOIN AircraftTypes AS aty ON ac.TypeId = aty.Id
	  WHERE AirportName = @airportName
	ORDER BY ac.Manufacturer, p.FullName

END

--EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'