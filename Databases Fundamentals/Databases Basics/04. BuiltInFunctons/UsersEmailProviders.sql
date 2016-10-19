USE Diablo

SELECT u.Username,
	   SUBSTRING(u.Email,CHARINDEX('@',u.Email,1)+1, (LEN(u.Email) - CHARINDEX('@', u.Email,1))) AS [Email Provider]
FROM Users AS u
ORDER BY [Email Provider],
	     u.Username
