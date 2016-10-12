SELECT mingie.Username,
		mingie.Game,
		mingie.Name,
		mingie.Strength
FROM
(SELECT  gts.Username,
		gts.Game,
		cs.Name,
		SUM(gts.Strength) + SUM(cs.Strength) + SUM(gg.Strength) Strength
FROM
(SELECT u.Username,
	   g.Name AS Game,
	   ug.CharacterId,
	   ug.Id AS UserGameId,
	   s.Strength,
	   s.Defence,
	   s.Speed,
	   s.Mind,
	   s.Luck
FROM Users AS u
	INNER JOIN UsersGames AS ug
		ON ug.UserId = u.Id
	INNER JOIN Games AS g
		ON ug.GameId = g.Id
	INNER JOIN GameTypes AS gt
		ON g.GameTypeId = gt.Id
	INNER JOIN [Statistics] AS s
		ON gt.BonusStatsId = s.Id) AS gts
	INNER JOIN (SELECT c.StatisticId,
					   c.Id,
					   c.Name,
					   ss.Strength,
					   ss.Defence,
					   ss.Speed,
					   ss.Mind,
					   ss.Luck
				FROM Characters AS c
					INNER JOIN [Statistics] AS ss
						ON c.StatisticId = ss.Id) AS cs
	ON cs.Id = gts.CharacterId
	INNER JOIN (SELECT ugi.ItemId,
					   ug.GameId,
					   sss.Strength
			   FROM UsersGames AS ug
					INNER JOIN UserGameItems AS ugi
						ON ug.GameId = ugi.UserGameId
					INNER JOIN Items AS i
						ON ugi.ItemId = i.Id
					INNER JOIN [Statistics] AS sss
						ON i.StatisticId = sss.Id) AS gg
	ON gts.UserGameId = gg.GameId

GROUP BY gts.Username,
		 gts.Game,
		 cs.Name) AS mingie
ORDER BY mingie.Strength DESC