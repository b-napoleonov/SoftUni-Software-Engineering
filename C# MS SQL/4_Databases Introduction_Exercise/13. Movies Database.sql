CREATE DATABASE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName VARCHAR(50) NOT NULL,
	NOTES VARCHAR(MAX)
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(50) NOT NULL,
	NOTES VARCHAR(MAX)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	NOTES VARCHAR(MAX)
)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear INT NOT NULL,
	Lenght INT,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating DECIMAL(5,2),
	NOTES VARCHAR(MAX)
)

INSERT INTO Directors VALUES
('Pesho', NULL),
('Gosho', NULL),
('Misho', NULL),
('Ceco', NULL),
('Ivan', NULL)

INSERT INTO Genres VALUES
('Drama', NULL),
('Comedy', NULL),
('Action', NULL),
('Horror', NULL),
('Sci Fi', NULL)

INSERT INTO Categories VALUES
('TV Series', NULL),
('Films', NULL),
('Animation', NULL),
('Documentary', NULL),
('Biography', NULL)

INSERT INTO Movies VALUES
('IT', 1, 2019, NULL, 4, 2, NULL, NULL),
('After', 2, 2019, NULL, 1, 2, 10, 'Best movie all times'),
('After 2', 3, 2020, NULL, 1, 2, 10, 'Another good SQL :D'),
('After 3', 4, 2021, NULL, 1, 2, 10, 'Keeping up the good work'),
('A star is born', 5, 2018, NULL, 1, 2, 10, 'One of the best dramas out there')