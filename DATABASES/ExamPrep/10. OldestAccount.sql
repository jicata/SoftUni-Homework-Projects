SELECT TOP 1c.CustomerID,
	   c.FirstName,
	   a.StartDate
FROM Customers AS c
	INNER JOIN Accounts AS a
		ON c.CustomerID = a.CustomerID
ORDER BY a.StartDate 
