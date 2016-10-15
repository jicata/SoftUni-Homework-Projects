UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'


INSERT INTO Monasteries VALUES
('Hanga Abbey', 'TZ')
--('Myin-Tin-Daik','Myanmar'),


SELECT co.ContinentName, 
	   cm.CountryName,
	   cm.MonasteriesCount
FROM
(SELECT c.CountryName,
	    COUNT(m.Name) AS MonasteriesCount
FROM Countries AS c
	LEFT JOIN Monasteries AS m
		ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted != 1
GROUP BY c.CountryName) AS cm
	INNER JOIN Countries AS c
		ON cm.CountryName = c.CountryName
	INNER JOIN Continents AS co
		ON c.ContinentCode = co.ContinentCode
ORDER BY cm.MonasteriesCount DESC, cm.CountryName
