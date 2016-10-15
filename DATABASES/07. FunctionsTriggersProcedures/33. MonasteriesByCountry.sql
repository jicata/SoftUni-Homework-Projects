CREATE TABLE Monasteries
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(50),
CountryCode CHAR(2) CONSTRAINT FK_Monasteries_Countries FOREIGN KEY REFERENCES Countries(CountryCode)
)

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')


ALTER TABLE Countries
ADD IsDeleted BIT NOT NULL DEFAULT 0



UPDATE Countries
SET IsDeleted = 1
WHERE CountryName IN (SELECT cr.CountryName
						FROM
						(SELECT c.CountryName,
								COUNT(cr.RiverId) AS RiverCount
						FROM Countries AS c
							INNER JOIN CountriesRivers AS cr
								ON c.CountryCode = cr.CountryCode
						GROUP BY c.CountryName
						HAVING COUNT(cr.RiverId) > 3) AS cr)


SELECT m.Name,
	   c.CountryName
FROM Monasteries AS m
	INNER JOIN Countries AS c
		ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted != 1
ORDER BY m.Name



