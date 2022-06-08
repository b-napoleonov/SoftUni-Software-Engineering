CREATE PROC usp_ChangeJourneyPurpose @journeyId INT, @newPurpose VARCHAR(11)
AS

BEGIN

IF NOT EXISTS (SELECT * FROM Journeys WHERE Id = @journeyId)
	THROW 50001, 'The journey does not exist!', 1

IF ((SELECT Purpose FROM Journeys WHERE Id = @journeyId)) = @newPurpose
	THROW 50002, 'You cannot change the purpose!', 1

UPDATE Journeys
	SET Purpose = @newPurpose
  WHERE Id = @journeyId
END