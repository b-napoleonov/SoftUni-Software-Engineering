CREATE VIEW v_UserWithCountries
AS
SELECT c.FirstName + ' ' + c.LastName AS CustomerName, c.Age, c.Gender, cr.Name
	FROM Customers AS c
	JOIN Countries AS cr ON c.CountryId = cr.Id