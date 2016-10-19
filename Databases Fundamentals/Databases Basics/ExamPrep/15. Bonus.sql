CREATE TABLE AccountLogs
(
AccountID INT PRIMARY KEY,
AccountNumber CHAR(12),
StartDate DATE,
CustomerID INT
)

GO

CREATE TRIGGER trg_InsertFromAccountsToAccountLogs
ON Accounts
INSTEAD OF DELETE
AS
BEGIN
	
	DELETE FROM EmployeesAccounts WHERE AccountID = (SELECT d.AccountID FROM deleted AS d)
	INSERT INTO AccountLogs
	SELECT * FROM deleted 
	DELETE FROM Accounts  WHERE AccountID = (SELECT d.AccountID FROM deleted AS d)
END

DELETE FROM [dbo].[Accounts] WHERE CustomerID = 4

TRUNCATE TABLE AccountLogs

SELECT * FROM AccountLogs