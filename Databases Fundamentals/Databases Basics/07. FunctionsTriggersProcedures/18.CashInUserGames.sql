CREATE FUNCTION ufn_CashInUsersGames(@GameName AS NVARCHAR(50))
RETURNS @SumCash TABLE
(
SumCash MONEY 
)
AS
BEGIN
	DECLARE @GameId INT
	SET @GameId = (SELECT g.Id
				   FROM Games AS g
				   WHERE g.Name = @GameName)

	INSERT INTO @SumCash(SumCash)
	SELECT SUM(n.Cash) AS SumCash
	FROM (SELECT ug.Cash,
			     ROW_NUMBER() OVER(ORDER BY Cash DESC) AS RowNumber
	      FROM UsersGames AS ug
			INNER JOIN Games AS g
				ON g.Id = ug.GameId 
				WHERE g.Name = @GameName) AS n	
	WHERE n.RowNumber % 2 !=0


	RETURN
END


DECLARE @table AS TABLE (SumCash MONEY)

INSERT INTO @table
SELECT * FROM ufn_CashInUsersGames('Lily Stargazer')

SELECT * FROM @table

