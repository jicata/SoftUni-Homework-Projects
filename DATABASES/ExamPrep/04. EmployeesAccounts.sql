SELECT TOP 5 e.EmployeeID,
	   e.FirstName,
	   ac.AccountNumber
FROM Employees AS e
	INNER JOIN EmployeesAccounts AS ec
		ON e.EmployeeID = ec.EmployeeID
	INNER JOIN Accounts AS ac
		ON ec.AccountID = ac.AccountID
WHERE ac.StartDate > '2012-01-01'
ORDER BY e.FirstName DESC