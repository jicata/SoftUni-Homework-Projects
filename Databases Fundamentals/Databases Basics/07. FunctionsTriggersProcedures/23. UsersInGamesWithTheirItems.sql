SELECT f.Username,
	   f.Name AS Game,
	   SUM(s.[Items Count]) AS [Items Count],
	   SUM(s.[Items Price]) AS [Items Price]
FROM
(SELECT u.Username,
	   g.Name,
	   ug.Id AS UserGameId,
	   g.Id AS GameId
FROM Users AS u
	INNER JOIN UsersGames AS ug
		ON u.Id = ug.UserId
	INNER JOIN Games AS g
		ON ug.GameId = g.Id) AS f
INNER JOIN (SELECT ugi.UserGameId,
				   SUM(i.Price) AS [Items Price],
				   COUNT(*) AS [Items Count]
			FROM Items AS i
				INNER JOIN UserGameItems AS ugi
					ON i.Id = ugi.ItemId
			GROUP BY ugi.UserGameId) AS s
ON s.UserGameId = f.UserGameId
GROUP BY f.Username, f.Name
HAVING SUM(s.[Items Count]) >= 10
ORDER BY [Items Count] desc, [Items Price] desc, f.Username