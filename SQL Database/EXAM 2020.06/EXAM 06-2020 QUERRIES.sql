USE TripService
--------2------------------------------

INSERT INTO Accounts 
	VALUES
( 'John',		'Smith',		'Smith',		34,	'1975-07-21',	'j_smith@gmail.com'),
( 'Gosho',		NULL,			'Petrov',		11,	'1978-05-16',	'g_petrov@gmail.com'),
( 'Ivan',		'Petrovich',	'Pavlov',		59,	'1849-09-26',	'i_pavlov@softuni.bg'),
( 'Friedrich',	'Wilhelm',		'Nietzsche',	2,	'1844-10-15',	'f_nietzsche@softuni.bg')



INSERT INTO Trips
	VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)


---------3------------------------------------

UPDATE Rooms
	SET Price=Price * 1.14
	WHERE HotelId IN (5, 7, 9)


---------4------------------------------------

DELETE FROM AccountsTrips
	WHERE AccountId = 47

---------5------------------------------------

SELECT A.FirstName, 
		A.LastName, 
		FORMAT(A.BirthDate, 'MM-dd-yyyy') AS BirthDate, 
		C.[Name] AS [Hometown],
		A.Email
	FROM Accounts AS A
	JOIN Cities AS C ON C.Id = A.CityId
	WHERE LEFT(Email,1) = 'e'
	ORDER BY [Hometown]

---------6------------------------------------

SELECT C.[Name] AS City, COUNT(H.Id) AS Hotels
	FROM Cities AS C
	JOIN Hotels AS H ON H.CityId = C.Id
	GROUP BY C.[Name]
	ORDER BY Hotels DESC, C.[Name] ASC

---------7------------------------------------


SELECT K.AccountId, 
		K.FullName,
		MAX(DIFF) AS LongestTrip, 
		MIN(DIFF) AS ShortestTrip
	FROM (
			SELECT AT.AccountId,
			DATEDIFF(day,ArrivalDate, T.ReturnDate )  AS DIFF,
			CONCAT(A.FirstName ,' ', A.LastName) as [FullName]
				FROM AccountsTrips AS AT
				JOIN Trips AS T ON T.Id = AT.TripId
				JOIN Accounts AS A ON A.Id = AT.AccountId
				WHERE T.CancelDate IS NULL AND A.MiddleName IS NULL) AS K
	GROUP BY K.AccountId, K.FullName
	ORDER BY LongestTrip DESC, ShortestTrip



---------8------------------------------------


SELECT TOP 10 C.Id, 
		C.Name AS City, 
		C.CountryCode AS Country,
		COUNT( A.Id) AS [Accounts]
	FROM Cities AS C
	JOIN Accounts AS A ON A.CityId = C.Id
	GROUP BY C.Id, C.Name, C.CountryCode
	ORDER BY [Accounts] DESC

---------9------------------------------------



SELECT A.Id, A.Email, C.[Name], COUNT(T.Id) AS [Trips]
	FROM Accounts AS A
	JOIN Cities AS C ON C.Id = A.CityId
	JOIN AccountsTrips AS AT ON AT.AccountId = A.Id
	JOIN Trips AS T ON AT.TripId = T.Id
	JOIN Rooms AS R ON R.Id = T.RoomId
	JOIN Hotels AS H ON H.Id = R.HotelId
	WHERE C.Id = H.CityId
	GROUP BY A.Id, A.Email, C.[Name]
	ORDER BY [Trips] DESC, A.Id


---------10------------------------------------

SELECT	T.Id,
		CONCAT( A.FirstName, ' ', A.MiddleName, ' ' ,A.LastName) AS FullName,
		C.[Name] AS [From],
		CH.[Name] AS [To],
		CASE 
			WHEN(T.CancelDate IS NULL )
				THEN	CONCAT( DATEDIFF(day,T.ArrivalDate, T.ReturnDate),' days')
			ELSE'Canceled'
		END AS [Duration]

	FROM Trips AS T
	LEFT JOIN AccountsTrips AS AT ON AT.TripId = T.Id
	JOIN Accounts AS A ON A.Id = AT.AccountId
	JOIN Cities AS C ON C.Id = A.CityId
	JOIN Rooms AS R ON R.Id = T.RoomId
	JOIN Hotels AS H ON H.Id = R.HotelId
	JOIN Cities AS CH ON CH.Id = H.CityId
	ORDER BY FullName, T.Id

	EXPECTED
Phoenix
Omsk
Canceled
835
Daron Fina B...   <--????

	QUERY
Phoenix
Omsk
Canceled
835
Daron Fina...

---------11------------------------------------
GO
CREATE OR ALTER FUNCTION udf_GetAvailableRoom(@HotelId INT , @Date DATETIME2, @People INT)
RETURNS VARCHAR(70)
AS
BEGIN
	DECLARE @RESULT VARCHAR(70);

	DECLARE @ROOM INT;
	SET @ROOM = (
			SELECT TOP 1 R.Id
				FROM Trips AS T
				JOIN Rooms AS R ON R.Id = T.RoomId
				WHERE R.HotelId = @HotelId AND (@Date NOT BETWEEN  T.ArrivalDate AND    T.ReturnDate)
				ORDER BY R.Price DESC)

	IF(@ROOM > 0)
		BEGIN
			DECLARE @Rprice DECIMAL (10,2) =
				( SELECT Price FROM Rooms WHERE Id = @ROOM) +
				(SELECT BaseRate FROM Hotels WHERE Id = @HotelId) ;
				
			SET @Rprice = @Rprice * @People

			SET @RESULT = CONCAT('Room ', @ROOM, ': ', 
				(SELECT [Type] FROM Rooms WHERE Id = @ROOM), ' (', 
				(SELECT Beds FROM Rooms WHERE Id = @ROOM), ' beds) - $',
				@Rprice * @People)
		END

	ELSE
		BEGIN
			 SET @RESULT =  'No rooms available';
		END

	RETURN @RESULT;
END

SELECT dbo.udf_GetAvailableRoom( 112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(1, '2015-07-26', 3)




GO
CREATE PROC usp_SwitchRoom (@TripId INT , @TargetRoomId INT)
AS
	DECLARE @HOTELID INT;
	IF(	SELECT HotelId	FROM Rooms 	WHERE Id = @TargetRoomId) != 
		(	SELECT HotelId	FROM Rooms AS R
			JOIN Trips AS T ON T.RoomId = R.Id WHERE T.Id = @TripId) 

			BEGIN;
				THROW  90001, 'Target room is in another hotel!',1
				RETURN;
			END;

		IF(	SELECT Beds	FROM Rooms 	WHERE Id = @TargetRoomId) < 
			(	SELECT Beds	FROM Rooms AS R
				JOIN Trips AS T ON T.RoomId = R.Id WHERE T.Id = @TripId) 
			BEGIN;
				THROW  90001, 'Not enough beds in target room!',1
				RETURN;
			END;

		UPDATE Trips
			SET RoomId = @TargetRoomId

		SELECT @TargetRoomId

GO
EXEC usp_SwitchRoom 10, 8
SELECT RoomId FROM Trips WHERE Id = 10

SELECT Id, Beds	FROM Rooms
SELECT Id, Beds	FROM Rooms

SELECT Id, Beds	FROM Rooms 	WHERE Id = 8
SELECT T.Id, R.Id,R.Beds	FROM Rooms AS R
				JOIN Trips AS T ON T.RoomId = R.Id WHERE T.Id = 10
