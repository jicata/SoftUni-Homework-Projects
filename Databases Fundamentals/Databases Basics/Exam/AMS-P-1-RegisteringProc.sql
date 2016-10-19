CREATE PROC usp_SubmitReview(@CustomerID AS INT, @ReviewContent AS VARCHAR(255), @ReviewGrade INT, @AirlineName VARCHAR(30))
AS
BEGIN
	BEGIN TRAN SubmitReview
	IF(@AirlineName NOT IN (SELECT a.AirlineName FROM Airlines AS a WHERE a.AirlineName = @AirlineName ))
	BEGIN
		RAISERROR('Airline does not exist',16,2)
		ROLLBACK
	END
	ELSE IF(LEN(@ReviewContent) > 255 OR @ReviewGrade < 0 OR @ReviewGrade > 10)
		ROLLBACK
	ELSE
	BEGIN
		DECLARE @AirlineID INT
		SET @AirlineID = (SELECT a.AirlineID FROM Airlines AS a WHERE a.AirlineName = @AirlineName )

		DECLARE @LastReviewID INT
		SET @LastReviewID = (SELECT TOP 1 cr.ReviewID FROM CustomerReviews AS cr ORDER BY cr.ReviewID DESC)

		INSERT INTO CustomerReviews(ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID) VALUES
		(@LastReviewID +1, @ReviewContent, @ReviewGrade, @AirlineID, @CustomerID)
		COMMIT TRAN SubmitReview
	END
END



