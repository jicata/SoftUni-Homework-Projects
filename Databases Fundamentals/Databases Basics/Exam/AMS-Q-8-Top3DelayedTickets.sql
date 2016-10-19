SELECT TOP 3 c.CustomerID,
       c.FirstName + ' ' + c.LastName AS FullName,
	   t.Price AS TicketPrice,
	   a.AirportName AS Destination
FROM Customers AS c
	INNER JOIN Tickets AS t
		ON c.CustomerID = t.CustomerID
	INNER JOIN Flights AS f
		ON t.FlightID = f.FlightID
	INNER JOIN Airports AS a
		ON f.DestinationAirportID = a.AirportID
WHERE F.[Status] = 'Delayed'
ORDER BY t.Price DESC, c.CustomerID
