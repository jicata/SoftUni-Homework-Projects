SELECT mc.CountryCode,
	   COUNT(m.MountainRange) AS MountainRanges
FROM MountainsCountries AS mc
	INNER JOIN Mountains AS m
		ON m.Id = mc.MountainId
		AND (mc.CountryCode = 'BG' OR mc.CountryCode = 'RU' OR mc.CountryCode = 'US')
GROUP BY mc.CountryCode
