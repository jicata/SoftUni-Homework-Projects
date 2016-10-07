CREATE TABLE Employees
(
Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Employees PRIMARY KEY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20),
Title NVARCHAR(20) NOT NULL,
Notes NVARCHAR(max),
)

INSERT INTO Employees(FirstName, LastName, Title, Notes)
VALUES
('Rumen', 'Ivanov', 'Janitor', 'Tuka si e ebalo makqta!'),
('Kris', 'Milkin', 'Yung-Merindjei', NULL),
('Martin', NULL, 'Piinqk', 'Tva nema kak da stane');

CREATE TABLE Customers
(
AccountNumber INT NOT NULL CONSTRAINT PK_Customers PRIMARY KEY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20),
PhoneNumber NVARCHAR(max) NOT NULL,
EmergencyName NVARCHAR(20) NOT NULL,
EmergencyNumber INT NOT NULL,
Notes NVARCHAR(max)
)

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES
(19282623, 'Pesho', NULL, '35908726352', 'PMan', 34, NULL),
(83627124, 'Stamat', 'Stamatev', '35948262352', 'SMan', 43, 'kvo?'),
(34732105, 'NeBqh', 'Az', '35936251744', 'Anon', 1, 'null');

CREATE TABLE RoomStatus
(
RoomStatus VARCHAR(20) CHECK (RoomStatus IN('Factory New', 'Minimal Wear', 'Field Tested')) CONSTRAINT PK_RoomStatus PRIMARY KEY,
Notes NVARCHAR(max)
)

INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES
('Factory New','chistak bursak'),
('Minimal Wear','malko mrasno'),
('Field Tested', 'palen ojas');

CREATE TABLE RoomTypes
(
RoomType VARCHAR(20) CHECK (RoomType IN('One Bed', 'Two Bed', 'KING PALACE')) NOT NULL CONSTRAINT PK_RoomTypes PRIMARY KEY,
Notes NVARCHAR(max)
)

INSERT INTO RoomTypes(RoomType, Notes)
VALUES
('One Bed', 'malko e'),
('Two Bed', 'malko e ma stava'),
('KING PALACE', 'idealka brat');

CREATE TABLE BedTypes
(
BedType VARCHAR(20) CHECK (BedType IN('One Man', 'Two Man', 'Debel kur')) NOT NULL CONSTRAINT PK_BedTypes PRIMARY KEY,
Notes NVARCHAR(max)
)

INSERT INTO BedTypes(BedType, Notes)
VALUES
('One Man', 'stava'),
('Debel Kur', NULL),
('Two Man', NULL);

CREATE TABLE Rooms
(
RoomNumber INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Rooms PRIMARY KEY,
RoomType VARCHAR(20) CHECK (RoomType IN('One Bed', 'Two Bed', 'KING PALACE')) NOT NULL CONSTRAINT FK_RoomType FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType VARCHAR(20) CHECK (BedType IN('One Man', 'Two Man')) NOT NULL CONSTRAINT FK_BedType FOREIGN KEY REFERENCES BedTypes(BedType),
Rate INT,
RoomStatus VARCHAR(20) CHECK (RoomStatus IN('Factory New', 'Minimal Wear', 'Field Tested')) CONSTRAINT FK_RoomStatus FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
Notes NVARCHAR(max)
)

INSERT INTO Rooms(RoomType, BedType, Rate, RoomStatus, Notes)
VALUES
('One Bed', 'One Man', 3, 'Factory New', NULL),
('One Bed', 'Two Man', 7, 'Field Tested', 'she e guch'),
('Two Bed', 'Two Man', 2, 'Factory New', NULL);

CREATE TABLE Payments
(
Id INT NOT NULL CONSTRAINT PK_Payments PRIMARY KEY,
EmployeeId INT NOT NULL CONSTRAINT FK_Employees FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATETIME NOT NULL,
AccountNumber INT NOT NULL CONSTRAINT FK_Customers FOREIGN KEY REFERENCES Customers(AccountNumber),
FirstDateOccupied DATETIME,
LastDateOccupied DATETIME,
TotalDays INT NOT NULL,
AmountCharged DECIMAL(19,4),
TaxRate FLOAT,
TaxAmount INT,
PaymentTotal DECIMAL(19,4) NOT NULL,
Notes NVARCHAR(max)
)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES
(1,'2016-09-29', 19282623, NULL, NULL, 3, 150.54,3.14, 300, 450.54, 'drusnahme go'),
(2,'1994-02-29', 34732105, NULL, NULL, 3, 150.54,3.14, 300, 450.54, 'drusnahme go'),
(3,'2016-09-29', 19282623, NULL, NULL, 3, 150.54,3.14, 300, 450.54, 'drusnahme go');

CREATE TABLE Occupancies
(
Id INT NOT NULL CONSTRAINT PK_Occupancies PRIMARY KEY,
EmployeeId INT NOT NULL CONSTRAINT FK_Employees_Occupancies FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATETIME NOT NULL,
AccountNumber INT NOT NULL CONSTRAINT FK_Customers_Occupancies FOREIGN KEY REFERENCES Customers(AccountNumber),
RoomNumber INT NOT NULL CONSTRAINT FK_Rooms_Occupancies FOREIGN KEY REFERENCES Rooms(RoomNumber),
RateApplied FLOAT,
PhoneCharge FLOAT,
Notes NVARCHAR(max)
)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES
(1,'2016-28-09', 34732105, 1, 3.14, 14.3, NULL),
(2,'2016-28-09', 34732105, 1, 3.14, 14.3, NULL),
(3,'2016-28-09', 34732105, 1, 3.14, 14.3, NULL);