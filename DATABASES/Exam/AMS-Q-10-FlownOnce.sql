SELECT c.CustomerID,
	   c.FirstName + ' ' + c.LastName AS FullName,
	   2016 - DATEPART(year, c.DateOfBirth) AS Age
FROM Customers AS c
	INNER JOIN Tickets AS t
		ON c.CustomerID = t.CustomerID
	INNER JOIN Flights AS f
		ON t.FlightID = f.FlightID
WHERE  2016 - DATEPART(year, c.DateOfBirth) < 21
AND f.[Status] = 'Arrived'
ORDER BY Age DESC, c.CustomerID 