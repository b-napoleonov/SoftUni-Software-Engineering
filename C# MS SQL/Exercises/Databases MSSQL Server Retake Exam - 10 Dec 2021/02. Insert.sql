INSERT INTO Passengers (FullName, Email)
SELECT FirstName + ' ' + LastName
	, CONCAT(FirstName, LastName, '@gmail.com')
	FROM Pilots
  WHERE Id BETWEEN 5 AND 15