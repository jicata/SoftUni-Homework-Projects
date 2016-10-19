SELECT c.FirstName,
	   c.DateOfBirth,
	   DATEDIFF(YEAR,c.DateOfBirth,'2016-10-01') AS Age
FROM Customers AS c
WHERE DATEDIFF(YEAR,c.DateOfBirth,'2016-10-01') BETWEEN 40 AND 50