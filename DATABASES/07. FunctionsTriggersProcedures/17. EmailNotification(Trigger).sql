--NotificationEmails(Id, Recipient, Subject, Body

CREATE TABLE NotificationEmails
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Recipient INT,
[Subject] NVARCHAR(50),
Body NVARCHAR(MAX)
)
GO

alter TRIGGER trg_EmailOnLog
ON Logs
AFTER INSERT, UPDATE
AS
BEGIN
	--DECLARE @AccountId INT
	INSERT INTO NotificationEmails(Recipient, [Subject], Body)
	SELECT d.AccountId,
		   CONCAT('Balance change for account: ',d.AccountId), --test concat
		   CONCAT('On date ',GETDATE(),' your balance was changed from ', d.OldSum,' to ',d.NewSum)	    
	FROM inserted as d
END

UPDATE Accounts
SET Balance = 666
WHERE id = 1

SELECT * FROM NotificationEmails