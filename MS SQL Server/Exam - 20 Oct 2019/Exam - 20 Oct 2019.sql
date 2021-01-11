CREATE DATABASE [Service]

USE [Service]

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME2,
	Age INT CHECK (Age BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME2,
	Age INT CHECK (Age BETWEEN 18 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status](
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME2 NOT NULL,
	CloseDate DATETIME2,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

INSERT INTO Employees (FirstName, LastName, Birthdate,DepartmentId) 
VALUES
	('Marlo', 'O''Malley', '1958-9-21', 1),
	('Niki', 'Stanaghan', '1969-11-26', 4),
	('Ayrton', 'Senna', '1960-03-21', 9),
	('Ronnie', 'Peterson', '1944-02-14', 9),
	('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports--(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES
	(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
	(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
	(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
	(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

DELETE FROM Reports
WHERE StatusId = 4

SELECT [Description], FORMAT(OpenDate, 'dd-MM-yyyy')
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate, Description

SELECT Description, Name as CategoryName
FROM Reports r
JOIN Categories c ON c.Id = r.CategoryId
WHERE CategoryId IS NOT NULL
ORDER BY [Description], [Name]

SELECT TOP(5) [Name], COUNT(*) AS ReportsNumber 
FROM Reports r
JOIN Categories c ON c.Id = r.CategoryId
GROUP BY CategoryId, [Name]
ORDER BY ReportsNumber DESC, [Name]

SELECT Username, c.[Name]
FROM Users u
JOIN Reports r ON r.UserId = u.Id
JOIN Categories c ON c.Id = r.CategoryId
WHERE DATEPART(DAY, OpenDate) = DATEPART(DAY, Birthdate) AND
	  DATEPART(MONTH, OpenDate) = DATEPART(MONTH, Birthdate)
	  --FORMAT(OpenDate, 'MM-dd') = FORMAT(Birthdate, 'MM-dd')
ORDER BY Username, c.[Name]

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName, COUNT(UserId) AS UsersCount
FROM Employees e
LEFT JOIN Reports r ON r.EmployeeId = e.Id
GROUP BY EmployeeId, e.FirstName, e.LastName
ORDER BY UsersCount DESC, FullName

SELECT 
	--CASE
	--	WHEN e.FirstName IS NULL OR e.LastName IS NULL THEN 'None'
	--	ELSE CONCAT(e.FirstName, ' ', e.LastName) 
	--END AS Employee,
	ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee,
	--CASE 
	--	WHEN d.[Name] IS NULL THEN 'None'
	--	ELSE d.[Name]
	--END AS Department,
	ISNULL(d.[Name], 'None') AS Department,
	c.[Name] AS Category,
	r.[Description],
	FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
	s.[Label] AS [Status],
	ISNULL(u.[Name], 'None') AS [User]
	--CASE
	--	WHEN u.[Name] IS NULL THEN 'None'
	--	ELSE u.[Name]
	--END AS [User]
FROM Reports r 
LEFT JOIN Employees e ON e.Id = r.EmployeeId
LEFT JOIN Departments d ON d.Id = e.DepartmentId
LEFT JOIN Categories c ON c.Id = r.CategoryId
LEFT JOIN [Status] s ON s.Id = r.StatusId
LEFT JOIN Users u ON u.Id = r.UserId
ORDER BY e.FirstName DESC,
		 e.LastName DESC,
		 Department, 
		 Category,
		 [Description],
		 OpenDate, 
		 [Status], 
		 [User]

GO

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF @StartDate IS NULL OR @EndDate IS NULL
	RETURN 0

	RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

GO

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
	DECLARE @reportCategoryId INT = (SELECT CategoryId 
									 FROM Reports
									 WHERE Id = @ReportId)

	DECLARE @reportCategoryDepartmentId INT = (SELECT DepartmentId 
									           FROM Categories
									           WHERE Id = @reportCategoryId)

	DECLARE @employeeDepartmentId INT = (SELECT DepartmentId 
									     FROM Employees
									     WHERE Id = @EmployeeId)

	IF @reportCategoryDepartmentId != @employeeDepartmentId
	THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1

	UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId

EXEC usp_AssignEmployeeToReport 30, 1

EXEC usp_AssignEmployeeToReport 17, 2


 

