SELECT c.FirstName + ' ' + c.LastName, c.PhoneNumber, c.Gender
	FROM Feedbacks AS f
	RIGHT JOIN Customers AS c ON f.CustomerId = c.Id
  WHERE f.Id IS NULL
ORDER BY c.Id