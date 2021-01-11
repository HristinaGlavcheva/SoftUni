CREATE DATABASE School

USE School

CREATE TABLE Students(
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(25),
LastName NVARCHAR(30) NOT NULL,
Age TINYINT CHECK (Age >= 5 AND Age <= 100),
[Address] NVARCHAR(50),
Phone NCHAR(10)
)

CREATE TABLE Subjects(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(20) NOT NULL,
Lessons	INT CHECK (Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects(
Id INT PRIMARY KEY IDENTITY NOT NULL,
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
Grade DECIMAL(3, 2) CHECK (Grade >= 2 AND Grade <= 6) NOT NULL
)

CREATE TABLE Exams(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Date] DATETIME2,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
Grade DECIMAL(3, 2) CHECK (Grade >= 2 AND Grade <= 6) NOT NULL,
PRIMARY KEY(StudentID, ExamID)
)

CREATE TABLE Teachers(
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
[Address] NVARCHAR(20) NOT NULL,
Phone CHAR(10),
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL,
PRIMARY KEY(StudentId, TeacherID)
)

INSERT INTO Teachers VALUES
	('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
	('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
	('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
	('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO Subjects VALUES
	('Geometry', 12),
	('Health', 10),
	('Drama', 7),
	('Sports', 9)

UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN (1, 2) AND Grade >= 5.50

DELETE FROM StudentsTeachers WHERE TeacherId IN
	(SELECT Id FROM Teachers
	WHERE Phone LIKE ('%72%'))

DELETE FROM Teachers
WHERE Phone LIKE ('%72%')

SELECT FirstName, LastName, Age
FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName

SELECT FirstName, LastName, COUNT(TeacherId) AS TeachersCount
FROM StudentsTeachers st
JOIN Students s ON s.Id = st.StudentId
GROUP BY StudentId, FirstName, LastName
ORDER BY LastName

SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
FROM Students s
LEFT JOIN StudentsExams se ON se.StudentId = s.Id
WHERE ExamId IS NULL
ORDER BY [Full Name]

SELECT TOP(10) FirstName, LastName, FORMAT(Grade, 'N') AS Grade 
FROM
	(SELECT FirstName, LastName, ROUND(AVG(Grade), 2) AS Grade
	FROM Students s
	JOIN StudentsExams se ON s.Id = se.StudentId
	GROUP BY StudentId, FirstName, LastName) AS DataWithNoRoundedGrade
	ORDER BY Grade DESC, FirstName, LastName

SELECT CONCAT(FirstName, ' ', MiddleName + ' ', LastName) AS [Full Name] 
FROM Students s
LEFT JOIN StudentsSubjects ss ON ss.StudentId = s.Id
WHERE SubjectId IS NULL
ORDER BY [Full Name]

SELECT [Name], AVG(Grade) AS AverageGrade
FROM Subjects s
JOIN StudentsSubjects ss ON s.Id = ss.SubjectId
GROUP BY s.Id, [Name]
ORDER BY s.Id

GO

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3, 2))
RETURNS NVARCHAR(MAX)
AS
BEGIN
	IF @studentId NOT IN (SELECT Id FROM Students)
	RETURN 'The student with provided id does not exist in the school!'

	IF @grade > 6
	RETURN 'Grade cannot be above 6.00!'
	
	DECLARE @countGrades INT = 	(SELECT COUNT(Grade) FROM StudentsExams
									WHERE StudentId = @studentId AND 
									Grade BETWEEN @grade AND (@grade + 0.5)) 

	DECLARE @firstName NVARCHAR(30) = (SELECT FirstName FROM Students
										WHERE Id = @studentId)

	RETURN 'You have to update ' + CAST(@countGrades AS NVARCHAR(10)) + ' grades for the student ' + @firstName
		
END

GO

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)

GO

CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
IF @StudentId NOT IN (SELECT Id FROM Students)
THROW 50001, 'This school has no student with the provided id!', 1
ELSE 
BEGIN
	DELETE FROM StudentsExams
	WHERE StudentId = @StudentId

	DELETE FROM StudentsSubjects
	WHERE StudentId = @StudentId

	DELETE FROM StudentsTeachers
	WHERE StudentId = @StudentId

	DELETE FROM Students
	WHERE Id = @StudentId
END

EXEC usp_ExcludeFromSchool 301

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students


