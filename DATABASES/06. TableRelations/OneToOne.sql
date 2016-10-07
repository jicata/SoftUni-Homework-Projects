USE Test
GO


CREATE TABLE Passports
(
PassportId INT PRIMARY KEY, --CONSTRAINT FK_Passports_Persons FOREIGN KEY REFERENCES Persons(PassportID),
PassportNumber NVARCHAR(10) NOT NULL
)


INSERT INTO Passports(PassportId,PassportNumber)
VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

CREATE TABLE Persons
(
PersonId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
FirstName NVARCHAR(20) NOT NULL,
Salary DECIMAL(19,4) NOT NULL,
PassportID INT NOT NULL CONSTRAINT FK_Persons_Passports FOREIGN KEY REFERENCES Passports(PassportId)
)

INSERT INTO Persons(FirstName, Salary, PassportID)
VALUES
('Roberto',43300.00,102),
('Tom',	56100.00,103),
('Yana', 60200.00,101)
