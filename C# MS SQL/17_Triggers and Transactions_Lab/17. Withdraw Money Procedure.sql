CREATE PROCEDURE usp_WithdrawMoney  @accountId INT, @moneyAmount DECIMAL(15, 4)
AS
BEGIN
	BEGIN TRANSACTION
	
	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)

	IF (@account IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR ('Invalid Id', 16, 1)
		RETURN
	END

	IF (@moneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR ('Please enter valid amount', 16, 2)
		RETURN
	END
	UPDATE Accounts
		SET Balance -= @moneyAmount
		WHERE Id = @accountId
	COMMIT
END