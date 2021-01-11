USE [Geography]

SELECT MountainRange, PeakName, Elevation
FROM Mountains
JOIN Peaks ON Peaks.MountainId = Mountains.Id
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC

CREATE DATABASE ExerciseDB

USE ExerciseDB

-- P01 --

CREATE TABLE Passports(
PassportID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
PassportNumber CHAR(8) NOT NULL
)

INSERT INTO Passports(PassportNumber)
VALUES
	('N34FG21B'),
	('K65LO4R7'),
	('ZE657QP2')

CREATE TABLE Persons(
PersonID INT PRIMARY KEY IDENTITY NOT NULL,
FirstName VARCHAR(50) NOT NULL,
Salary DECIMAL(8, 2) NOT NULL,
PassportID INT FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE
)

INSERT INTO Persons(FirstName, Salary, PassportID)
	VALUES
	('Roberto', 43.300, 102),
	('Tom', 56.100, 103),
	('Yana', 60.200, 101)

ALTER TABLE Persons
	DROP CONSTRAINT [PK__Persons__AA2FFB8563CA5E24]

ALTER TABLE Persons
ADD CONSTRAINT PK_PersonID
	PRIMARY KEY(PersonID)

-- P02 --

CREATE TABLE Models(
ModelID INT NOT NULL,
[Name] VARCHAR(50) NOT NULL,
ManufacturerID INT NOT NULL
)

INSERT INTO Models(ModelID, [Name], ManufacturerID)
	VALUES
	(101, 'X1', 1),
	(102, 'i6', 1),
	(103, 'Model S', 2),
	(104, 'Model X', 2),
	(105, 'Model 3', 2),
	(106, 'Nova', 3)

CREATE TABLE Manufacturers(
ManufacturerID INT NOT NULL,
[Name] VARCHAR(50) NOT NULL,
EstablishedOn DATE NOT NULL
)

INSERT INTO Manufacturers(ManufacturerID, [Name], EstablishedOn)
	VALUES
	(1, 'BMW', '07/03/1916'),
	(2, 'Tesla', '01/01/2003'),
	(3, 'Lada', '01/05/1966')

ALTER TABLE Models
	ADD CONSTRAINT PK_ModelID
	PRIMARY KEY(ModelID)

ALTER TABLE Manufacturers
	ADD CONSTRAINT PK_ManufacturerID
	PRIMARY KEY(ManufacturerID)

ALTER TABLE Models
	ADD CONSTRAINT FK_ManufacturerID
	FOREIGN KEY(ManufacturerID)
	REFERENCES Manufacturers(ManufacturerID)


-------------------------------------
DROP TABLE Models
DROP TABLE Manufacturers

CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL,
EstablishedOn DATE NOT NULL
)

INSERT INTO Manufacturers([Name], EstablishedOn)
	VALUES
	('BMW', '07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966')

	CREATE TABLE Models(
ModelID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL,
ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID) NOT NULL
)

INSERT INTO Models([Name], ManufacturerID)
	VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3)

-- P03 --

CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(80) NOT NULL
)

INSERT INTO Students([Name])
	VALUES
	('Mila'),
	('Toni'),
	('Ron')

CREATE TABLE Exams(
ExamID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
[Name] VARCHAR(80) NOT NULL
)

INSERT INTO Exams([Name])
	VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')
	 
CREATE TABLE StudentsExams(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID) NOT NULL,
	PRIMARY KEY(StudentID, ExamID)
)

-- OR --
CREATE TABLE StudentsExams(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL,
	CONSTRAINT PK_StudentsExams
	PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_StudentsExams_Students
	FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_StudentsExams_Exams
	FOREIGN KEY(ExamID) REFERENCES Exams(ExamID)


INSERT INTO StudentsExams(StudentID, ExamID)
	VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)

-- P04 --

CREATE TABLE Teachers(
TeacherID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
[Name] VARCHAR(50) NOT NULL,
ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers([Name], ManagerID)
	VALUES
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),
	('Greta', 101)

-- P09 --

SELECT MountainRange, PeakName, Elevation
FROM Mountains AS m
JOIN Peaks AS p ON m.Id = p.MountainID
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC

-- P05 --

CREATE DATABASE OnlineStore
USE OnlineStore

CREATE TABLE Cities(
CityID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL,
Birthday DATE,
CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
OrderID INT PRIMARY KEY IDENTITY NOT NULL,
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes(
ItemTypeID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items(
ItemID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL,
ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems(
OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
PRIMARY KEY(OrderID, ItemID),
)

/*CREATE TABLE OrderItems(
OrderID INT,
ItemID INT,
CONSTRAINT PK_OrderItems
PRIMARY KEY(OrderID, ItemID),
CONSTRAINT FK_OrderItems_Orders 
FOREIGN KEY(OrderID)  REFERENCES Orders(OrderID),
CONSTRAINT FK_OrderItems_Items 
FOREIGN KEY(ItemID) REFERENCES Items(ItemID)
)*/

-- P06 --

CREATE DATABASE University
USE University

CREATE TABLE Majors(
MajorID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY NOT NULL,
StudentNumber VARCHAR(20) NOT NULL,
StudentName VARCHAR(80) NOT NULL,
MajorID INT FOREIGN KEY REFERENCES Majors(MajorID) NOT NULL
)

CREATE TABLE Payments(
PaymentID INT PRIMARY KEY IDENTITY NOT NULL,
PaymentDate DATE NOT NULL,
PaymentAmount DECIMAL(6, 2) NOT NULL,
StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL
)

CREATE TABLE Subjects(
SubjectID INT PRIMARY KEY IDENTITY NOT NULL,
SubjectName VARCHAR(80) NOT NULL
)

CREATE TABLE Agenda(
StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
PRIMARY KEY(StudentID, SubjectID)
)

/*CREATE TABLE Agenda(
StudentID INT,
SubjectID INT,
CONSTRAINT PK_Agenda
PRIMARY KEY(StudentID, SubjectID),
CONSTRAINT FK_Agenda_Students
FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
CONSTRAINT FK_Agenda_Subjects
FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID)
)*/
