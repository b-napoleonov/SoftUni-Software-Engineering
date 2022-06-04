CREATE PROCEDURE usp_EmployeesBySalaryLevel @parameter VARCHAR(7)
AS
	SELECT FirstName, LastName
		FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @parameter