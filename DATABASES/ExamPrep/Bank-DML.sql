--Inserts

INSERT INTO DepositTypes--(DepositTypeID,Name)
VALUES
(1, 'Time Deposit'),
(2, 'Call Deposit'),
(3, 'Free Deposit')

INSERT INTO Deposits(Amount,StartDate, DepositTypeID,CustomerID)
SELECT CASE 
			WHEN c.DateOfBirth > '1980-01-01' AND c.Gender = 'M' THEN 1100 
			WHEN c.DateOfBirth > '1980-01-01' AND c.Gender != 'M' THEN 1200
			WHEN c.DateOfBirth < '1980-01-01' AND c.Gender = 'M' THEN 1600
			WHEN c.DateOfBirth < '1980-01-01' AND c.Gender != 'M' THEN 1700
	   END AS Amount,
	   GETDATE() AS StartDate,
	   CASE
			WHEN c.CustomerID <= 15 AND c.CustomerID % 2 != 0 THEN 1
			WHEN c.CustomerID <= 15 AND c.CustomerID % 2 = 0 THEN 2
			WHEN c.CustomerID > 15 THEN 3
	   END AS DepositTypeID,
	   c.CustomerID AS CustomerID
FROM Customers AS c
WHERE c.CustomerID < 20


INSERT INTO EmployeesDeposits(EmployeeID, DepositID)
VALUES
(15,4),
(20,15),
(8,7),
(4,8),
(3,13),
(3,8),
(4,10),
(10,1),
(13,4),
(14,9)

--Updates

UPDATE Employees
SET ManagerID =
(CASE 
     WHEN EmployeeID BETWEEN 2 AND 10 THEN 1
	 WHEN EmployeeID BETWEEN 12 AND 20 THEN 11
	 WHEN EmployeeID BETWEEN 22 AND 30 THEN 21
	 WHEN EmployeeID = 11 OR EmployeeID = 21 THEN 1
 END)

 --Deletes

 DELETE FROM EmployeesDeposits
 WHERE EmployeeID = 3 OR DepositID = 9


