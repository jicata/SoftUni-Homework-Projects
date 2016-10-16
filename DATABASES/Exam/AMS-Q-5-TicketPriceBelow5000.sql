SELECT t.TickedID,
	   a.AirportName,
	   CONCAT(c.FirstName,' ',c.LastName) AS FullName
FROM Tickets AS t
	INNER JOIN Customers AS c
		ON t.CustomerID = c.CustomerID
	INNER JOIN Flights AS f
		ON f.FlightID = t.FlightID
	INNER JOIN Airports AS a
		ON f.DestinationAirportID = a.AirportID
WHERE t.Price < 5000
AND t.Class = 'First'
ORDER BY t.TickedID