CREATE FUNCTION ufn_GetSalaryLevel(@salary MONEY)
RETURNS NVARCHAR(10) 
AS
BEGIN
	DECLARE @SalaryLevel NVARCHAR(10)
		IF(@salary < 30000)
			SELECT @SalaryLevel = 'Low'
		ELSE IF(@salary BETWEEN 30000 AND 50000)
			SELECT @SalaryLevel = 'Average'
		ELSE
			SELECT @SalaryLevel = 'High'
	RETURN @SalaryLevel
END


DECLARE @randomVar NVARCHAR(10)
EXEC @randomVar = ufn_GetSalaryLevel 999999
PRINT @randomVar