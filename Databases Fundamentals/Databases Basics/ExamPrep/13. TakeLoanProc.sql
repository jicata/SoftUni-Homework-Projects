CREATE PROC usp_TakeLoan(@CustomerID AS INT, @LoanAmount AS DECIMAL(18,2), @Interest AS FLOAT, @StartDate AS VARCHAR(MAX))
AS
BEGIN

	DECLARE @StartDateAsDate AS DATE
	SET @StartDateAsDate = CONVERT(DATE, @StartDate)
	BEGIN TRAN TakeLoan
	IF (@LoanAmount < 0.01 OR @LoanAmount > 100000)
	BEGIN
		RAISERROR('Invalid Loan Amount.',16,1)
		ROLLBACK
	END 
	INSERT INTO Loans(StartDate, Amount, Interest, CustomerID)
	VALUES(@StartDate, @LoanAmount, @Interest, @CustomerID)
	COMMIT
END

EXEC usp_TakeLoan @CustomerID = 1, @LoanAmount = 500, @Interest = 1, @StartDate='20160915'
