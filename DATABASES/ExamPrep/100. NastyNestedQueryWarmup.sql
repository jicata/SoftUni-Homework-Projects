SELECT kurche.ContinentCode,
	   penis.CurrencyCode,
	   kurche.CurrencyUsage 
FROM
(SELECT kur.ContinentCode,
	   MAX(kur.CurrencyUsage) AS CurrencyUsage
FROM
(SELECT c.CurrencyCode,
	   c.ContinentCode,
		COUNT(*) AS CurrencyUsage
FROM Countries AS c
GROUP BY C.CurrencyCode, c.ContinentCode
HAVING COUNT(*) > 1) as kur
GROUP by kur.ContinentCode) AS kurche
INNER JOIN (SELECT c.CurrencyCode,
					c.ContinentCode,
					COUNT(*) AS CurrencyUsage
			FROM Countries AS c
			GROUP BY C.CurrencyCode, c.ContinentCode
			HAVING COUNT(*) > 1) AS penis
		 ON kurche.ContinentCode = penis.ContinentCode
		 AND penis.CurrencyUsage = kurche.CurrencyUsage
ORDER BY penis.ContinentCode