SELECT SUM(l.Amount) AS TotalLoanAmount,
	   MAX(l.Interest) AS MaxInterest,
	   MIN(e.Salary) AS MinEmployeeSalary
FROM Employees AS e
	INNER JOIN EmployeesLoans AS el
		ON e.EmployeeID = el.EmployeeID
	INNER JOIN Loans AS l
		ON el.LoanID = l.LoanID