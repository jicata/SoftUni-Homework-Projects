SELECT c.CustomerID,
	   c.FirstName,
	   c.LastName,
	   c.Gender,
	   cc.CityName
FROM Customers AS c
	INNER JOIN Cities AS cc
		ON c.CityID = cc.CityID
WHERE (LEFT(c.LastName, 2) = 'Bu'
OR RIGHT(c.FirstName, 1) = 'a')
AND LEN(cc.CityName) >= 8