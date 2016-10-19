
SELECT TOP 5cp.CountryName AS Country,
	   CASE
			WHEN pm.HighestPeakName IS NULL THEN '(no highest peak)'
			ELSE pm.HighestPeakName
	   END AS HighestPeakName,
	   CASE
			WHEN cp.HighestPeakElevation IS NULL THEN 0
			ELSE cp.HighestPeakElevation
	   END AS HighestPeakElevation,
	   CASE
			WHEN pm.MountainRange IS NULL THEN '(no mountain)'
			ELSE pm.MountainRange
	   END AS Mountain
FROM
(SELECT c.CountryName,
	   MAX(hp.HighestPeakElevation) AS HighestPeakElevation
FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
		ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m
		ON mc.MountainId = m.Id
LEFT JOIN (SELECT m.MountainRange,
				   MAX(p.Elevation) AS HighestPeakElevation
			FROM Mountains AS m
				INNER JOIN Peaks AS p
					ON m.Id = p.MountainId
			GROUP BY m.MountainRange) AS hp
ON m.MountainRange = hp.MountainRange
GROUP BY c.CountryName) AS cp
LEFT JOIN (SELECT p.PeakName AS HighestPeakName,
				   hp.HighestPeakElevation AS HighestPeakElevation,
				   hp.MountainRange,
				   p.MountainId
		  FROM Peaks AS p
				INNER JOIN (SELECT m.MountainRange,
							       MAX(p.Elevation) AS HighestPeakElevation
							FROM Mountains AS m
								INNER JOIN Peaks AS p
									ON m.Id = p.MountainId
							GROUP BY m.MountainRange) AS hp
					ON P.Elevation = hp.HighestPeakElevation) AS pm
ON cp.HighestPeakElevation = pm.HighestPeakElevation
ORDER BY cp.CountryName, pm.HighestPeakName