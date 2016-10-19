USE SoftUni
GO

SELECT DISTINCT DepartmentID,
				Salary
FROM
(SELECT e.DepartmentID, 
	    e.Salary,
	    DENSE_RANK() OVER (PARTITION BY e.DepartmentId ORDER BY e.Salary DESC) AS DenseRank
FROM Employees AS e) AS Densed
WHERE DenseRank = 3


