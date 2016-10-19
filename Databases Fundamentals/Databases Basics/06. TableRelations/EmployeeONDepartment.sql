SELECT TOP 5 e.EmployeeID,
			 e.FirstName,
			 e.Salary,
		     d.Name
FROM Employees AS e
LEFT JOIN Departments AS d
         ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID
