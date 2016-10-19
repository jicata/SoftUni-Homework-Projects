SELECT  DepartmentID,
		(SELECT TOP 1 salary
		FROM (SELECT DISTINCT TOP 3  d.salary
			  FROM employees d
			  WHERE d.DepartmentID= e.DepartmentID 
			  ORDER BY d.salary DESC) a
			  ORDER BY a.salary) AS ThirdHighestSalary
FROM Employees e
WHERE e.DepartmentID IN 
(SELECT emp.DepartmentId
FROM Employees emp
GROUP BY emp.DepartmentID
HAVING COUNT(DISTINCT emp.Salary)>=3)
GROUP BY e.DepartmentID