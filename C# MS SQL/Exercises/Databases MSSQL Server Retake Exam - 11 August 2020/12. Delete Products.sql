CREATE TRIGGER tr_productDeletion
ON Products
INSTEAD OF DELETE
AS
BEGIN
	DECLARE @productId INT = (SELECT Id FROM deleted)

	DELETE
		FROM ProductsIngredients
	  WHERE ProductId = @productId

	DELETE
		FROM Feedbacks
	  WHERE ProductId = @productId

	 DELETE
		FROM Products
	  WHERE Id = @productId
END