
SELECT TOP 5  el.CountryName,
	   el.HighestPeakElevation,
	   rl.LongestRiverLength
FROM
(SELECT c.CountryName,
	   MAX(p.Elevation) AS HighestPeakElevation
FROM Countries AS c
	INNER JOIN MountainsCountries AS mc
		ON c.CountryCode = mc.CountryCode
	INNER JOIN Mountains AS m
		ON mc.MountainId = m.Id
	INNER JOIN Peaks AS p
		ON m.Id = p.MountainId
GROUP BY c.CountryName) AS el
	LEFT JOIN (SELECT c.CountryName,
				 MAX(r.Length) AS LongestRiverLength
			FROM Countries AS c
				INNER JOIN CountriesRivers AS cr
					ON c.CountryCode = cr.CountryCode
				INNER JOIN Rivers AS r
					ON cr.RiverId = r.Id
			GROUP BY c.CountryName) AS rl
		ON el.CountryName = rl.CountryName
ORDER BY el.HighestPeakElevation DESC, rl.LongestRiverLength DESC, el.CountryName



