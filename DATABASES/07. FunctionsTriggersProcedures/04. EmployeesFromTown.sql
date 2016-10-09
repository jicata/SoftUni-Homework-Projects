
ALTER PROC usp_GetEmployeesFromTown (@TownName AS NVARCHAR(MAX))
AS
BEGIN
	SELECT e.FirstName,
		   e.LastName
	FROM Employees AS e
		INNER JOIN Addresses AS a
			ON e.AddressID = a.AddressID
		INNER JOIN Towns AS t
			ON a.TownID = t.TownID
			AND t.Name = @TownName
END

EXECUTE usp_GetEmployeesFromTown  'Sofia'
