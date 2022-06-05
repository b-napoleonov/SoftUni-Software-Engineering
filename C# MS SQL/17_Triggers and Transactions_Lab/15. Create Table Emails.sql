CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT NOT NULL,
	[Subject] VARCHAR(50) NOT NULL,
	Body VARCHAR(MAX) NOT NULL
)

GO

CREATE TRIGGER tr_OnAddLog
ON Logs FOR INSERT
AS
BEGIN
	INSERT INTO NotificationEmails (Recipient, [Subject], Body)
	VALUES
	(
		(SELECT AccountId FROM inserted),
		(CONCAT_WS(' ','Balance change for account:', 
			(SELECT AccountId 
				FROM inserted))),
		(CONCAT_WS(' ', 'On', GETDATE(), 'your balance was changed from', 
			(SELECT OldSum FROM inserted), 'to', 
				(SELECT [NewSum] FROM inserted)))
	)
END