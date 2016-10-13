CREATE TRIGGER trg_AfterInsertInEmployees
ON Employees
AFTER INSERT
AS
BEGIN
	DECLARE @PreviousEmployeeId AS INT
	DECLARE @PreviousEmployeeLoanID AS INT
	SET @PreviousEmployeeId = (SELECT i.EmployeeID
							   FROM inserted AS i) - 1
	SET @PreviousEmployeeLoanID = (SELECT DISTINCT el.LoanID
								   FROM Employees AS e
										INNER JOIN EmployeesLoans AS el
											ON el.EmployeeID = @PreviousEmployeeId)
	INSERT INTO  EmployeesLoans(EmployeeID, LoanID)
	VALUES (@PreviousEmployeeId+1, @PreviousEmployeeLoanID)
END

INSERT INTO Employees(EmployeeID,FirstName, HireDate, Salary, BranchID) 
VALUES (31, 'Jake', '2016-12-12', 500, 2)