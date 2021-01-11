SELECT FirstName, LastName, t.Name AS Town, a.AddressText
FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
ORDER BY FirstName, LastName

SELECT EmployeeID, FirstName, LastName, Name AS DepartmentName 
FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID

SELECT FirstName, LastName, HireDate, [Name] AS DeptName 
FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID 
WHERE HireDate > '1999-01-01' 
		AND (d.Name = 'Finance' OR d.Name = 'Sales')
ORDER BY HireDate

SELECT FirstName, LastName, HireDate, [Name] AS DeptName 
FROM Employees e
	JOIN Departments d 
	ON e.DepartmentID = d.DepartmentID 
	AND HireDate > '1999-01-01' 
	AND (d.Name = 'Finance' OR d.Name = 'Sales')
ORDER BY HireDate

SELECT TOP(50) 
	e.EmployeeID,
	CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	d.Name AS DepartmentName
FROM Employees e
	LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID
	LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
	ORDER BY e.EmployeeID

SELECT TOP(1)
	(SELECT AVG(Salary) FROM Employees e
	 WHERE e.DepartmentID = d.DepartmentID) 
		AS MinAverageSalary
	 FROM Departments d
	 WHERE (SELECT COUNT(*) FROM Employees e
			WHERE E.DepartmentID = d.DepartmentID) > 0
	 ORDER BY MinAverageSalary

	 --P01--

SELECT TOP(5) EmployeeID, JobTitle, e.AddressID, a.AddressText
	FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
ORDER BY AddressID ASC

	--P02--

SELECT TOP(50) e.FirstName, e.LastName, t.Name AS TownName, a.AddressText
	FROM Employees e
JOIN Addresses a ON  e.AddressID = a.AddressID
JOIN Towns t ON t.TownID = a.TownID
ORDER BY FirstName, LastName

	--P03--

SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name AS DepartmentName
	FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS DepartmentName
	FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID AND d.[Name] = 'Sales'
ORDER BY e.EmployeeID

	--P04--

SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name] AS DepartmentName
	FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID ASC

SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name] AS DepartmentName
	FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID AND e.Salary > 15000
ORDER BY d.DepartmentID ASC

	--P05--

SELECT TOP(3) e.EmployeeID, e.FirstName
	FROM Employees e
LEFT JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID ASC

	--P06--

SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS DeptName
	FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID AND e.HireDate > '1.1.1999'
WHERE d.[Name] IN ('Sales', 'Finance')
ORDER BY HireDate

	--P07--

SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name] AS ProjectName
	FROM Employees e
JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects p ON p.ProjectID = ep.ProjectID AND p.StartDate > '2002-08-13'
WHERE p.EndDate IS NULL
ORDER BY e.EmployeeID ASC

	--P08--

SELECT e.EmployeeID, e.FirstName,
	CASE 
		WHEN YEAR(p.StartDate) >= 2005 THEN NULL
		ELSE p.Name
		END AS ProjectName
	FROM Employees e
	JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
	JOIN Projects p ON p.ProjectID = ep.ProjectID
	WHERE e.EmployeeID = 24

	--P09--

SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS ManagerName
	FROM Employees e
	JOIN Employees m ON e.ManagerID = m.EmployeeID AND e.ManagerID IN (3, 7)

SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS ManagerName
	FROM Employees e
	JOIN Employees m ON e.ManagerID = m.EmployeeID
	WHERE e.ManagerID IN (3, 7)

	--P10--

SELECT TOP(50) 
	e.EmployeeID,
	CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	d.[Name] AS DepartmentName
	FROM Employees e
	JOIN Employees m ON e.ManagerID = m.EmployeeID
	JOIN Departments d ON d.DepartmentID = e.DepartmentID
	ORDER BY e.EmployeeID
	
	--P11--

SELECT TOP(1) AVG(Salary) AS MinAverageSalary
	FROM Departments d
	JOIN Employees e ON e.DepartmentID = d.DepartmentID
	GROUP BY d.DepartmentID
	ORDER BY MinAverageSalary

SELECT MIN(AverageSalary) AS MinAverageSalary
FROM
	(SELECT AVG(Salary) AS AverageSalary
	FROM Employees
	GROUP BY DepartmentID) AS AverageSalaryQuery


	--P12--

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	FROM Countries c 
	JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	JOIN Mountains m ON m.Id = mc.MountainId
	JOIN Peaks p ON p.MountainId = m.Id
	WHERE c.CountryName = 'Bulgaria' AND p.Elevation > 2835
	ORDER BY p.Elevation DESC

	--P13--

CREATE VIEW v_MountainsInBG_US_RS AS
SELECT c.CountryCode, m.MountainRange
	FROM Mountains m
	JOIN MountainsCountries mc ON mc.MountainId = m.Id
	JOIN Countries c ON c.CountryCode = mc.CountryCode
	WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')

SELECT CountryCode, COUNT(MountainRange) AS MountainRanges
FROM(
	SELECT c.CountryCode, m.MountainRange
	FROM Mountains m
		JOIN MountainsCountries mc ON mc.MountainId = m.Id
		JOIN Countries c ON c.CountryCode = mc.CountryCode
	WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
	) AS Mountains_In_BG_US_RS
GROUP BY CountryCode

SELECT CountryCode, COUNT(MountainID) AS MountainRanges
	FROM MountainsCountries
WHERE CountryCode IN ('US', 'RU', 'BG')
	GROUP BY CountryCode
	
	--P14--

SELECT TOP(5) c.CountryName, r.RiverName 
FROM Continents cont
	JOIN Countries c ON c.ContinentCode = cont.ContinentCode
	LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers r ON r.Id = cr.RiverId
WHERE cont.ContinentName = 'Africa'
ORDER BY c.CountryName

	--P16--

SELECT COUNT(*) AS [Count]
FROM MountainsCountries mc
	RIGHT JOIN Countries c ON c.CountryCode = mc.CountryCode
WHERE mc.CountryCode IS NULL
	
	--P15--

SELECT ContinentCode, CurrencyCode, CurrencyUsage FROM
	(
	SELECT ContinentCode, 
		   CurrencyCode,
		   COUNT(CurrencyCode) AS CurrencyUsage,
		   DENSE_RANK() OVER
			   (PARTITION BY ContinentCode ORDER BY Count(CurrencyCode) DESC) AS CurrencyUsageRank
		FROM Countries 
	GROUP BY ContinentCode, CurrencyCode
	) AS RankingQuery
WHERE CurrencyUsage > 1 AND CurrencyUsageRank = 1
ORDER BY ContinentCode

	--P17--

SELECT TOP(5) c.CountryName, 
			MAX(p.Elevation) AS HighestPeakElevation, 
			MAX(r.Length) AS LongestRiverLength
FROM Countries c
	LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers r ON r.Id = cr.RiverId
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Peaks p ON p.MountainId = mc.MountainId
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName

	--P18--
			
SELECT TOP(5) [temp].Country,
              ISNULL([temp].[Highest Peak Name], '(no highest peak)') AS [Highest Peak Name],
              ISNULL([temp].[Highest Peak Elevation], 0) AS [Highest Peak Elevation],
              ISNULL([temp].Mountain, '(no mountain)') AS [Mountain]
    FROM
        (SELECT c.CountryName AS [Country],
                p.PeakName AS [Highest Peak Name],
                p.Elevation AS [Highest Peak Elevation],
                m.MountainRange AS [Mountain],
                DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS [Rank]
            FROM Countries AS c
                LEFT JOIN MountainsCountries AS mc
                ON c.CountryCode = mc.CountryCode
                LEFT JOIN Mountains AS m
                ON mc.MountainId = m.Id
                LEFT JOIN Peaks AS p
                ON m.Id = p.MountainId) AS [temp]
        WHERE [temp].[Rank] = 1
            ORDER BY [temp].Country ASC,
                     [Highest Peak Name] ASC;


SELECT TOP (5) Country,
		CASE 
			WHEN PeakName IS NULL THEN '(no highest peak)' 
			ELSE PeakName
		END AS [Highest Peak Name],
		CASE 
			WHEN Elevation IS NULL THEN 0 
			ELSE Elevation
		END AS [Highest Peak Elevation],
		CASE 
			WHEN MountainRange IS NULL THEN '(no mountain)'
			ELSE MountainRange
		END AS Mountain
	FROM 
	(SELECT *,
		DENSE_RANK() OVER 
			(PARTITION BY Country ORDER BY Elevation DESC) AS PeakRank
		FROM
			(SELECT CountryName AS Country,
				p.PeakName,
				p.Elevation,
				m.MountainRange
			FROM Countries c
				LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
				LEFT JOIN Mountains m ON m.Id = mc.MountainId
				LEFT JOIN Peaks p ON p.MountainId = m.Id
			) AS FullInfoQuery
		) AS PeakRankingQuery
	WHERE PeakRank = 1
	ORDER BY Country, [Highest Peak Name]

SELECT DepartmentID,
	(SELECT [Name] FROM Departments d WHERE e.DepartmentID = d.DepartmentID) AS DepartmentName,
	AVG(Salary) AS AverageSalary
	FROM Employees e
	GROUP BY DepartmentID



