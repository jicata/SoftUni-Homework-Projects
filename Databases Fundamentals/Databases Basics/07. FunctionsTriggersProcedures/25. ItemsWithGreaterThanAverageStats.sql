SELECT i.Name,
	   i.Price,
	   i.MinLevel,
	   s.Strength,
	   s.Defence,
	   s.Speed,
	   s.Luck,
	   s.Mind
FROM Items AS i
	INNER JOIN [Statistics] AS s
		ON i.StatisticId = s.Id
WHERE s.Mind > (SELECT  AVG(s.Mind) AS AverageMind
				FROM Items AS i
					INNER JOIN [Statistics] as s
						ON i.StatisticId = s.Id)
AND s.Luck > (SELECT  AVG(s.Luck) AS AverageMind
				FROM Items AS i
					INNER JOIN [Statistics] as s
						ON i.StatisticId = s.Id)
AND s.Speed > (SELECT  AVG(s.Speed) AS AverageMind
				FROM Items AS i
					INNER JOIN [Statistics] as s
						ON i.StatisticId = s.Id)
ORDER BY i.Name






