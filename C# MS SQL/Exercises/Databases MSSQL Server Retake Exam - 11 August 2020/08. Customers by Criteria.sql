SELECT c.FirstName, c.Age, c.PhoneNumber
	FROM Customers AS c
	JOIN Countries AS cr ON c.CountryId = cr.Id
  WHERE (Age >= 21 AND FirstName LIKE '%an%') OR (PhoneNumber LIKE '%38' AND cr.Name <> 'Greece')
ORDER BY c.FirstName, c.Age DESC