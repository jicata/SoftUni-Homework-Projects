ALTER PROC usp_TransferMoney(@SourceAccountId AS INT, @DestinationAccountId AS INT, @MoneyToTransfer AS MONEY)
AS
BEGIN
	BEGIN TRAN MoneyTransfer
	IF( NOT EXISTS (SELECT a.Id FROM Accounts AS a WHERE a.Id = @SourceAccountId) OR NOT EXISTS (SELECT a.Id FROM Accounts AS a WHERE a.Id = @DestinationAccountId))
	BEGIN
		PRINT 'Account Id Invalid'
		ROLLBACK
	END
	ELSE IF (@MoneyToTransfer < 0)
	BEGIN
		PRINT 'Money cannot be less than 0'
		ROLLBACK
	END

	DECLARE @SourceBefore AS MONEY
	DECLARE @DestinationBefore AS MONEY
	DECLARE @SourcePost AS MONEY
	DECLARE @DestinationPost AS MONEY

	SET @SourceBefore = (SELECT a.Balance
						 FROM Accounts AS a
						 WHERE a.Id = @SourceAccountId)
	SET @DestinationBefore = (SELECT a.Balance
							  FROM Accounts AS a
							  WHERE a.Id = @DestinationAccountId)

	UPDATE Accounts
	SET Balance = Balance - @MoneyToTransfer
	WHERE Id = @SourceAccountId

	UPDATE Accounts
	SET Balance = Balance + @MoneyToTransfer
	WHERE Id = @DestinationAccountId

	SELECT @SourcePost = (SELECT a.Balance
						 FROM Accounts AS a
						 WHERE a.Id = @SourceAccountId)

	SELECT @DestinationPost = (SELECT a.Balance
						 FROM Accounts AS a
						 WHERE a.Id = @DestinationAccountId)

	IF(@SourceBefore = @SourcePost OR @DestinationBefore = @DestinationPost)
	BEGIN
		PRINT 'Transfer incomplete'
		ROLLBACK
	END
	ELSE
	BEGIN
		PRINT 'Transfer successful'
		COMMIT
	END
END


EXEC usp_TransferMoney 1, 3, 5