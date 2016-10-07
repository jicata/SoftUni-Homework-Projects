USE SoftUni
GO

SELECT e.DepartmentID,
	   Min(e.Salary) AS MinimumSalary
FROM Employees AS e
WHERE (e.DepartmentID = 2 OR e.DepartmentID = 5 OR e.DepartmentID = 7) AND CAST(e.HireDate AS date) > CAST('2000-01-01' as date)
GROUP BY e.DepartmentID