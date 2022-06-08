SELECT c.Id
	, c.FirstName + ' ' + c.LastName
	FROM Colonists AS c
	JOIN TravelCards AS tc ON c.Id = tc.ColonistId
 WHERE JobDuringJourney = 'Pilot'
ORDER BY c.Id