CREATE PROC usp_EmployeesBySalaryLevel (@salaryLevel NVARCHAR(10))
AS
BEGIN
	SELECT e.FirstName,
		   e.LastName,
		   e.Salary
	FROM
	(SELECT e.FirstName,
		   e.LastName,
		   e.Salary,
		   CASE
				WHEN e.Salary < 30000 THEN 'Low'
				WHEN e.Salary BETWEEN 30000 AND 50000 THEN 'Average'
				ELSE 'High'
		   END AS SalaryLevel
	FROM Employees AS e) AS e
	WHERE e.SalaryLevel = @salaryLevel
END


EXEC usp_EmployeesBySalaryLevel 'low'