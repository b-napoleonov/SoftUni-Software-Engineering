CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
	OldSum DECIMAL (15, 4),
	NewSum DECIMAL (15, 4)
)

GO

CREATE TRIGGER tr_sumChangeLog
ON Accounts FOR UPDATE
AS
BEGIN
	INSERT INTO Logs (AccountId, OldSum, NewSum)
	VALUES
	(
		(SELECT Id FROM inserted),
		(SELECT Balance FROM deleted),
		(SELECT [Balance] FROM inserted)
	)
END