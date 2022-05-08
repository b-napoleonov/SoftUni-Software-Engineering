CREATE TABLE People
(
	Id BIGINT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	Gender NCHAR(1) NOT NULL,
	Birthdate DATETIME NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People VALUES
('Gosho', NULL, 1.90, 80, 'm', '03.03.1998', NULL),
('Pesho', NULL, 1.85, 90, 'm', '03.05.1997', NULL),
('Misho', NULL, 2.00, 100, 'm', '07.09.1995', NULL),
('Ivan', NULL, 1.93, 90, 'm', '12.12.1999', NULL),
('Ceco', NULL, 1.78, 75, 'm', '01.02.1997', NULL)