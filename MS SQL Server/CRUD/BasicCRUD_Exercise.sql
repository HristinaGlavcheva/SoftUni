USE SoftUni

SELECT DepartmentID, [Name]
FROM Departments

SELECT e.EmployeeID AS ID, e.FirstName, e.LastName AS FamilyName
FROM Employees AS e

SELECT FirstName + ' ' + LastName AS FullName, EmployeeID AS [No.]
FROM Employees

SELECT FirstName + ' ' + LastName AS [FullName], JobTitle, Salary
FROM Employees

SELECT DISTINCT DepartmentID
FROM Employees

SELECT LastName, Salary, ManagerID
FROM Employees
WHERE ManagerID IS NOT NULL

-- P02 --

SELECT * FROM Departments

-- P03 --

SELECT [Name] 
FROM Departments

-- P04 --

SELECT FirstName, LastName, Salary
FROM Employees

-- P05 --

SELECT FirstName, MiddleName, LastName
FROM Employees

-- P06 --

SELECT 
	FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address]
FROM Employees

-- P07 --

SELECT DISTINCT Salary
FROM Employees

-- P08 --

SELECT *
FROM Employees
WHERE JobTitle = 'Sales Representative'

-- P09 --

SELECT FirstName, LastName, JobTitle
FROM Employees
WHERE Salary >= 20000 AND Salary <= 30000

-- P10 --

SELECT	FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
-- или, за да избегнем двойния спейс при хора без второ име:
	-- SELECT CONCAT(FirstName, ' ', MiddleName + ' ', LastName) AS [Full Name]
	-- NULL + ' ' връща ''
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

-- P11 --

SELECT FirstName, LastName
FROM Employees
WHERE ManagerID IS NULL

-- P12 --

SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

-- P13 --

SELECT TOP (5) FirstName, LastName
FROM Employees
ORDER BY Salary DESC
-- OFFSET 5 ROWS - ако искаме да скипнем първите 5
-- FETCH NEXT 10 ROWS ONLY - ако искаме да изберем само следващите 10

-- P14 --

SELECT FirstName, LastName
FROM Employees
WHERE DepartmentID != 4

-- P15 --

SELECT *
FROM Employees
ORDER BY 
	Salary DESC, 
	FirstName,
	LastName DESC,
	MiddleName

-- P16 --

CREATE VIEW V_EmployeesSalaries
AS
SELECT FirstName, LastName, Salary
FROM Employees


-- P17 --

CREATE VIEW V_EmployeeNameJobTitle
AS
SELECT 
	CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name], JobTitle
	-- или за да замести MiddleName с '' при стойност NULL може да използваме вградената функция
	-- ISNULL(MiddleName, '')
FROM Employees

-- P18 --

SELECT DISTINCT JobTitle
FROM Employees

-- P19 --

SELECT TOP(10) *
FROM Projects
ORDER BY StartDate, [Name]

-- 20 --

SELECT TOP(7) FirstName, LastName, HireDate
FROM Employees
ORDER BY HireDate DESC

-- P21 --

UPDATE Employees
SET Salary *= 1.12
WHERE DepartmentID IN (1, 2, 4, 11)

SELECT Salary
FROM Employees

UPDATE Employees
SET Salary /= 1.12
WHERE DepartmentID IN (1, 2, 4, 11)

-- P22 --

SELECT PeakName
FROM Peaks
ORDER BY PeakName

-- P23 --

SELECT TOP(30) CountryName, [Population]
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC, CountryName

-- P24 --

SELECT CountryName, CountryCode, 
CASE
	WHEN CurrencyCode = 'EUR' THEN 'Euro'
	ELSE 'Not Euro'
	END AS Currency
FROM Countries
ORDER BY CountryName

-- P25 --
USE Diablo

SELECT [Name]
FROM Characters
ORDER BY [Name]






