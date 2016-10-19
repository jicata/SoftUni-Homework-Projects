SELECT  DISTINCT c.CustomerID,
		f.FlightID,
		c.FirstName + ' ' + c.LastName AS FullName,
		2016 - DATEPART(year, c.DateOfBirth) AS Age
FROM Customers AS c
	INNER JOIN Tickets AS t
		ON c.CustomerID = t.CustomerID
	INNER JOIN Flights AS f
		ON t.FlightID = f.FlightID
WHERE f.[Status] = 'Departing'
ORDER BY Age, CustomerID

