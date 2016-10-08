CREATE TABLE Subjects
(
SubjectID INT PRIMARY KEY,
SubjectName VARCHAR(50)
)

CREATE TABLE Majors
(
MajorID INT PRIMARY KEY,
Name VARCHAR(50)
)

CREATE TABLE Students
(
StudentID INT PRIMARY KEY,
StudentNumber INT,
StudentName VARCHAR(50),
MajorID INT CONSTRAINT FK_StudentsMajors FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Agenda
(
StudentID INT,
SubjectID INT,
PRIMARY KEY(StudentID, SubjectID),
CONSTRAINT FK_Agenda_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID), 
CONSTRAINT FK_Agenda_Subjects FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID)
)

CREATE TABLE Payments
(
PaymentID INT PRIMARY KEY,
PaymentDate DATE,
PaymentAmount DECIMAL(19,4),
StudentID INT CONSTRAINT FK_Payments_Students FOREIGN KEY REFERENCES Students(StudentID)
)



