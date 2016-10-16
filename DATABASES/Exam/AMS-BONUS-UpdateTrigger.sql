CREATE TABLE ArrivedFlights
(
FlightID INT PRIMARY KEY,
ArrivalTime DATETIME NOT NULL,
Origin VARCHAR(50) NOT NULL,
Destination VARCHAR(50) NOT NULL,
Passengers INT NOT NULL
)
GO

CREATE TRIGGER trg_OnFlightArrived
ON Flights
AFTER UPDATE
AS
BEGIN
	DECLARE @FlightStatus AS VARCHAR(50)
	SET @FlightStatus = (SELECT i.[Status] FROM inserted AS i)
	IF(@FlightStatus = 'Arrived')
	BEGIN
		DECLARE @Origin AS VARCHAR(50)
		DECLARE @Destination AS VARCHAR(50)
		SELECT @Origin = a.AirportName,
			   @Destination = aa.AirportName
		FROM Flights AS f
			INNER JOIN Airports AS a
				ON f.OriginAirportID = a.AirportID
			INNER JOIN Airports AS aa
				ON f.DestinationAirportID = aa.AirportID
		INSERT INTO ArrivedFlights(FlightID, ArrivalTime, Origin, Destination, Passengers) 
		SELECT i.FlightID,
			   i.ArrivalTime,
			   @Origin,
			   @Destination,
			   (SELECT Age
				FROM
				(SELECT f.FlightID,
						COUNT(c.CustomerID) AS Age
				FROM Flights AS f
						INNER JOIN Tickets AS t
						ON f.FlightID = t.FlightID
						AND f.FlightID = i.FlightID
						INNER JOIN Customers AS c
						ON c.CustomerID = t.CustomerID
				GROUP BY f.FlightID) AS Passengers)
		FROM inserted AS i
	END
END

