CREATE TABLE Flights
(
FlightID INT PRIMARY KEY,
DepartureTime DATETIME NOT NULL,
ArrivalTime DATETIME NOT NULL,
[Status] VARCHAR(9) NOT NULL CHECK ([Status] IN ('Departing', 'Delayed', 'Arrived', 'Cancelled')),
OriginAirportID INT CONSTRAINT FK_Flights_AirportsOrigin FOREIGN KEY REFERENCES Airports(AirportID),
DestinationAirportID INT CONSTRAINT FK_Flights_AirportsDestination FOREIGN KEY REFERENCES Airports(AirportID),
AirlineID INT CONSTRAINT FK_Flights_AirportsAirline FOREIGN KEY REFERENCES Airlines(AirlineID)
)

CREATE TABLE Tickets
(
TickedID INT PRIMARY KEY,
Price DECIMAL(6,2) NOT NULL,
Class VARCHAR(6) NOT NULL CHECK (Class IN ('First', 'Second', 'Third')),
Seat VARCHAR(5) NOT NULL,
CustomerID INT CONSTRAINT FK_Tickets_Customers REFERENCES Customers(CustomerID),
FlightID INT CONSTRAINT FK_Tickets_Fligths REFERENCES Flights(FlightID)
)