SELECT TOP 5 a.AirlineID,
	   a.AirlineName,
	   a.Nationality,
	   a.Rating
FROM Airlines AS a
WHERE a.AirlineID IN (SELECT DISTINCT a.AirlineID
								FROM Airlines AS a
									INNER JOIN Flights AS f
										ON a.AirlineID = f.AirlineID)
ORDER BY a.Rating DESC, a.AirlineID

