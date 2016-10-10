CREATE FUNCTION ufn_CalculateFutureValue(@Sum AS DECIMAL(19,2), @Interest AS FLOAT, @NumberOfYears AS INT)
RETURNS DECIMAL(19,2)
AS
BEGIN
	DECLARE @FutureValue AS DECIMAL(19,2)
	SET @FutureValue = @Sum * POWER(1+@Interest, @NumberOfYears) 
	RETURN @FutureValue
END


DECLARE @FutureValue AS DECIMAL(19,2)
EXEC @FutureValue = ufn_CalculateFutureValue 1000, 0.1, 5

PRINT @FutureValue