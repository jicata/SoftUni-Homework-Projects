ALTER PROC usp_GetHoldersWithBalanceHigherThan(@balance AS Money)
AS
BEGIN
	SELECT fi.FirstName AS [FirstName],
		   fi.LastName AS [LastName]
	FROM
		(SELECT ah.FirstName,
				ah.LastName,
			    SUM(a.Balance) AS TotalBalance
		FROM AccountHolders AS ah
			INNER JOIN Accounts AS a
				ON ah.Id = a.AccountHolderId
		GROUP BY ah.FirstName, ah.LastName) AS fi
	WHERE fi.TotalBalance > @balance
END

EXEC usp_GetHoldersWithBalanceHigherThan 4
