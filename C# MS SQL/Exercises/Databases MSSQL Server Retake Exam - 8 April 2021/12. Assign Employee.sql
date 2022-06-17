CREATE PROC usp_AssignEmployeeToReport @EmployeeId INT, @ReportId INT
AS
BEGIN
	
	DECLARE @employeeDepartment INT = (SELECT DepartmentId FROM Employees
									WHERE @EmployeeId = Id)

	DECLARE @reportCategoryDepartment INT = (SELECT d.Id 
												FROM Reports AS r
												JOIN Categories AS c ON r.CategoryId = c.Id
												JOIN Departments AS d ON c.DepartmentId = d.Id
											  WHERE r.Id = @ReportId)

	IF(@employeeDepartment <> @reportCategoryDepartment)
		THROW 50001, 'Employee doesn''t belong to the appropriate department!',1

	UPDATE Reports
		SET EmployeeId = @EmployeeId
	  WHERE Id = @ReportId
END