CREATE TABLE CustomerReviews
(
ReviewID INT PRIMARY KEY,
ReviewContent VARCHAR(255) NOT NULL,
ReviewGrade INT CHECK (ReviewGrade >= 0 AND ReviewGrade <= 10),
AirlineID INT CONSTRAINT FK_CustomerReview_Airlines FOREIGN KEY REFERENCES Airlines(AirlineID),
CustomerID INT CONSTRAINT FK_CustomerReview_Customers FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE CustomerBankAccounts
(
AccountID INT PRIMARY KEY,
AccountNumber VARCHAR(10) NOT NULL CONSTRAINT UQ_CBA UNIQUE,
Balance DECIMAL(10,2) NOT NULL,
CustomerID INT CONSTRAINT FK_CustomerBankAccounts_Customers FOREIGN KEY REFERENCES Customers(CustomerID)
)