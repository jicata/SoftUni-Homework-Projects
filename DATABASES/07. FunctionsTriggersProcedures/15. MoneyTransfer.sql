CREATE PROC usp_TransferMoney(@SourceAccountId AS INT, @DestinationAccountId AS INT, @MoneyToTransfer AS DECIMAL)
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

	@

END