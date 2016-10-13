SELECT Calc.CountryName,
	   co.ContinentName,
	   CASE 
			WHEN Calc.RiversCount = 0 THEN 0
			ELSE Calc.RiversCount
	   END AS RiversCount,
	   CASE
			WHEN Calc.RiversCount = 0 THEN 0
			ELSE Calc.TotalLength
	   END AS TotalLength
FROM
(SELECT c.CountryName,
	  SUm(r.Length) AS TotalLength,
	  COUNT(cr.RiverId) AS RiversCount
FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr
		ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r
		ON cr.RiverId = r.Id
GROUP BY c.CountryName) AS Calc
INNER JOIN Countries AS c
	ON Calc.CountryName = c.CountryName
INNER JOIN Continents AS co
	ON c.ContinentCode = co.ContinentCode
ORDER BY RiversCount DESC, TotalLength DESC, CountryName