SELECT TOP (5) e.EmployeeID
	, e.JobTitle
	, e.AddressID 
	, A.AddressText
	FROM Employees AS e
 JOIN Addresses AS a
 ON E.AddressID = A.AddressID 
ORDER BY e.AddressID