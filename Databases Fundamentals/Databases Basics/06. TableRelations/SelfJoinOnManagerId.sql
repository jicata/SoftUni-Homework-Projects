

SELECT e.EmployeeID,
	   e.FirstName,
	   e.ManagerID,
	   m.FirstName AS ManagerName 
FROM Employees AS e
	INNER JOIN Employees AS m
		ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID = 3 OR e.ManagerID = 7
ORDER BY e.EmployeeID