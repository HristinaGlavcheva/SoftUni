CREATE DATABASE TripService

USE TripService

CREATE TABLE Cities(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL,
CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
EmployeeCount INT NOT NULL,
BaseRate DECIMAL(8, 2)
)

CREATE TABLE Rooms(
Id INT PRIMARY KEY IDENTITY,
Price DECIMAL(8, 2) NOT NULL,
[Type] NVARCHAR(20) NOT NULL,
Beds INT NOT NULL,
HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips(
Id INT PRIMARY KEY IDENTITY,
RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
BookDate DATETIME2 NOT NULL, 
	CONSTRAINT ck_BookDateValidity CHECK (BookDate < ArrivalDate),
ArrivalDate DATETIME2 NOT NULL, 
	CONSTRAINT ck_ArrivalDateValidity CHECK (ArrivalDate < ReturnDate),
ReturnDate DATETIME2 NOT NULL,
CancelDate DATETIME2
)

CREATE TABLE Accounts(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(20),
LastName NVARCHAR(50) NOT NULL,
CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
BirthDate DATETIME2 NOT NULL,
Email VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE AccountsTrips(
AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
Luggage INT NOT NULL CHECK(Luggage >= 0),
PRIMARY KEY(AccountId, TripId)
)

INSERT INTO Accounts VALUES
	('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
	('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
	('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
	('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')


INSERT INTO Trips VALUES
	(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
	(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
	(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
	(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
	(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

UPDATE Rooms
SET Price*= 1.14
WHERE HotelId IN(5, 7, 9)

DELETE FROM AccountsTrips
WHERE AccountId = 47

SELECT FirstName,
       LastName, 
	   FORMAT(BirthDate, 'MM-dd-yyyy') AS BirthDate, 
	   c.[Name], Email
FROM Accounts a
JOIN Cities c ON c.Id = a.CityId
WHERE Email LIKE ('e%')
ORDER BY c.[Name]

SELECT c.[Name] AS City, COUNT(h.Id) AS Hotels
FROM Cities c
JOIN Hotels h ON h.CityId = c.Id
GROUP BY c.Id, c.[Name]
ORDER BY Hotels DESC, City

SELECT a.Id,
	   CONCAT(FirstName, ' ', LastName) AS FullName,
	   MAX(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS LongestTrip,
	   MIN(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS ShortestTrip
FROM Accounts a
JOIN AccountsTrips ac ON ac.AccountId = a.Id
JOIN Trips t ON t.Id = ac.TripId
WHERE a.MiddleName IS NULL AND CancelDate IS NULL
GROUP BY a.Id, FirstName, LastName
ORDER BY LongestTrip DESC, ShortestTrip

SELECT TOP(10) c.Id, c.[Name] AS City, CountryCode AS Country, COUNT(a.Id) AS Accounts
FROM Cities	c
JOIN Accounts a ON a.CityId = c.Id
GROUP BY c.Id, c.[Name], CountryCode
ORDER BY Accounts DESC

SELECT a.Id AS Id, Email, c.[Name] AS City, 
	COUNT(h.CityId) AS Trips
FROM Accounts a 
JOIN Cities c ON c.Id = a.CityId
JOIN Hotels h ON h.CityId = a.CityId
WHERE a.CityId = h.CityId

GROUP BY a.Id, Email, c.[Name]
ORDER BY Trips DESC, a.Id


------P10-------

SELECT 
		t.Id AS Id, 
		CONCAT(a.FirstName, ' ', a.MiddleName + ' ', a.LastName) AS [Full Name],
	    c.[Name] AS [From],
		c2.[Name],
	    CASE 
			WHEN CancelDate IS NOT NULL THEN CONVERT(VARCHAR, 'Canceled')
			ELSE CONCAT(DATEDIFF(DAY, ArrivalDate, ReturnDate), ' days')
		END AS Duration
FROM Trips t
JOIN AccountsTrips ac ON ac.TripId = t.Id
JOIN Accounts a ON a.Id = ac.AccountId
JOIN Cities c ON c.Id = a.CityId
JOIN Rooms r ON r.Id = t.RoomId
JOIN Hotels h ON h.Id = r.HotelId
JOIN Cities c2 ON c2.ID = h.CityId
ORDER BY [Full Name], t.Id

----P11------

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATETIME2, @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	
	DECLARE @counter INT = 1;
	DECLARE @countRooms INT;
	SET @countRooms = (SELECT COUNT(*) 
					   FROM Rooms
					   WHERE HotelId = @HotelId)

	WHILE(@counter <= @countRooms)
		BEGIN
			DECLARE @currentRoomId INT = (SELECT * 
							FROM Rooms r
							LEFT JOIN Trips t ON r.Id = t.RoomId
							WHERE HotelId = 7)

		END

END

SELECT *
FROM Rooms
WHERE HotelId = 7


-----P12-------
GO

CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS

DECLARE @targetRoomHotelId INT = (SELECT HotelId
							  FROM Rooms
							  WHERE @TargetRoomId = Id)

DECLARE @tripHotelId INT = (SELECT HotelId
							FROM ROOMS r
							JOIN Trips t ON t.RoomId = r.Id
							WHERE t.Id = @TripId)

IF @targetRoomHotelId != @tripHotelId
THROW 50001, 'Target room is in another hotel!', 1

DECLARE @countBedsInTargetRoom INT = (SELECT Beds
									  FROM Rooms	
									  WHERE Id = @TargetRoomId)		
									
DECLARE @countOfAllTripsAccounts INT = (SELECT COUNT(*)
										FROM AccountsTrips ac
									    JOIN Trips t ON t.Id = ac.TripId
										WHERE t.Id = @TripId)
										
IF @countBedsInTargetRoom < @countOfAllTripsAccounts
THROW 50001, 'Not enough beds in target room!', 1

UPDATE Trips
		SET RoomId = @TargetRoomId


EXEC usp_SwitchRoom 10, 8	Not enough beds in target room!

EXEC usp_SwitchRoom 10, 7

		EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10


SELECT * FROM ROOMS r
		JOIN Trips t ON t.RoomId = r.Id
	

SELECT * FROM TRIPS

SELECT a.Id AS Id, Email, c.[Name] AS City, COUNT(*) AS Trips
FROM Accounts a
JOIN AccountsTrips ac ON ac.AccountId = a.Id
JOIN Trips t ON t.Id = ac.TripId
JOIN Rooms r ON r.Id = t.RoomId
JOIN Hotels h ON h.Id = r.HotelId
JOIN Cities c ON c.Id = h.CityId
WHERE a.CityId = h.CityId
GROUP BY a.Id, Email, c.[Name]
ORDER BY Trips DESC, a.Id

SELECT 
		t.Id AS Id, 
		CONCAT(a.FirstName, ' ', a.MiddleName + ' ', a.LastName) AS [Full Name],
	    c.[Name] AS [From],
		c2.[Name],
	    CASE 
			WHEN CancelDate IS NOT NULL THEN CONVERT(VARCHAR, 'Canceled')
			ELSE CONCAT(DATEDIFF(DAY, ArrivalDate, ReturnDate), ' days')
		END AS Duration
FROM Trips t
JOIN AccountsTrips ac ON ac.TripId = t.Id
JOIN Accounts a ON a.Id = ac.AccountId
JOIN Cities c ON c.Id = a.CityId
JOIN Rooms r ON r.Id = t.RoomId
JOIN Hotels h ON h.Id = r.HotelId
JOIN Cities c2 ON c2.ID = h.CityId
ORDER BY [Full Name], t.Id

GO

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATETIME2, @People INT)
RETURNS NVARCHAR(MAX) 
AS
BEGIN
	DECLARE @counter INT = 1;
	DECLARE @countRooms INT;
	SET @countRooms = (SELECT COUNT(*) 
					   FROM Rooms
					   WHERE HotelId = @HotelId)

	DECLARE @roomsAvailabe BIT = 0
	DECLARE @maxPrice DECIMAL(8, 2) = 0

	WHILE(@counter <= @countRooms AND @roomsAvailabe = 0)
		BEGIN
			
			DECLARE @currentRoomId INT = (SELECT r.Id 
							FROM Rooms r
							LEFT JOIN Trips t ON r.Id = t.RoomId
							WHERE HotelId = 5)


			DECLARE @currentRoomArrivalDate DATETIME2 = (SELECT * 
							FROM Rooms r
							LEFT JOIN Trips t ON r.Id = t.RoomId
							WHERE HotelId = 5)

			DECLARE @currentRoomReturnDate DATETIME2 = (SELECT * 
							FROM Rooms r
							LEFT JOIN Trips t ON r.Id = t.RoomId
							WHERE HotelId = 5)

			DECLARE @currentRoomPrice DECIMAL(8, 2) = (SELECT Price 
														FROM Rooms 
														WHERE Id = @currentRoomId)
			

			IF (@Date >= @currentRoomArrivalDate AND @Date <= @currentRoomReturnDate)
				OR 
				(SELECT CancelDate FROM Trips
				WHERE RoomId = @currentRoomId) IS NOT NULL
				OR
			    @currentRoomPrice < @maxPrice 
				SET @counter += 1

			ELSE
			SET @roomsAvailabe = 1

		END

		IF @roomsAvailabe = 1
		RETURN 'No rooms available'
		ELSE RETURN 'Room ' + @currentRoomId + ': {Room Type} ({Beds} beds) - $' + @currentRoomPrice
END

SELECT * FROM Rooms
