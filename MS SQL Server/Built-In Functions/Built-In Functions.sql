/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [CustomerID]
      ,[FirstName]
      ,[LastName]
      ,CONCAT(LEFT(PaymentNumber, 6),  REPLICATE('*', 10)) AS [PaymentNumber]
  FROM [Demo].[dbo].[Customers]

	-- P01 --

 SELECT FirstName, LastName
	FROM Employees
	WHERE FirstName LIKE 'SA%'

	-- P02 --

 SELECT FirstName, LastName
	FROM Employees
	WHERE LastName LIKE '%ei%'

	--P03--

SELECT FirstName
	FROM Employees
	WHERE (DepartmentID = 3 OR DepartmentID = 10) AND (YEAR(HireDate) BETWEEN 1995 AND 2005)

SELECT FirstName
	FROM Employees
	WHERE DepartmentID IN (3, 10) AND 
		(DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005)

	--P04--
	
SELECT FirstName, LastName 
	FROM Employees
	WHERE JobTitle NOT LIKE ('%engineer%')

SELECT FirstName, LastName 
	FROM Employees
	WHERE CHARINDEX('engineer', JobTitle) = 0

	--P05--

--Write a SQL query to find town names that are 5 or 6 symbols long and order them alphabetically by town name. 

SELECT [Name] 
	FROM Towns
	WHERE LEN([Name]) IN (5, 6)
	ORDER BY [Name]

	--P06--

	SELECT * FROM TOWNS
	WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
	ORDER BY [Name] ASC

SELECT * FROM TOWNS
	WHERE [Name] LIKE '[MKBE]%'
	ORDER BY [Name] ASC
	
SELECT * FROM TOWNS
	WHERE SUBSTRING([Name], 1, 1) IN ('M', 'K', 'B', 'E')
	ORDER BY [Name] ASC

	--P07--

--Write a SQL query to find all towns that does not start with letters R, B or D. Order them alphabetically by name. 

SELECT * FROM Towns
	WHERE LEFT([Name], 1) NOT IN ('R','B', 'D')
	ORDER BY [Name] ASC

SELECT * FROM Towns
	WHERE SUBSTRING([Name], 1, 1) NOT IN ('R', 'B', 'D')
	ORDER BY [Name] ASC

SELECT * FROM Towns
	WHERE [Name] LIKE '[^RBD]%'
	ORDER BY [Name] ASC

	--P08--

--Write a SQL query to create view V_EmployeesHiredAfter2000 with first and last name to all employees hired after 2000 year. 
 
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
	WHERE YEAR(HireDate) > 2000

	--P09--

--Write a SQL query to find the names of all employees whose last name is exactly 5 characters long.

SELECT FirstName, LastName FROM Employees
	WHERE LEN(LastName) = 5

	--P10--

	/*Write a query that ranks all employees using DENSE_RANK. 
	In the DENSE_RANK function, employees need to be partitioned by Salary 
	and ordered by EmployeeID. 
	You need to find only the employees whose Salary is between 10000 and 50000 
	and order them by Salary in descending order.*/

SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000 
	ORDER BY Salary DESC

	--P11--

SELECT * FROM (
SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000) AS TempResults
WHERE [Rank] = 2
ORDER BY Salary DESC

	--P12--

SELECT CountryName, IsoCode FROM Countries
	WHERE CountryName LIKE '%A%A%A%'
	ORDER BY IsoCode

	--P13--

SELECT PeakName, RiverName, LOWER(CONCAT(LEFT(PeakName, (LEN(PeakName) - 1)), RiverName)) AS Mix
	FROM Peaks
	JOIN Rivers ON RIGHT(PeakName, 1) = LEFT(RiverName, 1) 
	ORDER BY Mix

SELECT PeakName, RiverName, LOWER(CONCAT(p.PeakName, SUBSTRING(r.RiverName, 2, LEN(r.RiverName) - 1))) AS Mix
	FROM Peaks AS p, Rivers AS r
	WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1) 
	ORDER BY Mix


	--P14--

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start] FROM Games
	WHERE YEAR([Start]) IN (2011, 2012)
	ORDER BY [Start], [Name]

	--P15--

SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
	FROM Users
	ORDER BY [Email Provider], Username

	--P16--

SELECT Username, IpAddress AS [IP Address] FROM Users
	WHERE IpAddress LIKE '___.1_%._%.___'
	ORDER BY Username
	
	--P17--

SELECT [Name],
	CASE
		WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		ELSE 'Evening'
	END AS [Part of the Day],
	CASE 
		WHEN DURATION <= 3 THEN 'Extra Short'
		WHEN DURATION BETWEEN 4 AND 6 THEN 'Short'
		WHEN DURATION > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS Duration
	FROM Games
	ORDER BY [Name], Duration, [Part of the Day]

	--P18--

	SELECT ProductName, OrderDate, DATEADD(DAY, 3, OrderDate) AS [Pay Due], DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
	FROM ORDERS

	--P19--

CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	Birthdate DATETIME2 NOT NULL
	)

INSERT INTO People([Name], Birthdate)
	VALUES
	('Victor', '2000-12-07'),
	('Steven', '1992-09-10'),
	('Stephen', '1910-09-19'),
	('John', '2010-01-06')

SELECT [Name], 
	DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
	DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
	DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE, Birthdate, GETDATE())  AS [Age in Minutes]
	FROM People











	
