SELECT TOP 5 f.FlightID,
	   f.DepartureTime,
	   f.ArrivalTime,
	   ao.AirportName AS Origin,
	   ad.AirportName AS Destination
FROM Flights AS f
	INNER JOIN Airports AS ao
		ON f.OriginAirportID = ao.AirportID
	INNER JOIN Airports AS ad
		ON f.DestinationAirportID = ad.AirportID
WHERE f.[Status] = 'Departing'
ORDER BY f.DepartureTime, FlightID