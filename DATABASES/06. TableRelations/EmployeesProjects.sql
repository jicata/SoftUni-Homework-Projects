SELECT TOP 3 e.EmployeeID,
			 e.FirstName
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
      ON e.EmployeeID != ep.ProjectID 