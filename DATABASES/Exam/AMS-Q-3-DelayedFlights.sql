SELECT f.FlightID,
	   f.DepartureTime,
	   f.ArrivalTime
FROM Flights AS f
WHERE f.[Status] = 'Delayed'
ORDER BY f.FlightID