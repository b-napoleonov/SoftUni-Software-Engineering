CREATE PROC usp_AssignProject @emloyeeId INT, @projectID INT
AS
BEGIN TRANSACTION
	DECLARE @employee INT = (SELECT EmployeeID FROM Employees WHERE EmployeeID = @emloyeeId)
	DECLARE @project INT = (SELECT ProjectID FROM Projects WHERE ProjectID = @projectID)

	IF (@employee IS NULL OR @project IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR ('Invalid employeeId or projectId!', 16, 1)
		RETURN
	END

	DECLARE @employeeProjectCount INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId)

	IF (@employeeProjectCount >= 3)
	BEGIN
		ROLLBACK
		RAISERROR ('The employee has too many projects!', 16, 2)
		RETURN
	END

	INSERT INTO EmployeesProjects (EmployeeID, ProjectID) VALUES
	(@emloyeeId, @projectID)
COMMIT