CREATE INDEX IX_Employees_Salary
ON Employees(Salary)

DROP INDEX IX_Employees_Salary
ON Employees

SELECT DISTINCT DepartmentID
	FROM Employees
	ORDER BY DepartmentID

SELECT DepartmentID, SUM(Salary) AS TotalSalary 
	FROM Employees e 
	GROUP BY DepartmentID
	ORDER BY DepartmentID

SELECT DepartmentID, SUM(Salary) AS TotalSalary,
	(SELECT [Name] FROM Departments d WHERE d.DepartmentID = e.DepartmentID) AS DepartmentName
	FROM Employees e
	GROUP BY e.DepartmentID
	HAVING SUM(Salary) > 15000

SELECT DepartmentID,
	(SELECT [Name] FROM Departments d WHERE e.DepartmentID = d.DepartmentID) AS DepartmentName,
	AVG(Salary) AS AverageSalary
	FROM Employees e
	GROUP BY DepartmentID

	--P01--

SELECT COUNT(*) AS [Count]
FROM WizzardDeposits

	--P02--

SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
	
	--P03--

SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

	--P04--

SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

	--P05--

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

	--P06--

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

	--P07--

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

	--P08--
	
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

	--P09--

SELECT AgeGroup, Count(*) AS WizardCount FROM 
	(SELECT
		CASE
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS AgeGroup, *
		FROM WizzardDeposits) AS AgeGroupQuery
		GROUP BY AgeGroup

SELECT 
	CASE
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]'
	END AS AgeGroup,
	Count(*) AS [Count]
FROM WizzardDeposits
GROUP BY CASE
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]'
	END 

	--P10--

SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter

	--P11--
 
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest)
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC

	--P12--

SELECT SUM([Difference]) AS SumDifference
FROM
(SELECT h.FirstName AS [Host Wizard],
	   h.DepositAmount AS [Host Wizard Deposit],
	   g.FirstName AS [Guest Wizard],
	   g.DepositAmount AS [Guest Wizard Deposit],
	   h.DepositAmount - g.DepositAmount AS [Difference]
FROM WizzardDeposits h
JOIN WizzardDeposits g ON g.Id = h.Id + 1) AS FindDifferenceQuery

	--P13--

SELECT DepartmentID, SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

	--P14--

SELECT DepartmentID, MIN(Salary) AS MinimumSalary
FROM Employees
WHERE DepartmentID IN (2, 5, 7) AND HireDate > 01/01/2000
GROUP BY DepartmentID

	--P15--

SELECT *
INTO EmployeesWithSalaryMoreThan30000
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithSalaryMoreThan30000 WHERE ManagerID = 42

UPDATE EmployeesWithSalaryMoreThan30000
SET Salary += 5000 WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM EmployeesWithSalaryMoreThan30000
GROUP BY DepartmentID

	--P16--

SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

	--P17--

SELECT COUNT(*) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

	--P18--

SELECT DISTINCT DepartmentID, Salary AS ThirdHighestSalary
FROM
	(
	SELECT DepartmentID, 
			Salary,
			DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS RankingSalary
	FROM Employees
	) AS RankingSalaryQuery
WHERE RankingSalary = 3


SELECT DepartmentID, Salary AS ThirdHighestSalary
FROM
	(
	SELECT DepartmentID, 
			Salary,
			DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS RankingSalary
	FROM Employees 
	GROUP BY DepartmentID, Salary
	) AS RankingSalaryQuery
WHERE RankingSalary = 3

	--P19--

SELECT TOP(10) FirstName, LastName, e.DepartmentID
FROM
	(
	SELECT DepartmentID, AVG(Salary) AS AverageSalary
	FROM Employees
	GROUP BY DepartmentID
	) AS AverageSalaryQuery
JOIN Employees e ON e.DepartmentID = AverageSalaryQuery.DepartmentID
WHERE Salary > AverageSalary
ORDER BY DepartmentID

SELECT TOP(10) FirstName, LastName, e.DepartmentID
FROM Employees e
WHERE e.Salary >
				(
				SELECT AVG(Salary) AS AverageSalary
				FROM Employees eAverageSalary
				WHERE e.DepartmentID = eAverageSalary.DepartmentID
				GROUP BY DepartmentID
				) 
ORDER BY DepartmentID








		
	




	
	