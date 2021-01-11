CREATE DATABASE Bitbucket

USE Bitbucket

CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY NOT NULL,
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(30) NOT NULL,
Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
PRIMARY KEY(RepositoryId, ContributorId)
)

CREATE TABLE Issues(
Id INT PRIMARY KEY IDENTITY NOT NULL,
Title VARCHAR(255) NOT NULL,
IssueStatus CHAR(6) NOT NULL,
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Message] VARCHAR(255) NOT NULL,
IssueId INT FOREIGN KEY REFERENCES Issues(Id),
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(100) NOT NULL,
Size DECIMAL(8, 2) NOT NULL,
ParentId INT FOREIGN KEY REFERENCES Files(Id),
CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)

INSERT INTO Files VALUES
	('Trade.idk', 2598.0, 1, 1),
	('menu.net', 9238.31, 2, 2),
	('Administrate.soshy', 1246.93, 3, 3),
	('Controller.php', 7353.15, 4, 4),
	('Find.java', 9957.86, 5, 5),
	('Controller.json', 14034.87, 3, 6),
	('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues VALUES
	('Critical Problem with HomeController.cs file', 'open', 1, 4),
	('Typo fix in Judge.html', 'open', 4, 3),
	('Implement documentation for UsersService.cs', 'closed', 8, 2),
	('Unreachable code in Index.cs', 'open', 9, 8)

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

DELETE FROM RepositoriesContributors
WHERE RepositoryId = (SELECT Id FROM Repositories
					  WHERE [Name] = 'Softuni-Teamwork')

DELETE FROM Issues
WHERE RepositoryId = (SELECT Id FROM Repositories
					  WHERE [Name] = 'Softuni-Teamwork')

SELECT Id, [Message], RepositoryId, ContributorId
FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId

SELECT Id, [Name], Size
FROM Files
WHERE Size > 1000 AND [Name] LIKE ('%html%')
ORDER BY Size DESC, Id, [Name]

SELECT i.Id, CONCAT(u.Username, ' : ', i.Title)
FROM Issues i
JOIN Users u ON u.Id = i.AssigneeId
ORDER BY i.Id DESC, i.AssigneeId

SELECT f.Id, f.[Name], CONCAT(f.Size, 'KB') AS Size
FROM Files f
LEFT JOIN Files pf ON f.Id = pf.ParentId
WHERE pf.Id IS NULL
ORDER BY f.Id, f.[Name], Size DESC

SELECT TOP(5) r.Id, r.[Name], COUNT(c.RepositoryId) AS Commits
FROM Repositories r
JOIN Commits c ON c.RepositoryId = r.Id
LEFT JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.[Name]
ORDER BY Commits DESC, r.Id, r.[Name]

SELECT Username, AVG(Size) AS Size 
FROM Users u
JOIN Commits c ON c.ContributorId = u.Id
JOIN Files f ON f.CommitId = c.Id
GROUP BY Username
ORDER BY Size DESC, Username

GO

CREATE OR ALTER FUNCTION udf_UserTotalCommits(@username VARCHAR(30)) 
RETURNS INT
AS
BEGIN
	DECLARE @count INT = (SELECT COUNT(*)
						  FROM Users u
						  JOIN Commits c ON c.ContributorId = u.Id
						  GROUP BY u.Username
						  HAVING Username = @username)
RETURN @count
END

GO

GO

CREATE OR ALTER FUNCTION udf_UserTotalCommits1(@username VARCHAR(50))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*) 
			   FROM Commits 
			  WHERE ContributorId IN (SELECT Id 
										FROM Users 
									   WHERE Username = @username))

END

GO

SELECT dbo.udf_UserTotalCommits('BlaSinduxrein')
SELECT dbo.udf_UserTotalCommits1('BlaSinduxrein')

SELECT *
	FROM Users u
	JOIN Commits c ON c.ContributorId = u.Id
	GROUP BY u.Username
	HAVING Username = 'UnderSinduxrein'

SELECT COUNT(*) 
			   FROM Commits 
			  WHERE ContributorId IN (SELECT Id 
										FROM Users 
									   WHERE Username = 'UnderSinduxrein')

									   GO

GO

CREATE FUNCTION udf_UserTotalCommits2(@username VARCHAR(30)) 
RETURNS INT
AS
BEGIN
	DECLARE @count INT = (SELECT COUNT(*)
						  FROM Users u
						  JOIN Commits c ON c.ContributorId = u.Id
						  WHERE Username = @username
						  GROUP BY u.Username)
RETURN @count
END

SELECT dbo.udf_UserTotalCommits2('UnderSinduxrein')

GO

CREATE PROCEDURE usp_FindByExtension(@extension VARCHAR(10))
AS
SELECT Id, [Name], CONCAT(Size, 'KB') AS Size
FROM Files
WHERE RIGHT([Name], LEN(@extension)) = @extension
ORDER BY Id, [Name], Size DESC

EXEC usp_FindByExtension 'txt'

GO 

CREATE PROC usp_FindByExtension(@extension VARCHAR(10))
AS
BEGIN
	SELECT f.Id, f.[Name],
		   CONCAT(f.Size,'KB') AS Size
	  FROM Files f
	 WHERE [Name] LIKE '%.' + @extension
	 ORDER BY Id, [Name], f.Size DESC
END

CREATE FUNCTION udf_UserTotalCommits(@username NVARCHAR(30))
RETURNS INT
    AS
    BEGIN
        DECLARE @userCount INT = (
        SELECT COUNT(*) FROM Commits C
JOIN Users U on C.ContributorId = U.Id
WHERE Username = @username
        );

        RETURN @userCount
    END

GO

CREATE OR ALTER FUNCTION udf_UserTotalCommits(@username VARCHAR(30)) 
RETURNS INT
AS
BEGIN
	DECLARE @count INT = (SELECT COUNT(*)
						  FROM Users u
						  JOIN Commits c ON c.ContributorId = u.Id
						  GROUP BY u.Username
						  HAVING Username = @username)
RETURN @count
END

GO


