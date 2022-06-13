SELECT d.Name, i.Name, p.Name, AVG(f.Rate)
	FROM Distributors AS d
	JOIN Ingredients AS i ON d.Id = i.DistributorId
	JOIN ProductsIngredients AS pri ON pri.IngredientId = i.Id
	JOIN Products AS p ON pri.ProductId = p.Id
	JOIN Feedbacks AS f ON p.Id = f.ProductId
GROUP BY d.Name, i.Name, p.Name
HAVING AVG(f.Rate) BETWEEN 5 AND 8
ORDER BY d.Name, i.Name, p.Name