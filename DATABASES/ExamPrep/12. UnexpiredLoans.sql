CREATE PROC usp_CustomersWithUnexpiredLoans (@CustomerID AS INT)
AS
BEGIN
	SELECT c.CustomerID,
	   c.FirstName,
	   l.LoanID
	FROM Customers AS c
		INNER JOIN Loans AS l
			ON c.CustomerID = l.CustomerID
	WHERE l.ExpirationDate IS NULL
	AND c.CustomerID = @CustomerID
END




EXEC usp_CustomersWithUnexpiredLoans @CustomerID = 9