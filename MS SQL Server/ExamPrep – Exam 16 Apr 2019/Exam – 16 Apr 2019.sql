CREATE DATABASE Airport

CREATE TABLE Planes(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(30) NOT NULL,
Seats INT NOT NULL,
[Range] INT NOT NULL
)

CREATE TABLE Flights(
Id INT PRIMARY KEY IDENTITY NOT NULL,
DepartureTime DATETIME2,
ArrivalTime DATETIME2,
Origin VARCHAR(50) NOT NULL,
Destination VARCHAR(50) NOT NULL,
PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers(
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
Age INT NOT NULL,
[Address] VARCHAR(30) NOT NULL,
PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages(
Id INT PRIMARY KEY IDENTITY NOT NULL,
LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
)

CREATE TABLE Tickets(
Id INT PRIMARY KEY IDENTITY NOT NULL,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
Price DECIMAL(15, 2) NOT NULL
)

INSERT INTO Planes([Name], Seats, [Range])
VALUES
	('Airbus 336', 112, 5132),
	('Airbus 330', 432, 5325),
	('Boeing 369', 231, 2355),
	('Stelt 297', 254, 2143),
	('Boeing 338', 165, 5111),
	('Airbus 558', 387, 1342),
	('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes([Type])
VALUES
	('Crossbody Bag'),
	('School Backpack'),
	('Shoulder Bag')

UPDATE Tickets
SET Price *= 1.13
WHERE FlightId IN 
		(SELECT Id FROM Flights
		WHERE Destination = 'Carlsbad')
		
UPDATE Tickets
SET Price *= 1.13
	FROM Flights f
	JOIN Tickets t ON t.FlightId = f.Id
	WHERE f.Destination = 'Carlsbad'

DELETE FROM Tickets WHERE FlightId IN
	(SELECT Id FROM Flights
	WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

SELECT * FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, [Range]

SELECT * FROM Planes
WHERE CHARINDEX('tr', [Name]) > 0
ORDER BY Id, [Name], Seats, [Range]

SELECT FlightId, SUM(Price) AS Price
FROM Flights f
JOIN Tickets t ON t.FlightId = f.Id
GROUP BY FlightId
ORDER BY Price DESC, FlightId

SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name], f.Origin, f.Destination
FROM Passengers p
JOIN Tickets t ON p.Id = t.PassengerId
JOIN Flights f ON f.Id = t.FlightId
ORDER BY [Full Name], Origin, Destination

SELECT FirstName, LastName, Age
FROM Passengers p
LEFT JOIN Tickets t ON t.PassengerId = p.Id
WHERE t.Id IS NULL
ORDER BY Age DESC, FirstName, LastName

SELECT  
	CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
	pl.[Name] AS [Plane Name],
	CONCAT(f.Origin, ' - ', f.Destination) AS [Trip],
	lt.[Type] AS [Luggage Type]
FROM Passengers p
JOIN Tickets t ON t.PassengerId = p.Id
JOIN Flights f ON f.Id = t.FlightId
JOIN Planes pl ON pl.Id = f.PlaneId
JOIN Luggages l ON l.Id = t.LuggageId
JOIN LuggageTypes lt ON lt.Id = l.LuggageTypeId
ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination, [Luggage Type]

SELECT pl.[Name], pl.Seats, COUNT(t.Id) AS [Passengers Count]
FROM Planes pl
LEFT JOIN Flights f ON f.PlaneId = pl.Id
LEFT JOIN Tickets t ON t.FlightId = f.Id
GROUP BY pl.[Name], pl.Seats
ORDER BY [Passengers Count] DESC, pl.[Name], Seats

GO

CREATE /*OR ALTER*/ FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(100)
AS
BEGIN
	IF @peopleCount <=0 
	RETURN 'Invalid people count!'
	
	DECLARE @flightId INT = (
							SELECT TOP(1) Id FROM Flights
							WHERE Origin = @origin AND
								  Destination = @destination	  
							)
	IF @flightId IS NULL
	RETURN 'Invalid flight!'

	DECLARE @totalPrice DECIMAL(15,2) = (
										SELECT TOP(1) Price FROM Tickets
										WHERE FlightId = @flightId
										) * @peopleCount
	--RETURN 'Total price ' + CAST(@totalPrice AS VARCHAR(30))
	RETURN CONCAT('Total price ', @totalPrice)

END

GO

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)

SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

GO

CREATE PROC usp_CancelFlights
AS
	UPDATE Flights
	SET DepartureTime = NULL, ArrivalTime = NULL  
	WHERE ArrivalTime > DepartureTime

	SELECT * FROM Flights
	WHERE ArrivalTime > DepartureTime

