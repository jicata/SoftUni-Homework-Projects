SELECT  c.CustomerID,
		CONCAT(c.FirstName, ' ' ,c.LastName) AS FullName,
		tt.TownName
FROM Customers AS c
	INNER JOIN Tickets AS t
		ON c.CustomerID = t.CustomerID
	INNER JOIN Flights AS f
		ON t.FlightID = f.FlightID
		AND f.[Status] = 'Departing'
	INNER JOIN Airports AS a
		ON f.OriginAirportID = a.AirportID
		AND a.TownID = c.HomeTownID
	INNER JOIN Towns AS tt
		ON a.TownID = tt.TownID