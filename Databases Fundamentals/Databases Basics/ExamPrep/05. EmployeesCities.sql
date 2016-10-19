SELECT c.CityName,
	   b.Name,
	   COUNT(e.FirstName) AS EmployeesCount
FROM Cities AS c
	INNER JOIN Branches AS b
		ON c.CityID = b.CityID AND c.CityID !=4 AND c.CityID != 5
	INNER JOIN Employees AS e
		ON e.BranchID = b.BranchID
GROUP BY c.CityName, b.Name
HAVING COUNT(e.FirstName) >= 3