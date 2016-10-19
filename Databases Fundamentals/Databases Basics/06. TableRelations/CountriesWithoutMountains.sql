SELECT COUNT(c.CountryCode) AS CountryCode
FROM
(SELECT c.CountryCode,
	   mc.MountainId
FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
		ON c.CountryCode = mc.CountryCode) AS c
WHERE c.MountainId IS NULL