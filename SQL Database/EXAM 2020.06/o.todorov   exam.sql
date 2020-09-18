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


---------12------------------------------------


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