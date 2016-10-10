CREATE TABLE Logs
(
LogId INT IDENTITY(1,1) PRIMARY KEY,
AccountId INT CONSTRAINT FK_Logs_Accounts FOREIGN KEY REFERENCES Accounts(Id),
OldSum MONEY,
NewSum MONEY,
)
GO

CREATE TRIGGER trg_LogAccountActivity
ON Accounts
AFTER UPDATE
AS
BEGIN
	DECLARE @AccountId AS INT
	DECLARE @OldSum AS MONEY
	DECLARE @NewSum AS MONEY

	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT d.Id,
		   d.Balance,
		   i.Balance
	FROM deleted AS d
		INNER JOIN inserted AS i
			ON i.Id = d.Id
END

UPDATE Accounts
SET Balance = 20
WHERE Id = 1

SELECT * FROM Logs