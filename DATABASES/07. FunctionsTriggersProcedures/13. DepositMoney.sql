ALTER PROC usp_DepositMoney(@AccountID AS INT, @MoneyAmount AS DECIMAL(19,4))
AS
BEGIN
	DECLARE @CurrentBalance AS DECIMAL(19,4)
	DECLARE @NewBalance AS DECIMAL(19,4)
	BEGIN TRAN DepositMoney
	SET @CurrentBalance = (SELECT a.Balance
						  FROM Accounts AS a
						  WHERE a.Id = @AccountID)
	PRINT @CurrentBalance
	UPDATE Accounts
	SET Balance = Balance + @MoneyAmount
	WHERE Id = @AccountID
	
	SET @NewBalance = (SELECT a.Balance
						  FROM Accounts AS a
						  WHERE a.Id = @AccountID)
	IF(@NewBalance = @CurrentBalance OR @NewBalance < @CurrentBalance)
	BEGIN
		PRINT 'Deposit Unsuccessful'
		PRINT @CurrentBalance
		ROLLBACK
	END	
	ELSE
	BEGIN
		COMMIT TRAN DepositMoney
		PRINT 'Deposit successful'
	END
END

EXEC usp_DepositMoney 1, 5