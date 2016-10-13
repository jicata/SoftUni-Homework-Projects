SELECT *
FROM
(SELECT u.Username,
	   ug.GameId,
	   SUM(s.Strength) AS [ItemStr],
	   SUM(s.Defence) AS [ItemDef],
	   SUM(s.Speed) AS [ItemSpeed],
	   SUM(s.Mind) AS [ItemMind],
	   SUM(s.Luck) AS [ItemLuck]
FROM Users AS u
	INNER JOIN UsersGames AS ug
		ON u.Id = ug.UserId
	INNER JOIN UserGameItems AS ugi
		ON ug.Id = ugi.UserGameId
	INNER JOIN Items AS i
		ON ugi.ItemId = i.Id
	INNER JOIN [Statistics] AS s
		ON i.StatisticId = s.Id
GROUP BY u.Username, ug.GameId) AS film
ORDER BY ItemStr DESC

--legit so far, now what? how can we join the Character Table? can't really group by CharacterId. Joining the Games table is EZ since we grouped by GameId but what about the Characters table?
SELECT 
	   SUM(s.Strength) AS [ItemStr],
	   SUM(s.Defence) AS [ItemDef],
	   SUM(s.Speed) AS [ItemSpeed],
	   SUM(s.Mind) AS [ItemMind],
	   SUM(s.Luck) AS [ItemLuck]
FROM Users AS u
	INNER JOIN UsersGames AS ug
		ON u.Id = ug.UserId
	INNER JOIN UserGameItems AS ugi
		ON ug.Id = ugi.UserGameId
	INNER JOIN Items AS i
		ON ugi.ItemId = i.Id
	INNER JOIN [Statistics] AS s
		ON i.StatisticId = s.Id
WHERE ugi.UserGameId = 97