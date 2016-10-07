USE SoftUni
GO



SELECT *
INTO EmployeesOver30k
FROM Employees AS e
WHERE e.Salary > 30000

DELETE FROM EmployeesOver30k
WHERE ManagerID = 42

UPDATE EmployeesOver30k
SET Salary = Salary + 5000
WHERE EmployeesOver30k.DepartmentID = 1

SELECT	e30.DepartmentID,
		AVG(e30.Salary) AS AverageSalary
FROM EmployeesOver30k AS e30
GROUP BY e30.DepartmentID
