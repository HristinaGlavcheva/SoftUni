-- P01 - P07 --

CREATE DATABASE Minions

USE Minions

CREATE TABLE Minions(
	Id INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Age TINYINT
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

INSERT INTO Towns(Id, [Name])
	VALUES
		   (1, 'Sofia'),
		   (2, 'Plovdiv'),
		   (3, 'Varna')

INSERT INTO Minions(Id, [Name], Age, TownId)
	VALUES
		   (1, 'Kevin', 22, 1),
		   (2, 'Bob', 15, 3),
		   (3, 'Steward', NULL, 2)

SELECT * FROM Minions
SELECT * FROM Towns

TRUNCATE TABLE Minions

DROP TABLE Minions
DROP TABLE Towns

-- P08 - P12 --

CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL ,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX)
		CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
VALUES
('Hristina', 'Tina123', '05.16.2020', 0),
('Georgi', 'Joreto123', '05.25.2020', 0),
('Chudomir', 'Chocko123', '05.22.2020', 0),
('Nikolina', 'Jinjer123', '03.16.2020', 0),
('Somebody', 'Whatever123', '01.20.2015', 1)

SELECT * FROM Users

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC0758CA2303]

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername
	PRIMARY KEY(Id, Username)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLength
	CHECK(LEN([Password]) >= 5)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
VALUES
('HristinaG', 'TinaTina', '05.16.2020', 0)

Select * FROM Users

DELETE FROM Users 
	WHERE Username = 'HristinaG';

ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users(Username, [Password],IsDeleted)
VALUES
('HristinaG', 'TinaTina', 0)

ALTER TABLE Users
DROP CONSTRAINT [PK_Users_CompositeIdUsername]

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_UsernameLength
CHECK(LEN(Username) >= 3)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
VALUES
('Hr', 'Tina123', '05.16.2020', 0)

-- P16 --

CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	AddressText NVARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(30) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(7, 2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Towns([Name])
	VALUES
		('Sofia'),
		('Plovdiv'),
		('Varna'),
		('Burgas')

SELECT * FROM Towns

INSERT INTO Departments([Name])
	VALUES
		('Engineering'),
		('Sales'),
		('Marketing'),
		('Software Development'),
		('Quality Assurance')

SELECT * FROM Employees

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
	VALUES
		('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02/01/2013', 3500.00),
		('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '03/02/2004', 4000.00),
		('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08/28/2016', 525.25),
		('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '12/09/2007', 3000.00),
		('Peter', 'Pan', 'Pan', 'Intern', 3, '08/28/2016', 599.88)

-- (SELECT TOP 1 [Name] FROM Departments WHERE Id = 4)

-- P19 --

SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

-- P20 --

SELECT * FROM Towns
	ORDER BY [Name]

SELECT * FROM Departments
	ORDER BY [Name]

SELECT * FROM Employees
	ORDER BY Salary DESC

-- P21 --

SELECT [Name] FROM Towns
ORDER BY [Name]

SELECT [Name] FROM Departments
ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

-- P22 --

UPDATE Employees
SET Salary = Salary * 1.1

SELECT Salary FROM Employees

-- P07 --

USE Minions

CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX)
		CHECK (DATALENGTH(Picture) <= 2 * 1024 * 1024),	
	Height DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	Gender CHAR(1) NOT NULL
		CHECK(Gender = 'm' OR Gender = 'f'),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People([Name], Height, [Weight], Gender, Birthdate, Biography)
	VALUES
		('Hristina', 1.62, 52.00, 'f', '08/13/1981', 'My biography'),
		('Georgi', 1.80, 78.00, 'm', '03/07/1978', 'George biography'),
		('Chudomir', 0.96, 14.00, 'm', '04/12/2017', 'Chudomir biography'),
		('Jinger', 1.62, 50.00, 'f', '07/14/1979', 'Jinger biography'),
		('Daria', 0.52, 3.20, 'f', '03/13/2021', 'Dari biography')

SELECT * FROM People

-- P15 --

CREATE DATABASE Hotel 

USE Hotel

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Title NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title)
	VALUES
		('Ivan', 'Petrov', 'Manager'),
		('Todor', 'Nestorov', 'Receptionist'),
		('Verginia', 'Paskova', 'Waiter')

CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	PhoneNumber NVARCHAR(20) NOT NULL,
	EmergencyName NVARCHAR(50) NOT NULL,
	EmergencyNumber NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers(FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
	VALUES
			('Zahari', 'Petrakiev', '+359 898 555 999', 'Viara Nacheva', '+359 899 564 856'),
			('Valio', 'Zanev', '+359 896 565 458', 'Georgi Dragnev', '+359 899 425 458'),
			('Zhenia', 'Ganeva', '+359 898 656 454', 'Fori Monev', '+359 899 856 321')

CREATE TABLE RoomStatus(
	RoomStatus VARCHAR(40) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

/*ALTER TABLE RoomStatus
ADD CONSTRAINT PK_RoomStatus_RoomStatus
PRIMARY KEY(RoomStatus)*/

INSERT INTO RoomStatus (RoomStatus)
	VALUES
		('Occupied'),
		('Vacant'),
		('Out of Order')

CREATE TABLE RoomTypes(
	RoomType VARCHAR(40) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

/*ALTER TABLE RoomTypes
ADD CONSTRAINT PK_RoomTypes_RoomType
PRIMARY KEY(RoomType)*/

INSERT INTO RoomTypes (RoomType)
	VALUES
		('Double'),
		('Studio'),
		('Suite')

CREATE TABLE BedTypes(
	BedType VARCHAR(20) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

/*ALTER TABLE BedTypes
ADD CONSTRAINT PK_BedTypes_BedType
PRIMARY KEY(BedType)*/

INSERT INTO BedTypes (BedType)
	VALUES
		('Single'),
		('Double'),
		('Kingsize')

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY NOT NULL,
	RoomType VARCHAR(40) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
	BedType VARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
	Rate DECIMAL(5, 2) NOT NULL,
	RoomStatus VARCHAR(40) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus)
	VALUES
		(101, 'Double', 'Double', 80.00, 'Vacant'),
		(203, 'Studio', 'Single', 120.00, 'Vacant'),
		(410, 'Suite', 'Kingsize', 150.00, 'Occupied')

CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY NOT NULL, 
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
PaymentDate DATE, 
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
FirstDateOccupied DATE,
LastDateOccupied DATE, 
TotalDays AS DATEDIFF(DAY, LastDateOccupied, FirstDateOccupied), 
AmountCharged DECIMAL(8, 2), 
TaxRate DECIMAL(6, 2), 
TaxAmount DECIMAL(6, 2),
PaymentTotal DECIMAL(8, 2),
Notes NVARCHAR(MAX)
)

INSERT INTO Payments (EmployeeId, PaymentDate, AmountCharged)
VALUES
(1, '12/10/2019', 600.40),
(2, '12/12/2019', 740.60),
(3, '12/16/2019', 500.20)

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATE, 
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber), 
	RateApplied DECIMAL(5, 2), 
	PhoneCharge DECIMAL(5, 2), 
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies (EmployeeId, RateApplied) 
	VALUES
	(1, 80.00),
	(2, 100.00),
	(3, 120.00)

UPDATE Payments
	SET TaxRate *= 0.97

SELECT TaxRate FROM Payments

TRUNCATE TABLE Occupancies

-- P13 --

CREATE DATABASE Movies 

USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DirectorName NVARCHAR(80) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName)
	VALUES
	('Ivan Petrov'),
	('Petar Ivanov'),
	('Georgi Dimitrov'),
	('Dimityr Peshev'),
	('Zornica Karambasheva')

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY NOT NULL, 
	GenreName VARCHAR(50) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Genres(GenreName)
	VALUES
	('Action'),
	('Adventure'),
	('Comedy'),
	('Crime'),
	('Romance')

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName VARCHAR(50) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories(CategoryName)
	VALUES
	('Documentary'),
	('Serial'),
	('Kids'),
	('Animated'),
	('biography')

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY NOT NULL, 
	Title NVARCHAR(300) NOT NULL, 
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear INT NOT NULL, 
	[Length] TIME NOT NULL, 
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL, 
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL, 
	Rating INT NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating)
	VALUES
	('Movie1', 1, 1974, '2:54', 3, 4, 8),
	('Movie2', 5, 1989, '3:45', 2, 4, 10),
	('Movie3', 4, 2020, '1:30', 1, 5, 9),
	('Movie4', 3, 2008, '2:43', 2, 3, 7),
	('Movie5', 2, 2016, '1:35', 4, 1, 6)

-- P14--

CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY NOT NULL, 
	CategoryName VARCHAR(80) NOT NULL,
	DailyRate DECIMAL(6, 2) NOT NULL,
	WeeklyRate DECIMAL(8, 2) NOT NULL,
	MonthlyRate DECIMAL(8, 2) NOT NULL,
	WeekendRate DECIMAL(8, 2) NOT NULL
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
	VALUES
	('Category1', 30.00, 180.00, 700.00, 50.00),
	('Category2', 50.00, 320.00, 1300.00, 80.00),
	('Category3', 100.00, 650.00, 2600.00, 180.00)

CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	PlateNumber NVARCHAR(10) NOT NULL,
	Manufacturer NVARCHAR(50) NOT NULL,
	Model NVARCHAR(50) NOT NULL, 
	CarYear INT NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL, 
	Doors INT NOT NULL,
	Picture VARBINARY(MAX),
	Condition VARCHAR(200) NOT NULL,
	Available BIT NOT NULL
) 

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Condition, Available)
	VALUES
	('A 4856 HA', 'Reanault', 'Modus', 2005, 1, 5, 'Good', 1),
	('B 8547 BB', 'Subary', 'Legacy', 1998, 3, 5, 'Excellent', 0),
	('Y 8966 AB', 'Daewoo', 'Nubira', 1994, 2, 3, 'Good', 1)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL, 
	FirstName NVARCHAR(80) NOT NULL, 
	LastName NVARCHAR(80) NOT NULL,  
	Title NVARCHAR(80) NOT NULL,  
	Notes NVARCHAR(MAX) 
) 

INSERT INTO Employees(FirstName, LastName, Title)
	VALUES
	('Ivan', 'Ivanov', 'Manager'),
	('Petar', 'Petrov', 'Salesman'),
	('Chavdar', 'Zhekov', 'Salesman')

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY NOT NULL, 
	DriverLicenceNumber NVARCHAR(30) NOT NULL,
	FullName NVARCHAR(200) NOT NULL, 
	[Address] NVARCHAR(200) NOT NULL,
	City NVARCHAR(80) NOT NULL,
	ZIPCode NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode)
	VALUES
	('123456789', 'Petar Atanasov', 'Varna, ul. Nezabravka', 'Varna', '9000'),
	('595654954', 'Angel Filipov', 'Varna, ul. Sinchec', 'Varna', '9000'),
	('654984154', 'Zhivomir Yalamov', 'Varna, ul. Kokiche', 'Varna', '9000')

CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY IDENTITY NOT NULL, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL, 
	TankLevel DECIMAL(5, 2) NOT NULL, 
	KilometrageStart INT NOT NULL, 
	KilometrageEnd INT NOT NULL, 
	TotalKilometrage AS (KilometrageEnd - KilometrageStart),
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL, 
	TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
	RateApplied VARCHAR(20) NOT NULL,
	TaxRate DECIMAL(8, 2) NOT NULL, 
	OrderStatus VARCHAR(20) NOT NULL, 
	Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate, RateApplied, TaxRate, OrderStatus)
	VALUES
	(1, 2, 3, 20.70, 100564, 101600, '08/13/2019', '08/20/2019', 'WeeklyRate', 1300.00, 'Closed'),
	(2, 1, 2, 16.80, 150602, 151200, '08/13/2019', '08/14/2019', 'DailyRate', 100.00, 'Closed'),
	(3, 3, 1, 55.60, 100564, 80400, '08/13/2019', '09/13/2019', 'MonthlyRate', 2600.00, 'Closed')