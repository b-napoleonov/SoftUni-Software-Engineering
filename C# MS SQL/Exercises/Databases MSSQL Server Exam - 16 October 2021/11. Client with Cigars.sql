CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(MAX))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*)
		FROM Clients AS c
		JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
		JOIN Cigars AS ci ON cc.CigarId = ci.Id
	  WHERE c.FirstName = @name)
END

SELECT dbo.udf_ClientWithCigars('Betty')