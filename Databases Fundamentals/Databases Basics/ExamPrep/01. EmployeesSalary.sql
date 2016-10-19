SELECT e.EmployeeID,
	   e.HireDate,
	   e.Salary,
	   e.BranchID
FROM Employees AS e
WHERE e.Salary > 2000
AND e.HireDate > '2009-06-15'