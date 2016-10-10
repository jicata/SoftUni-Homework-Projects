ALTER PROC usp_GetHoldersWithBalanceHigherThan(@balance AS INT)
AS
BEGIN
	SELECT m.FirstName AS [FirstName],
		   o.LastName AS [LastName]
	FROM
		(SELECT ah.FirstName,
			   SUM(a.Balance) AS TotalBalance
		FROM AccountHolders AS ah
			INNER JOIN Accounts AS a
				ON ah.Id = a.AccountHolderId
		GROUP BY ah.FirstName) AS m
			INNER JOIN (SELECT ah.FirstName,
							   ah.LastName
					   FROM AccountHolders AS ah) AS o
				ON m.FirstName = o.FirstName
	WHERE m.TotalBalance >= @balance
END

EXEC usp_GetHoldersWithBalanceHigherThan 20
