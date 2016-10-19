ALTER PROC usp_PurchaseTicket(@CustomerID AS INT, @FlightID AS INT, @TicketPrice AS DECIMAL(8,2), @Class AS VARCHAR(6), @Seat AS VARCHAR(5))
AS
BEGIN
	BEGIN TRAN PurchaseTicket
	DECLARE @CurrentBalance AS DECIMAL(10,2)
	SET @CurrentBalance = (SELECT cba.Balance FROM CustomerBankAccounts AS cba WHERE cba.CustomerID = @CustomerID)
	IF(@TicketPrice > @CurrentBalance)
	BEGIN
		RAISERROR('Insufficient bank account balance for ticket purchase.',16,2)
		ROLLBACK
	END
	ELSE
	BEGIN
		DECLARE @LastTicketID INT
		SET @LastTicketID = (SELECT TOP 1 t.TickedID FROM Tickets AS t ORDER BY t.TickedID DESC)
		INSERT INTO Tickets(TickedID, Price, Class, Seat, CustomerID, FlightID) VALUES
		(@LastTicketID +1, @TicketPrice, @Class, @Seat, @CustomerID, @FlightID)

		UPDATE CustomerBankAccounts
		SET Balance -= @TicketPrice
		WHERE CustomerID = @CustomerID

		COMMIT TRAN PurchaseTicket
	END
END

EXEC usp_PurchaseTicket 1, 5, 300.00, 'First', '24-A'