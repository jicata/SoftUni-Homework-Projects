SELECT co.ContinentName,
	   pop.CountriesArea,
	   pop.CountriesPopulation
FROM
(SELECT c.ContinentCode,
	   SUM(CONVERT(bigint,c.AreaInSqKm)) AS CountriesArea,
	   SUM(CONVERT(bigint,c.Population)) AS CountriesPopulation
FROM Countries AS c
GROUP BY c.ContinentCode) AS pop
	INNER JOIN Continents AS co
		ON pop.ContinentCode = co.ContinentCode
ORDER BY pop.CountriesPopulation DESC