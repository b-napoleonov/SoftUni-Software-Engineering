CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @roomId INT = (SELECT TOP 1 r.[Id] 
							FROM Rooms r 
							JOIN [Hotels] h ON h.[Id] = r.[HotelId] 
						WHERE h.[Id] = @hotelId 
						ORDER BY r.[Price] DESC)

	DECLARE @roomPrice DECIMAL(15, 2) = (SELECT [Price] 
											FROM [Rooms] 
										WHERE [Id] = @roomId)
	
	DECLARE @hotelBaseRate DECIMAL(15, 2) = (SELECT [BaseRate] 
											FROM [Hotels] 
										WHERE [Id] = @hotelId)

	DECLARE @totalPrice DECIMAL (15, 2) = (@hotelBaseRate + @roomPrice) * @people

	DECLARE @tripArrivalDate DATE = 
								(SELECT TOP 1 t.[ArrivalDate]	
											FROM [Rooms] r 
											JOIN [Hotels] h ON h.Id = r.[HotelId]
											JOIN [Trips] t ON t.[RoomId] = r.[Id] 
										WHERE h.[Id] = @hotelId AND 
										t.[CancelDate] IS NULL AND 
										t.[RoomId] = @roomId)

	DECLARE @tripReturnDate DATE = 
								(SELECT TOP 1 t.[ReturnDate] 
								FROM [Rooms] r 
								JOIN [Hotels] h ON h.[Id] = r.[HotelId] 
								JOIN [Trips] t ON t.[RoomId] = r.[Id]
								WHERE h.[Id] = @hotelId AND 
								t.[CancelDate] IS NULL AND 
								t.[RoomId] = @roomId)

	DECLARE @result NVARCHAR(MAX) = 'No rooms available'

	IF (@date BETWEEN @tripArrivalDate AND @tripReturnDate)
		RETURN @result

	IF NOT EXISTS 
	(
		SELECT r.[Id] 
		FROM [Hotels] h 
		JOIN [Rooms] r ON r.[HotelId] = h.[Id] 
		WHERE h.[Id] = @hotelId AND @roomId = ANY 
											  (
											    SELECT r.[Id] 
											    FROM [Hotels] h JOIN [Rooms] r ON r.[HotelId] = h.[Id] 
											    WHERE h.[Id] = @hotelId AND r.[Id] = @roomId
											  )
	)
		RETURN @result

	DECLARE @roomBeds INT = (SELECT [Beds] 
								FROM [Rooms] 
							WHERE [Id] = @roomId)

	IF (@people > @roomBeds)
		RETURN @result

	DECLARE @roomType NVARCHAR(100) = (SELECT [Type] 
								FROM [Rooms] 
							WHERE [Id] = @roomId)

	SET @result = 
		'Room ' + CAST(@roomId AS NVARCHAR(50)) + ': ' + CAST(@roomType AS NVARCHAR(50)) + ' (' + CAST(@roomBeds AS NVARCHAR(50)) + ' beds) - $' + CAST(@totalPrice AS NVARCHAR(50))
			RETURN @result
END