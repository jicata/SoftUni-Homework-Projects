ALTER FUNCTION ufn_IsWordComprised (@setOfLetters AS NVARCHAR(MAX), @word AS NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @Comprise BIT
	DECLARE @wordIndex INT = 1
	DECLARE @setIndex INT = 1
	DECLARE @Flag BIT = 0
	DECLARE @letter NCHAR
	SET @word = LTRIM(@word)
	SET @word = RTRIM(@word)

	WHILE(@wordIndex <= LEN(@word)) 
	BEGIN
		SET @Flag = 0		
		SET @letter = SUBSTRING(@word, @wordIndex,1)
		WHILE(@setIndex <= LEN(@setOfLetters))
		BEGIN
			IF(SUBSTRING(@setOfLetters,@setIndex,1) = @letter)
			BEGIN
				SET @Flag = 1
				BREAK
			END
			SET @setIndex = @setIndex+1
		END
		IF (@Flag != 1)
		BEGIN
			SET @Comprise = 0
			BREAK
		END
		SET @setIndex = 1
		SET @wordIndex = @wordIndex+1
	END
	SET @setIndex = 1

	IF(LEN(@word) = 0 AND LEN(@setOFLetters) != 0)
	BEGIN
	SET @letter = SUBSTRING(@word, @wordIndex,1)
	WHILE(@setIndex <= LEN(@setOfLetters))
		BEGIN
			IF(SUBSTRING(@setOfLetters,@setIndex,1) = @letter)
			BEGIN
				SET @Flag = 1
				BREAK
			END
			SET @setIndex = @setIndex+1
		END
	END

	IF(LEN(@word) = 0 AND LEN(@setOfLetters) = 0)
		SET @Comprise = 1
	ELSE IF(@Flag = 0)
		SET @Comprise = 0
	ELSE
		SET @Comprise = 1
	RETURN @Comprise
END 


GO

DECLARE @kur BIT

EXEC @kur = ufn_IsWordComprised 'k ur', ' '

Print @kur
