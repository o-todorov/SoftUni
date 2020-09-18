SELECT * FROM Flights
SELECT * FROM Tickets
SELECT * FROM Luggages
SELECT * FROM LuggageTypes
SELECT * FROM Passengers
SELECT * FROM Planes

----------------------------------------------
INSERT INTO Planes([Name], Seats, [Range])
	VALUES
('Airbus 336',	112,	5132),
('Airbus 330',	432,	5325),
('Boeing 369',	231,	2355),
('Stelt 297',	254,	2143),
('Boeing 338',	165,	5111),
('Airbus 558',	387,	1342),
('Boeing 128',	345,	5541)

INSERT INTO LuggageTypes([Type])
	VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')


--------------------------------------------


UPDATE Tickets
	SET Price = Price * 1.13
	WHERE FlightId IN (	SELECT Id
						FROM Flights
						WHERE Destination = 'Carlsbad')

-------------------------------

DELETE 	FROM Tickets
	WHERE FlightId IN (	SELECT Id
						FROM Flights
						WHERE Destination = 'Ayn Halagim')

DELETE 	FROM Flights
	WHERE Destination = 'Ayn Halagim'

---------------------------------

SELECT Id, [Name], Seats, [Range]
	FROM Planes
	WHERE [Name] LIKE '%tr%'
	ORDER BY Id, [Name], Seats, [Range]

---------------------------------

SELECT FlightId, SUM(Price) AS Price
	FROM Tickets
	GROUP BY FlightId
	ORDER BY Price DESC, FlightId ASC

---------------------------------

SELECT CONCAT(P.FirstName,' ',  P.LastName) AS [Full Name],
		F.Origin, 
		F.Destination
	FROM Passengers AS P
	JOIN Tickets AS T ON T.PassengerId = P.Id
	JOIN Flights AS F ON F.Id = T.FlightId
	ORDER BY [Full Name], Origin, Destination

---------------------------------

SELECT FirstName, LastName, Age
	FROM Passengers AS P
	LEFT JOIN Tickets AS T ON P.Id = T.PassengerId
	WHERE T.Id IS NULL
	ORDER BY Age DESC, FirstName, LastName

---------------------------------

SELECT CONCAT(P.FirstName,' ',  P.LastName) AS [Full Name],
		PL.[Name] AS [Plane Name],
		CONCAT(F.Origin,' - ',  F.Destination) AS Trip,
		LT.[Type] AS [Luggage Type]
	FROM Passengers AS P
	JOIN Tickets AS T ON T.PassengerId = P.Id
	JOIN Flights AS F ON F.Id = T.FlightId
	JOIN Planes AS PL ON PL.Id = F.PlaneId
	JOIN Luggages AS L ON L.Id = T.LuggageId
	JOIN LuggageTypes AS LT ON LT.Id = L.LuggageTypeId
	ORDER BY [Full Name], [Plane Name], Origin, Destination, [Luggage Type]

---------------------------------

SELECT [Name], Seats, COUNT(T.Id) AS [Passengers Count] 
	FROM Planes AS PL
	LEFT JOIN Flights AS F ON F.PlaneId = PL.Id
	LEFT JOIN Tickets AS T ON T.FlightId = F.Id
	GROUP BY PL.Id, PL.Name, PL.Seats
	ORDER BY [Passengers Count] DESC, [Name], Seats

---------------------------------

GO

CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(30), @destination VARCHAR(30), @peoplecount INT) 
RETURNS VARCHAR(50)
AS	
BEGIN
	DECLARE @Result VARCHAR (50);

	IF (SELECT COUNT(*) 
		FROM Flights
		WHERE Origin = @origin AND Destination = @destination) <= 0
		BEGIN
			SET @Result =  'Invalid flight!';
			RETURN @Result;
		END

	IF(@peopleCount <= 0)
		BEGIN
			SET @Result =  'Invalid people count!';
			RETURN @Result;
		END

	DECLARE @TOTAL DECIMAL(15,2);

	SET @TOTAL = @peopleCount * (SELECT top 1 Price 
							FROM Tickets AS T
							JOIN Flights AS F ON F.Id = T.FlightId
							WHERE Origin = @origin AND Destination = @destination);
	RETURN  CONCAT('Total price ',@TOTAL);
END

GO

-----------------------------------
SELECT dbo.udf_CalculateTickets ('Kolyshley', 'Rancabolang', 33)
SELECT dbo.udf_CalculateTickets ('Kolyshley', 'Rancabolang', -1)
SELECT dbo.udf_CalculateTickets ('Invalid', 'Rancabolang', 33)

-----------------------------------------------
GO

CREATE OR ALTER PROC usp_CancelFlights
AS
	WITH CTE AS
	(SELECT * FROM Flights
					WHERE ArrivalTime > DepartureTime)
	UPDATE CTE
	SET ArrivalTime = NULL, DepartureTime = NULL
	

GO

EXEC usp_CancelFlights
















