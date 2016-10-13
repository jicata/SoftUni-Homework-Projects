SELECT TOP 5 c.CustomerID,
	   l.Amount
FROM Customers As c
	INNER JOIN Loans AS l
		ON c.CustomerID = l.CustomerID
WHERE l.Amount > (SELECT AverageLoanAmount
					FROM
					(SELECT c.Gender,
							AVG(l.Amount) AS AverageLoanAmount
					FROM Customers AS c
						INNER JOIN Loans AS l
							ON c.CustomerID = l.CustomerID
					WHERE c.Gender = 'M'
					GROUP BY c.Gender) AS con)
ORDER BY c.LastName


