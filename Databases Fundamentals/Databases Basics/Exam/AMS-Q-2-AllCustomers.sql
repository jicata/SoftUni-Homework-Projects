SELECT c.CustomerID,
	   CONCAT(c.FirstName, ' ', c.Lastname) AS FullName,
	   c.Gender
FROM Customers AS c
ORDER BY Fullname, c.CustomerID