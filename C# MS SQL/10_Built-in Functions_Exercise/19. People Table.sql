CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	BirthDate DATETIME NOT NULL
)

INSERT INTO People VALUES
	('Pesho', '1998-07-11 00:00:00.000'),
	('Gosho', '1995-04-23 00:00:00.000'),
	('Misho', '1957-10-10 00:00:00.000'),
	('Ceco', '2003-12-12 00:00:00.000')

SELECT [Name]
	, DATEDIFF(YEAR, BirthDate, GETDATE()) AS [Age in Years]
	, DATEDIFF(MONTH, BirthDate, GETDATE()) AS [Age in Months]
	, DATEDIFF(DAY, BirthDate, GETDATE()) AS [Age in Days]
	, DATEDIFF(MINUTE, BirthDate, GETDATE()) AS [Age in Minutes]
	FROM People