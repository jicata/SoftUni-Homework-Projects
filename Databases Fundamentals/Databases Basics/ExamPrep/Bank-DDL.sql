	CREATE TABLE DepositTypes
(
DepositTypeID INT PRIMARY KEY,
Name VARCHAR(20)
)

CREATE TABLE Deposits
(
DepositID INT IDENTITY(1,1) PRIMARY KEY,
Amount DECIMAL (10,2),
StartDate DATE,
EndDate DATE,
DepositTypeID INT CONSTRAINT FK_Deposits_DepositTypes FOREIGN KEY REFERENCES DepositTypes(DepositTypeID),
CustomerID INT CONSTRAINT FK_Deposits_Customers FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE EmployeesDeposits
(
EmployeeID INT,
DepositID INT,
CONSTRAINT FK_EmployeesDeps_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
CONSTRAINT FK_EmployeesDeps_Deposits FOREIGN KEY (DepositID) REFERENCES Deposits(DepositID),
CONSTRAINT PK_EmployeesDeposits PRIMARY KEY (EmployeeID, DepositID)
)

CREATE TABLE CreditHistory
(
CreditHistoryID INT PRIMARY KEY,
Mark CHAR(1),
StartDate DATE,
EndDate DATE,
CustomerID INT CONSTRAINT FK_CreditHistory_Customers FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE Payments
(
PaymentID INT PRIMARY KEY,
[Date] DATE,
Amount DECIMAL(10,2),
LoanID INT CONSTRAINT FK_Payments_Loans FOREIGN KEY REFERENCES Loans(LoanID)
)

CREATE TABLE Users
(
UserID INT PRIMARY KEY,
UserName VARCHAR(20),
[Password] VARCHAR(20),
CustomerID INT UNIQUE CONSTRAINT FK_UsersCustomers FOREIGN KEY REFERENCES Customers(CustomerID)
)

ALTER TABLE Employees
ADD ManagerID INT CONSTRAINT SFK_ManagerID_EmployeeID FOREIGN KEY REFERENCES Employees(EmployeeID)