USE SoftUni
GO

CREATE PROC usp_GetTownsStartingWith(@StartsWith AS NVARCHAR(MAX))
AS
BEGIN
	SELECT t.Name
	FROM Towns AS t
	WHERE @StartsWith = LEFT(t.Name, LEN(@StartsWith))
END

EXECUTE usp_GetTownsStartingWith 'dul'
