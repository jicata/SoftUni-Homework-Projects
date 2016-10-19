INSERT INTO UserGameItems(UserGameId,ItemId)
SELECT (SELECT DISTINCT ug.Id
				FROM Users AS u
					INNER JOIN UsersGames AS ug
						ON u.Id = ug.UserId
					INNER JOIN Games AS g
						ON ug.GameId = g.Id
						AND g.Name='Edinburgh'
						AND u.Username = 'Alex'
					INNER JOIN UserGameItems AS ugi
						ON ug.Id = ugi.UserGameId
					INNER JOIN Items AS i
						ON i.Id = ugi.ItemId),
		i.id
FROM Items AS i
WHERE i.Name IN ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet')

UPDATE UsersGames
SET Cash -= (SELECT SUM(i.Price)
			 FROM Items AS i
			 WHERE i.Name IN ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet'))
WHERE Id = (SELECT DISTINCT ug.Id
				FROM Users AS u
					INNER JOIN UsersGames AS ug
						ON u.Id = ug.UserId
					INNER JOIN Games AS g
						ON ug.GameId = g.Id
						AND g.Name='Edinburgh'
						AND u.Username = 'Alex'
					INNER JOIN UserGameItems AS ugi
						ON ug.Id = ugi.UserGameId
					INNER JOIN Items AS i
						ON i.Id = ugi.ItemId)

SELECT u.Username,
	   g.Name,
	   ug.Cash,
	   i.Name AS [Item Name]
FROM Users AS u
	INNER JOIN UsersGames AS ug
		ON u.Id = ug.UserId
	INNER JOIN Games AS g
		ON ug.GameId = g.Id
		AND g.Name='Edinburgh'
		--AND u.Username = 'Alex'
	INNER JOIN UserGameItems AS ugi
		ON ug.Id = ugi.UserGameId
	INNER JOIN Items AS i
		ON i.Id = ugi.ItemId
ORDER BY [Item Name]