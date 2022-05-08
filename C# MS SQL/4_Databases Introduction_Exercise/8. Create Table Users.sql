CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT NOT NULL
)

INSERT INTO Users VALUES
('peshko', '12333', NULL, GETDATE(), 0),
('goshko', '00000', NULL, GETDATE(), 1),
('mishko', '12345', NULL, GETDATE(), 1),
('pencho', '12222', NULL, GETDATE(), 0),
('manko', '12300', NULL, GETDATE(), 1)