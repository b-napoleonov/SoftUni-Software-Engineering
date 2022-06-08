CREATE FUNCTION dbo.udf_GetColonistsCount(@planetName VARCHAR (30))
RETURNS INT
AS
BEGIN
DECLARE @count INT
SET @count = (SELECT COUNT(*) 
	FROM Planets AS p
	JOIN Spaceports AS sp ON p.Id = sp.PlanetId
	JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id
	JOIN TravelCards AS tc ON tc.JourneyId = j.Id
	JOIN Colonists AS c ON c.Id = tc.ColonistId
 WHERE p.Name = @planetName)
 RETURN @count
 END