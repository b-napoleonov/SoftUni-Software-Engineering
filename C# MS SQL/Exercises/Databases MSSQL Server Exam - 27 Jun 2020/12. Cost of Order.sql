CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(15, 2)
AS
BEGIN
	DECLARE @result DECIMAL(15, 2) = 0

	DECLARE @jobOrdersCount INT = (SELECT COUNT ([OrderId]) 
									FROM [Jobs] AS j
									LEFT JOIN [Orders] AS o ON j.[JobId] = o.[JobId]
								  WHERE j.[JobId] = @jobId)
		IF @jobOrdersCount = 0
		BEGIN
			 RETURN 0
		END
		SET @result = (SELECT SUM(p.[Price] * op.[Quantity]) 
						FROM [Jobs] AS j
						LEFT JOIN [Orders] AS o ON j.[JobId] = o.[JobId]
						LEFT JOIN [OrderParts] AS op ON o.[OrderId] = op.[OrderId]
						LEFT JOIN [Parts] AS p ON op.[PartId] = p.[PartId]
					  WHERE j.[JobId] = @jobId)

	RETURN @result
END