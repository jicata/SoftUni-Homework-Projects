BEGIN TRY
	BEGIN TRAN dodoEGei
		BEGIN
			DECLARE @UserId INT
			DECLARE @GameId INT
			DECLARE @GameUserID INT
			DECLARE @TotalAvailableCash DECIMAL (10,2)
			DECLARE @TotalItemValue INT

			SELECT @UserId = u.Id,
				   @GameId = g.Id,
				   @GameUserID = ug.Id
			FROM Users AS u
				INNER JOIN UsersGames AS ug
					ON u.Id = ug.UserId
				INNER JOIN Games AS g
					ON ug.GameId = g.Id
			WHERE u.Username = 'Stamat' AND g.Name = 'Safflower'

			SET @TotalItemValue = (SELECT SUM(i.Price) 
								   FROM Items AS i 
								   WHERE i.MinLevel BETWEEN 11 AND 12)

			INSERT INTO UserGameItems(ItemId, UserGameId)
			SELECT i.Id,
				   @GameUserID
			FROM Items AS i 
			WHERE i.MinLevel BETWEEN 11 AND 12

			UPDATE UsersGames
			SET Cash -= @TotalItemValue
			WHERE Id = @GameUserID

			SET @TotalAvailableCash = (SELECT Cash FROM UsersGames WHERE Id = @GameUserID)
			IF(@TotalAvailableCash < 0)
				ROLLBACK
			ELSE
				COMMIT
		END
END TRY
BEGIN CATCH
	ROLLBACK TRAN dodoEGei
END CATCH

BEGIN TRY
	BEGIN TRAN dodoEGei2
		BEGIN
		

			SELECT @UserId = u.Id,
				   @GameId = g.Id,
				   @GameUserID = ug.Id
			FROM Users AS u
				INNER JOIN UsersGames AS ug
					ON u.Id = ug.UserId
				INNER JOIN Games AS g
					ON ug.GameId = g.Id
			WHERE u.Username = 'Stamat' AND g.Name = 'Safflower'

			SET @TotalItemValue = (SELECT SUM(i.Price) 
								   FROM Items AS i 
								   WHERE i.MinLevel BETWEEN 11 AND 12)

			INSERT INTO UserGameItems(ItemId, UserGameId)
			SELECT i.Id,
				   @GameUserID
			FROM Items AS i 
			WHERE i.MinLevel BETWEEN 11 AND 12

			UPDATE UsersGames
			SET Cash -= @TotalItemValue
			WHERE Id = @GameUserID

			SET @TotalAvailableCash = (SELECT Cash FROM UsersGames WHERE Id = @GameUserID)
			IF(@TotalAvailableCash < 0)
				ROLLBACK
			ELSE
				COMMIT
		END
END TRY
BEGIN CATCH
	ROLLBACK TRAN dodoEGei2
END CATCH

SELECT i.Name
FROM UserGameItems AS ugi
	INNER JOIN Items AS i
		ON ugi.ItemId = i.Id
		AND ugi.UserGameId = @GameUserID
ORDER BY i.Name