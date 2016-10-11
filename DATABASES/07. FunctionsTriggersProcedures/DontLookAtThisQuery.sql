SELECT f.Username,
	   kur.Game,
	   kur.ItemCount AS [Items Count],
	   f.[Items Price] AS [Items Price]
FROM
(SELECT 
	   g.Id AS GameId,
	   g.Name AS Game,
	  SUM(ipc.[Items Count]) AS ItemCount
FROM Users AS u
	INNER JOIN UsersGames AS ug
		ON u.Id = ug.UserId
	 JOIN (SELECT ugi.UserGameId,
					   SUM(ip.Price) AS [Items Price],
					   COUNT(*) AS [Items Count]
				FROM
					(SELECT i.Id,
							i.Price
					FROM Items AS i) AS ip
					INNER JOIN UserGameItems AS ugi
						ON ip.Id = ugi.ItemId
				GROUP BY ugi.UserGameId) AS ipc
		ON ug.Id = ipc.UserGameId
	INNER JOIN Games AS g
		ON ug.GameId = g.Id
GROUP BY g.id,g.Name
HAVING SUM(ipc.[Items Count]) >= 10) AS kur
	INNER JOIN	 (SELECT  u.Username,
						  ipp.[Items Price],
						  ug.GameId
				   FROM Users AS u
						INNER JOIN UsersGames AS ug
							ON u.Id = ug.UserId
						INNER JOIN (SELECT ugi.UserGameId,
										   SUM(ip.Price) AS [Items Price]
									FROM
										(SELECT i.Id,
												i.Price
										 FROM Items AS i) AS ip
											INNER JOIN UserGameItems AS ugi
												ON ip.Id = ugi.ItemId
									GROUP BY ugi.UserGameId) AS ipp
								ON ug.Id = ipp.UserGameId) AS f
	ON kur.GameId = f.GameId
ORDER BY kur.ItemCount DESC, f.[Items Price] DESC, f.Username

SELECT *
FROM Users AS u
	INNER JOIN UsersGames AS ug
		ON u.Id = ug.UserId
	INNER JOIN (SELECT ugi.UserGameId,
					   SUM(ip.Price) AS [Items Price]
				FROM
					(SELECT *
					 FROM Items AS i) AS ip
						INNER JOIN UserGameItems AS ugi
						ON ip.Id = ugi.ItemId
				GROUP BY ugi.UserGameId)
















SELECT ug.Id
FROM UsersGames AS ug
	INNER JOIN Games AS g
		ON g.Id = 35 AND g.Id = ug.GameId

SELECT COUNT(ugi.ItemId)
FROM UserGameItems AS ugi
WHERE ugi.UserGameId = 36 OR ugi.UserGameId = 97-- OR ugi.UserGameId = 172 OR ugi.UserGameId = 209
