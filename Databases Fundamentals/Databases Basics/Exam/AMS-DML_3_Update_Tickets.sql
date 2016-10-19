
UPDATE Tickets
SET Price = Price + Price * 0.5
WHERE FlightID IN (SELECT f.FlightID
					FROM Flights AS f
					WHERE f.AirlineID = (SELECT TOP 1 a.AirlineID
												FROM Airlines AS a
												ORDER BY a.Rating DESC))



