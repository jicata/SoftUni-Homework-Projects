SELECT ca.CustomerID,
       ca.Height		
FROM
(SELECT c.CustomerID,
	   c.Height,
	   a.AccountID
FROM Customers AS c
	LEFT JOIN Accounts AS a
		ON c.CustomerID = a.CustomerID) AS ca
WHERE ca.Height BETWEEN 1.74 AND 2.04
AND ca.AccountID IS NULL