CREATE PROC usp_PlaceOrder @jobId INT, @partSerialNumber VARCHAR(50), @quantity INT
AS
BEGIN
	IF(@quantity <= 0)
		THROW 50012, 'Part quantity must be more than zero!', 1
	ELSE IF NOT EXISTS(SELECT JobId FROM Jobs WHERE JobId = @jobId)
		THROW 50013, 'Job not found!', 1
	ELSE IF EXISTS(SELECT Status FROM Jobs WHERE JobId = @jobId AND Status = 'Finished')
		THROW 50011, 'This job is not active!', 1
	ELSE IF NOT EXISTS(SELECT PartId FROM Parts WHERE SerialNumber = @partSerialNumber)
		THROW 50014, 'Part not found!', 1

	DECLARE @jobStatus VARCHAR(50) = (SELECT [Status] FROM Jobs WHERE JobId = @jobId)
	DECLARE @isJobIdExist INT = (SELECT JobId FROM Jobs WHERE JobId = @jobId)
	DECLARE @partId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @partSerialNumber)
	DECLARE @orderId INT = (SELECT OrderId FROM Orders WHERE JobId = @jobId AND IssueDate IS NULL)

	IF (@orderId IS NULL)
	BEGIN
		INSERT INTO Orders(JobId, IssueDate, Delivered) VALUES (@jobId, NULL, 0)
	END

	SET @orderId = (SELECT OrderId FROM Orders WHERE JobId = @jobId AND IssueDate IS NULL)
	
	DECLARE @orderPartQty INT = (SELECT Quantity FROM OrderParts WHERE OrderId = @orderId AND PartId = @partId)
	IF (@orderPartQty IS NULL)
	BEGIN
		INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES (@orderId, @partId, @quantity)
	END
	ELSE
	BEGIN
		UPDATE 
			OrderParts 
			SET Quantity += @quantity 
			WHERE OrderId = @orderId AND PartId = @partId
	END
END