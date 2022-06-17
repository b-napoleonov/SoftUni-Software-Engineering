CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @passengerId INT = 
		(SELECT Id 
			FROM Passengers 
		  WHERE Email = @email)

	RETURN (SELECT COUNT(*)
		FROM FlightDestinations
	  WHERE PassengerId = @passengerId)
END