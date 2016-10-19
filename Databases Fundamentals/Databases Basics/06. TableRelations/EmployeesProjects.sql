SELECT TOP 5  e.EmployeeID,
			 e.FirstName,
		     p.Name
FROM Employees AS e
      INNER JOIN EmployeesProjects AS ep
		ON e.EmployeeID = ep.EmployeeId
	  INNER JOIN Projects AS p
		ON ep.ProjectID = p.ProjectID 
		AND p.StartDate > CONVERT(DATETIME, '2002-08-13')
		AND p.EndDate IS NULL
ORDER BY e.EmployeeID 