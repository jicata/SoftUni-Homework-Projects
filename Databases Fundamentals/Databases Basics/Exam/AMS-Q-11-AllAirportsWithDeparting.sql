SELECT a.AirportID,
	   a.AirportName,
	   COUNT(*) AS Passangers
FROM Airports AS a
	INNER JOIN Flights AS f
		ON f.DestinationAirportID = a.AirportID
	INNER JOIN Tickets AS t
		ON f.FlightID = t.FlightID
	INNER JOIN Customers AS c
		ON t.CustomerID = c.CustomerID
WHERE f.[Status] = 'Departing'
GROUP BY a.AirportID, a.AirportName
HAVING COUNT(*) > 0
ORDER BY a.AirportID 