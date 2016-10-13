SELECT TOP 3 e.FirstName,
			 c.CityName
FROM Employees AS e
	INNER JOIN Branches AS b
		ON e.BranchID = b.BranchID
	INNER JOIN Cities AS c
		ON b.CityID = c.CityID
UNION ALL
SELECT TOP 3 c.FirstName,
			 cc.CityName
FROM Customers AS c
	INNER JOIN Cities AS cc
		ON c.CityID = cc.CityID