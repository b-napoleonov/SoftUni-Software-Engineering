SELECT t.Id
	, a.FirstName + ' ' + ISNULL(a.MiddleName + ' ', '') + a.LastName AS [Full Name]
	, c.[Name] AS [From]
	, c2.[Name] AS [To]
	, IIF(t.CancelDate IS NULL, CAST(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS VARCHAR(MAX)) + ' days', 'Canceled') AS Duration
	FROM AccountsTrips at
	JOIN Accounts a ON a.Id = at.AccountId
	JOIN Cities c ON c.Id = a.CityId
	JOIN Trips t ON t.Id = at.TripId
	JOIN Rooms r ON r.Id = t.RoomId
	JOIN Hotels h ON h.Id = r.HotelId
	JOIN Cities c2 ON c2.Id = h.CityId
ORDER BY [Full Name], t.Id