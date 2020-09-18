USE Geography


--22 All Mountain Peaks
SELECT PeakName 
	FROM Peaks
	ORDER BY PeakName

--23 Biggest Countries by Population
SELECT TOP 30 CountryName, [Population]
	FROM Countries AS c
	JOIN Continents AS cont ON cont.ContinentCode=c.ContinentCode
	WHERE cont.ContinentName='Europe'
	ORDER BY Population DESC

--24 *Countries and Currency (Euro / Not Euro)
SELECT  CountryName, CountryCode, 
	CASE 
		WHEN CurrencyCode ='EUR'
			THEN 'Euro' 
			ELSE 'Not Euro' 
		END AS [Currency]
	FROM Countries
	ORDER BY CountryName

---------
SELECT * FROM Currencies


--25 All Diablo Characters
USE Diablo

SELECT Name
	FROM Characters
	ORDER BY Name


