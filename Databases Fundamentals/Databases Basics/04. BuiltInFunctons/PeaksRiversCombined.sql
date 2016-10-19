USE Geography

SELECT p.PeakName,
	   r.RiverName,
	   LOWER(CONCAT(LEFT(p.PeakName,LEN(p.PeakName)-1),r.RiverName)) AS 'Mix'
FROM Peaks AS p
	 INNER JOIN Rivers AS r
		ON RIGHT(p.PeakName,1) = LEFT(r.RiverName,1)
ORDER BY Mix
