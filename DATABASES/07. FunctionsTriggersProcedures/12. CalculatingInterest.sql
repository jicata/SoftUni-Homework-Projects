ALTER PROCEDURE usp_CalculateFutureValueForAccount(@AccountId AS INT)
AS
BEGIN
	SELECT fi.[Account Id],
		   fi.FirstName,
		   fi.LastName,
		   fi.Balance AS [Current Balance],
		   fv.[Balance In 5 Years]
	FROM
		(SELECT a.Id AS [Account Id],
			    ah.FirstName,
			    ah.LastName,
			    a.Balance
		FROM AccountHolders AS ah
			INNER JOIN Accounts AS a
				ON ah.Id = a.AccountHolderId) AS fi
		INNER JOIN (SELECT  tb.FirstName,
							dbo.ufn_CalculateFutureValue(tb.Balance, 0.1, 5) AS [Balance In 5 Years]
					FROM
						(SELECT a.Id AS [Account Id],
								ah.FirstName,
								ah.LastName,
								a.Balance
						 FROM AccountHolders AS ah
								INNER JOIN Accounts AS a
									ON ah.Id = a.AccountHolderId) AS tb ) AS fv
			ON fv.FirstName = fi.FirstName
WHERE fi.[Account Id] = @AccountId	
END


EXEC usp_CalculateFutureValueForAccount 2

