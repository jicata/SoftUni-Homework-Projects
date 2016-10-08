USE Geography
GO

SELECT mc.CountryCode,
	   m.MountainRange,
	   p.PeakName,
	   p.Elevation
FROM MountainsCountries AS mc
	INNER JOIN Mountains AS m
		ON mc.MountainId = m.Id
	INNER JOIN Peaks as p
		ON m.Id = p.MountainId
WHERE p.Elevation > 2835 AND mc.CountryCode = 'BG'
ORDER BY p.Elevation DESC