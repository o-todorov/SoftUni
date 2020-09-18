USE ColonialJourney

INSERT INTO Planets
	VALUES
	('Mars'),
	('Earth'),
	('Jupiter'),
	('Saturn')
	
INSERT INTO Spaceships
	VALUES
	('Golf'		, 'VW'		, 3 ),
	('WakaWaka'	, 'Wakanda'	, 4 ),
	('Falcon9'	, 'SpaceX'	, 1 ),
	('Bed'		, 'Vidolov'	, 6 )


UPDATE Spaceships
	SET LightSpeedRate += 1
	WHERE Id BETWEEN 8 AND 12


----4-------------------------------------

DELETE  FROM TravelCards
	WHERE JourneyId IN (SELECT TOP(3) Id FROM Journeys)

DELETE TOP (3) FROM Journeys



---5 ------------------------


SELECT	Id, 
		FORMAT(JourneyStart,'dd/MM/yyyy') AS JourneyStart,
		FORMAT(JourneyEnd,'dd/MM/yyyy') AS JourneyEnd
	FROM Journeys
	WHERE Purpose LIKE 'Military'
	ORDER BY JourneyStart

---6 ------------------------


SELECT C.Id, CONCAT(C.FirstName, ' ', C.LastName) AS full_name
	FROM Colonists AS C
	INNER JOIN TravelCards AS TC ON TC.ColonistId = C.Id
	WHERE TC.JobDuringJourney LIKE 'Pilot'
	ORDER BY C.Id

	---7 ------------------------


SELECT COUNT(C.Id) AS count
	FROM Colonists AS C
	INNER JOIN TravelCards AS TC ON TC.ColonistId = C.Id
	INNER JOIN Journeys AS J ON J.Id = TC.JourneyId
	WHERE J.Purpose LIKE 'Technical'

---8 ------------------------

SELECT S.[Name], S.Manufacturer
	FROM Spaceships AS S
	WHERE S.Id IN(
					SELECT J.SpaceshipId 
						FROM Colonists AS C
						JOIN TravelCards AS TC ON TC.ColonistId = C.Id
						JOIN Journeys AS J ON J.Id = TC.JourneyId
						WHERE TC.JobDuringJourney LIKE 'Pilot' AND
							DATEDIFF(YEAR,C.BirthDate,'01/01/2019') < 30)
	ORDER BY S.[Name]


	---------------9-------------

SELECT P.[Name] AS PlanetName
	FROM Planets AS P
	LEFT JOIN Spaceports AS SP ON SP.PlanetId = P.Id

SELECT P.[Name] AS PlanetName,COUNT(J.Id) AS JourneysCount
	FROM Journeys AS J
	JOIN Spaceports AS SP ON SP.Id = J.DestinationSpaceportId
	JOIN Planets AS P ON P.Id = SP.PlanetId
	GROUP BY P.Name
	ORDER BY JourneysCount DESC, PlanetName ASC

	-----------------10---------------

SELECT * FROM(

			SELECT	TC.JobDuringJourney,
					CONCAT(C.FirstName, ' ', C.LastName ) AS FullName,
					DENSE_RANK () OVER (PARTITION BY TC.JobDuringJourney ORDER BY C.BirthDate 	) AS JobRank
				FROM Colonists AS C
				JOIN TravelCards AS TC ON TC.ColonistId = C.Id
				JOIN Journeys AS J ON J.Id = TC.JourneyId) AS R

		WHERE JobRank = 2

--------------11-----------------------

GO

CREATE OR ALTER FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR(30))

RETURNS INT
AS

BEGIN

	DECLARE @ThisPlanetColonistsCount INT=
		(SELECT COUNT(TC.ColonistId)AS Count
			FROM TravelCards AS TC
			JOIN Journeys AS J ON J.Id = TC.JourneyId
			JOIN Spaceports AS SP ON SP.Id = J.DestinationSpaceportId
			JOIN Planets AS P ON P.Id = SP.PlanetId
			WHERE P.[Name] = @PlanetName
			GROUP BY P.[Name])

	RETURN @ThisPlanetColonistsCount ;
END


GO


SELECT		dbo.udf_GetColonistsCount('Otroyphus')AS COUNT

--------------12-----------------------

GO

CREATE  PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
	IF (SELECT COUNT(*) FROM Journeys WHERE Id = @JourneyId) =0
		BEGIN
			THROW 50001, 'The journey does not exist!',1;
		END

	IF (SELECT Purpose FROM Journeys WHERE Id = @JourneyId) =@NewPurpose
		BEGIN
			THROW 50001, 'You cannot change the purpose!',1;
		END

	UPDATE Journeys
		SET Purpose = @NewPurpose
		WHERE Id = @JourneyId

GO


EXEC usp_ChangeJourneyPurpose 4, 'Technical'
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'

-----------------------------------------------------------
		SELECT  COUNT(C.Id) AS [Count]
			FROM Colonists AS C
			JOIN TravelCards AS TC ON TC.ColonistId = C.Id
			JOIN Journeys AS J ON J.Id = TC.JourneyId
			JOIN Spaceports AS SP ON SP.Id = J.DestinationSpaceportId
			JOIN Planets AS P ON P.Id = SP.PlanetId
			GROUP BY P.[Name]
			ORDER BY Count

		SELECT  COUNT(TC.ColonistId) AS Count
			FROM TravelCards AS TC
			JOIN Journeys AS J ON J.Id = TC.JourneyId
			JOIN Spaceports AS SP ON SP.Id = J.DestinationSpaceportId
			--JOIN Planets AS P ON P.Id = SP.PlanetId
			GROUP BY SP.PlanetId
			ORDER BY Count








