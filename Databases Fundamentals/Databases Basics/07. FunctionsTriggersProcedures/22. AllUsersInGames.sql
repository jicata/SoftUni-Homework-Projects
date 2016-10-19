SELECT gg.Game,
	   gg.[Game Type],
	   fp.Username,
	   fp.Level,
	   fp.Cash,
	   fp.Name AS [Character]
FROM
(SELECT u.Username,
	   ug.Level,
	   ug.Cash,
	   ug.GameId,
	   c.Name
FROM Users AS u
	INNER JOIN UsersGames AS ug
		ON ug.UserId = u.Id
	INNER JOIN Characters AS c
		ON ug.CharacterId = c.Id) AS fp
	INNER JOIN (SELECT g.Name AS [Game],
					   gt.Name AS [Game Type],
					   g.Id
				FROM Games AS g
					INNER JOIN GameTypes AS gt
						ON g.GameTypeId = gt.Id) AS gg
	ON fp.GameId = gg.Id
ORDER BY fp.Level DESC, fp.Username, gg.Game