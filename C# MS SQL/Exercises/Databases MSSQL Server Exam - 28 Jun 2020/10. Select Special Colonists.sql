SELECT *
	FROM (SELECT tc.JobDuringJourney, 
		c.FirstName + ' ' + c.LastName AS FullName, 
	DENSE_RANK() OVER(PARTITION BY JobDuringJourney ORDER BY c.BirthDate) AS JobRank
	FROM Colonists AS c
	JOIN TravelCards AS tc ON tc.ColonistId = c.Id) AS k
 WHERE k.JobRank = 2