CREATE PROC usp_WithdrawMoney(@AccountId AS INT, @MoneyAmount AS DECIMAL(19,4))
AS
BEGIN
	BEGIN TRAN WithdrawMoney
	DECLARE @MoneyBeforeTran AS DECIMAL (19,4)
	DECLARE @MoneyAfterTran AS DECIMAL (19,4)
	SET @MoneyBeforeTran = (SELECT a.Balance
						   FROM Accounts AS a 
						   WHERE a.Id = @AccountId)
	UPDATE Accounts
	SET Balance = Balance - @MoneyAmount
	WHERE Id = @AccountId

	SELECT @MoneyAfterTran = (SELECT a.Balance
						      FROM Accounts AS a 
						      WHERE a.Id = @AccountId)

	IF(@MoneyAfterTran < 0 OR @MoneyAfterTran >= @MoneyBeforeTran)
	BEGIN
		PRINT 'Money not withdrawn'
		ROLLBACK
	END
	ELSE
	BEGIN
		PRINT 'Withdrawl successful'
		COMMIT
	END
END

EXEC usp_WithdrawMoney 1, 500