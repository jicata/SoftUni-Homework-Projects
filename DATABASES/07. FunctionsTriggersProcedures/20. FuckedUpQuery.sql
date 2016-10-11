SELECT i.Name
FROM Items AS i
	INNER JOIN UserGameItems AS ugi
		ON i.Id = ugi.ItemId
	INNER JOIN UsersGames AS ug
		ON ugi.UserGameId = ug.GameId
	INNER JOIN Games AS g
		ON ug.GameId = g.Id
		AND g.Name = 'Safflower'

BEGIN TRANSACTION Items11And12
BEGIN
	DECLARE @TotalCostOfItems MONEY
	SET @TotalCostOfItems = (SELECT SUM(i.Price)
							 FROM Items AS i
							 WHERE i .MinLevel BETWEEN 11 AND 12)

	INSERT INTO UserGameItems(ItemId,UserGameId)
	SELECT i.Id, 
		   87
	FROM Items AS i
	WHERE i.MinLevel BETWEEN 11 AND 12

	UPDATE UsersGames
	SET Cash -= @TotalCostOfItems
	WHERE UserId IN (SELECT u.Id
					  FROM UsersGames AS ug
							INNER JOIN Users AS u
								ON ug.UserId = u.Id
								AND u.FirstName = 'Stamat')
	DECLARE @CurrentBalance AS MONEY
	SET @CurrentBalance = (SELECT ug.Cash
						   FROM UsersGames AS ug
								INNER JOIN Users AS u
									ON ug.UserId = u.Id
									AND ug.GameId = 87)
	IF(@CurrentBalance < 0)
	BEGIN
		ROLLBACK
	END
	ELSE
	BEGIN
		COMMIT
	END

END
BEGIN TRY
BEGIN TRANSACTION Items19And21
BEGIN
	DECLARE @TotalCostOfItemsTwo MONEY
	SET @TotalCostOfItemsTwo = (SELECT SUM(i.Price)
							 FROM Items AS i
							 WHERE i .MinLevel BETWEEN 19 AND 21)
	
	INSERT INTO UserGameItems(ItemId,UserGameId)
	SELECT i.Id, 
		   87
	FROM Items AS i
	WHERE i.MinLevel BETWEEN 19 AND 21
	AND i.Id NOT IN(SELECT i.Id
					FROM Items AS i)
	UPDATE UsersGames
	SET Cash -= @TotalCostOfItemsTwo
	WHERE UserId IN (SELECT u.Id
					  FROM UsersGames AS ug
							INNER JOIN Users AS u
								ON ug.UserId = u.Id
								AND u.FirstName = 'Stamat')
	
	DECLARE @CurrentBalanceTwo AS MONEY
	SET @CurrentBalanceTwo = (SELECT ug.Cash
						   FROM UsersGames AS ug
								INNER JOIN Users AS u
									ON ug.UserId = u.Id
									AND ug.GameId = 87)
	IF(@CurrentBalanceTwo < 0)
	BEGIN
		ROLLBACK
	END
	ELSE
	BEGIN
		COMMIT
	END
	

END
END TRY
BEGIN CATCH
	ROLLBACK
END CATCH

	SELECT  i.Name
	FROM
	(SELECT ug.GameId,
			g.Name,
			u.Username,
			ug.Level,
			ug.Cash
	FROM Users AS u
		INNER JOIN UsersGames AS ug
			ON u.Id = ug.UserId
		INNER JOIN Games AS g
			ON ug.GameId = g.Id
	WHERE u.Username = 'Stamat'
	AND g.Name = 'Safflower') AS st
		INNER JOIN UserGameItems AS ugi
			ON st.GameId = ugi.UserGameId
		INNER JOIN Items AS i
			ON ugi.ItemId = i.Id
	ORDER BY i.Name



