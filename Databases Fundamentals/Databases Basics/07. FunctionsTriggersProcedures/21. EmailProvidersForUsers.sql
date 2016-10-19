SELECT p.[Email Provider],
	   COUNT(*) AS [Number Of Users]
FROM
(SELECT SUBSTRING(u.Email, CHARINDEX('@',u.Email,0)+1,LEN(u.Email)) AS [Email Provider]
FROM Users AS u) AS p
GROUP BY p.[Email Provider]
ORDER BY [Number Of Users] DESC, p.[Email Provider]
