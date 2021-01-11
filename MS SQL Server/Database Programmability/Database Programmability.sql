-- Scalar Function -- returns single value

-- Създаване --

CREATE OR ALTER FUNCTION udf_ProjectDurationInWeeks (@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF @EndDate IS NULL
	SET @EndDate = GETDATE()
	RETURN DATEDIFF(WEEK, @StartDate, @EndDate)
END

-- Извикване --

SELECT StartDate, EndDate, [dbo].[udf_ProjectDurationInWeeks](StartDate, EndDate) AS DurationInWeeks
FROM Projects

-- Table Valued Function (TVF)- Inline TVF -- returns a table - inline TVF

-- Създаване --

CREATE FUNCTION udf_AverageSalaryByDepartment()
RETURNS TABLE
AS
RETURN
(
	SELECT d.Name AS Department, AVG(Salary) AS AverageSalary 
	FROM Departments d 
	JOIN Employees e ON e.DepartmentID = d.DepartmentID
	GROUP BY d.DepartmentID, d.Name
)

-- Извикване --

SELECT * FROM udf_AverageSalaryByDepartment()

-- Multi-statement table Valued Function (MSTVF) -- returns a table 

--Създаване--

CREATE FUNCTION udf_EmployeeListByDepartment(@DeptName NVARCHAR(20))
RETURNS @employeeList TABLE(
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	DepartmentName NVARCHAR(20) NOT NULL
)
AS
BEGIN
	WITH Employees_CTE (FirstName, LastName, DepartmentName)
	AS(
		SELECT e.FirstName, e.LastName, d.[Name]
		FROM Employees e
		LEFT JOIN Departments d ON d.DepartmentID = e.DepartmentID)

	INSERT INTO @employeeList SELECT FirstName, LastName, DepartmentName
	FROM Employees_CTE WHERE DepartmentName = @DeptName
	RETURN
END

-- Извикване --

SELECT * FROM udf_EmployeeListByDepartment('Production')

-------------------------------------------------------
CREATE FUNCTION udf_SalaryLevelFunction(@Salary MONEY)
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @Level NVARCHAR(10);

	IF @Salary < 30000 
	SET @Level = 'Low'
	ELSE IF @Salary <= 50000
	SET @Level = 'Average'
	ELSE 
	SET @Level = 'High'

	RETURN @Level
END

SELECT FirstName,
		dbo.udf_SalaryLevelFunction(Salary) AS SalaryLevel
FROM Employees


	--P07--
GO 

CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @isComprised BIT = 1;
	DECLARE @i INT = 1;

	WHILE(@i <= LEN(@word))
		BEGIN
			DECLARE @currentLetter VARCHAR = SUBSTRING(@word, @i, 1);
			IF CHARINDEX(@currentLetter, @setOfLetters) <= 0
				BEGIN
				SET @isComprised = 0;
				BREAK;
				END;

			SET @i = @i + 1; 
		END
		
	RETURN @isComprised;
END

GO

CREATE OR ALTER FUNCTION ufn_IsWordComprised1(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @i INT = 1;
	DECLARE @currentLetter CHAR;
		
	WHILE(@i <= LEN(@word))
		BEGIN
			SET @currentLetter = SUBSTRING(@word, @i, 1)

			DECLARE @isComprised INT = CHARINDEX(@currentLetter, @setOfLetters)
						
			IF  @isComprised <= 0
				BEGIN
				RETURN 0;
				END
		
			SET @i = @i + 1; 
		END
		
	RETURN 1;
END

CREATE FUNCTION ufn_IsWordComprised4(@setOfLetters VARCHAR (50), @word VARCHAR (50)) 
RETURNS BIT
AS
BEGIN
     DECLARE @index INT = 1
     DECLARE @length INT = LEN(@word)
     DECLARE @letter CHAR(1)

     WHILE (@index <= @length)
     BEGIN
          SET @letter = SUBSTRING(@word, @index, 1)
          IF (CHARINDEX(@letter, @setOfLetters) > 0)
             SET @index = @index + 1
          ELSE
             RETURN 0
     END
     RETURN 1
END 

select CHARINDEX('O', 'firmf')
select CHARINDEX('i', 'firmf')
SELECT LEFT('SFDSF', 2)
SELECT SUBSTRING('SoftUni', 2, 2)

SELECT dbo.ufn_IsWordComprised1('oistmiahf', 'Sofia')

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Halves')
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'sofia')

SELECT dbo.ufn_IsWordComprised2('oistmiahf', 'Halves')
SELECT dbo.ufn_IsWordComprised2('oistmiahf', 'sofia')

SELECT dbo.ufn_IsWordComprised4('oistmiahf', 'Halves')
SELECT dbo.ufn_IsWordComprised4('oistmiahf', 'sofia')

SELECT dbo.ufn_IsWordComprised5('oistmiahf', 'Halves')
SELECT dbo.ufn_IsWordComprised5('oistmiahf', 'sofia')


SELECT CHARINDEX(LEFT('Sofia', 1), 'oistmiahf')

CREATE FUNCTION ufn_IsWordComprised2
  (
  @setOfLetters nvarchar(255), 
  @word nvarchar(255)
  )
RETURNS bit
AS
BEGIN 
    DECLARE @l int = 1;
    DECLARE @exist bit = 1;
    WHILE LEN(@word) >= @l AND @exist > 0
    BEGIN
      DECLARE @charindex int; 
      DECLARE @letter char(1);
      SET @letter = SUBSTRING(@word, @l, 1)
      SET @charindex = CHARINDEX(@letter, @setOfLetters, 0)
      SET @exist =
        CASE
            WHEN  @charindex > 0 THEN 1
            ELSE 0
        END;
      SET @l += 1;
    END

    RETURN @exist
END

CREATE FUNCTION ufn_IsWordComprised5(@setOfLetters NVARCHAR(50), @word NVARCHAR(25))
RETURNS BIT
AS
BEGIN
    DECLARE @result BIT = 1;
    DECLARE @counter INT = 1;
    DECLARE @wordLen INT = LEN(@word);
        WHILE(@counter <= @wordLen)
        BEGIN
        DECLARE @currentLetter CHAR(1)= SUBSTRING(@word, @counter, 1);
            IF(@setOfLetters NOT LIKE '%'+@currentLetter + '%')
            BEGIN
            SET @result = 0;
            END
        SET @counter += 1;
        END
 
    RETURN @result;
END

-------------------------------------------------------------------------
-- Cъздаване--

CREATE OR ALTER PROC dbo.usp_SelectEmployeesBySeniority
AS
	SELECT *
	FROM Employees
	WHERE DATEDIFF(YEAR, HireDate, GetDate()) > 19
GO

--Изпълнение--

EXEC [dbo].[usp_SelectEmployeesBySeniority]

ALTER PROC usp_SelectEmployeesBySeniority
AS
	SELECT FirstName, LastName, HireDate, 
	DATEDIFF(YEAR, HireDate, GetDate()) AS YearExperience
	FROM Employees
	WHERE DATEDIFF(YEAR, HireDate, GetDate()) > 10
	ORDER BY YearExperience
GO

-- С Параметри --

ALTER PROC usp_SelectEmployeesBySeniority(@minYearExperience INT = 10)
AS
	SELECT FirstName, LastName, HireDate, 
	DATEDIFF(YEAR, HireDate, GetDate()) AS YearExperience
	FROM Employees
	WHERE DATEDIFF(YEAR, HireDate, GetDate()) > @minYearExperience
	ORDER BY YearExperience
GO

EXEC [dbo].[usp_SelectEmployeesBySeniority] 19

-- Output --

CREATE PROC sp_AddingNumbers
	 @firstNumber SMALLINT, 
	 @secondNumber SMALLINT, 
	 @result INT OUTPUT
AS
	SET @result = @firstNumber + @secondNumber;
GO

DECLARE @result INT
EXECUTE sp_AddingNumbers 105, 110, @result  OUTPUT
SELECT 'The result is:', @result

-- MULTIPLE OUTPUT --

CREATE PROC sp_MultipleOutput
AS
	SELECT FirstName, LastName 	FROM Employees
	SELECT FirstName, LastName, d.[Name] AS Department
	FROM Employees e
	JOIN Departments d ON d.DepartmentID = e.DepartmentID;
GO

EXEC sp_MultipleOutput

	--P01--

GO

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
	SELECT FirstName, LastName
	FROM Employees 
	WHERE Salary > 35000

EXEC usp_GetEmployeesSalaryAbove35000

	--P02--

GO

CREATE PROC usp_GetEmployeesSalaryAboveNumber (@minSalary DECIMAL(18, 4))
AS
	SELECT FirstName, LastName
	FROM Employees 
	WHERE Salary >= @minSalary

EXEC usp_GetEmployeesSalaryAboveNumber 48100 

	--P03--

GO

CREATE PROC usp_GetTownsStartingWith (@beginningString NVARCHAR(20))
AS
	SELECT [Name] AS Town
	FROM Towns
	WHERE LEFT([Name], LEN(@beginningString)) = @beginningString

EXEC usp_GetTownsStartingWith 'B'

	--P04--

GO

CREATE PROC usp_GetEmployeesFromTown (@townName VARCHAR(20))
AS
	SELECT FirstName, LastName
	FROM Employees e
	JOIN Addresses a ON a.AddressID = e.AddressID
	JOIN Towns t ON t.TownID = a.TownID
	WHERE t.Name = @townName

EXEC usp_GetEmployeesFromTown 'Sofia'

	--P05--
GO

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(10);

	IF @salary < 30000
	SET @salaryLevel = 'Low';
	ELSE IF @salary BETWEEN 30000 AND 50000
	SET @salaryLevel = 'Average';
	ELSE 
	SET @salaryLevel = 'High';

	RETURN @salaryLevel
END

GO

SELECT Salary, dbo.ufn_GetSalaryLevel (Salary) AS SalaryLevel
		FROM Employees

	--P06--

GO

CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(10))
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE  dbo.ufn_GetSalaryLevel (Salary) = @salaryLevel

EXEC usp_EmployeesBySalaryLevel 'High'

	--P08--
GO

CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
							SELECT EmployeeID FROM Employees
							WHERE DepartmentID = @departmentId
						)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
							SELECT EmployeeID FROM Employees
							WHERE DepartmentID = @departmentId
					    )

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (
							SELECT EmployeeID FROM Employees
							WHERE DepartmentID = @departmentId
					    )

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId

	EXEC usp_DeleteEmployeesFromDepartment 1 

	--P09--
GO

CREATE PROC usp_GetHoldersFullName
AS
	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders

EXEC usp_GetHoldersFullName

	--P10--

GO

CREATE PROC usp_GetHoldersWithBalanceHigherThan (@totalSum MONEY)
AS
	SELECT FirstName, LastName
	FROM  Accounts a 
	JOIN AccountHolders ah ON a.AccountHolderId = ah.Id
	GROUP BY AccountHolderId, FirstName, LastName
	HAVING SUM(Balance) > @totalSum
	ORDER BY FirstName, LastName
	
EXEC usp_GetHoldersWithBalanceHigherThan 100000

GO

	--P11--

GO

CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18, 4), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
	DECLARE @futureValue DECIMAL(18, 4) = @sum * (POWER((1 + @yearlyInterestRate), @numberOfYears))
	RETURN @futureValue
END

GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

	--P12--

GO

CREATE PROC usp_CalculateFutureValueForAccount (@accountId INT, @interestRate FLOAT)
AS
	SELECT a.Id, FirstName, LastName, Balance,
		   dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM Accounts a
	JOIN AccountHolders ah ON ah.Id = a.AccountHolderId
	WHERE a.Id = @accountId

EXEC usp_CalculateFutureValueForAccount 1, 0.1

	--P13--
GO

CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE AS
RETURN
SELECT SUM(Cash) AS SumCash FROM
	(
	SELECT g.[Name], 
		   ug.Cash, 
		   ROW_NUMBER() OVER (PARTITION BY [Name] ORDER BY Cash DESC) AS RowNum
	FROM Games g
	JOIN UsersGames ug ON ug.GameId = g.Id
	WHERE g.[Name] = @gameName
	) AS CashInAllRows
	WHERE RowNum % 2 = 1


SELECT * FROM ufn_CashInUsersGames('Love in a mist')


	
	