CREATE FUNCTION udf_ConcatString (@FirstString AS VARCHAR(MAX), @SecondString AS VARCHAR(MAX))
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @ReversedFirst VARCHAR(MAX)
	DECLARE @ReversedSecond VARCHAR(MAX)
	DECLARE @ConcatResult VARCHAR(MAX)

	SET @ReversedFirst = REVERSE(@FirstString)
	SET @ReversedSecond = REVERSE(@SecondString)

	SET @ConcatResult = CONCAT(@ReversedFirst, @ReversedSecond)

	RETURN @ConcatResult

END


DECLARE @result AS VARCHAR(MAX)
EXEC @result = udf_ConcatString '123', '456'

PRINT @result