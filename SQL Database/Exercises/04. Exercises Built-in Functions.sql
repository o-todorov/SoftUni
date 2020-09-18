USE SoftUni

--	Problem 1.	Find Names of All Employees by First Name

SELECT FirstName, LastName
FROM Employees
WHERE LEFT(FirstName,2) = 'SA' 

--Problem 2.	  Find Names of All employees by Last Name 

SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%' 

--	Problem 3.	Find First Names of All Employees

SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10) AND 
	1995<=DATEPART(yyyy,HireDate) AND  DATEPART(yyyy,HireDate)<=2005 

	--	Problem 4
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%' 

--	Problem 5
SELECT [Name]
	FROM Towns
	WHERE LEN([Name]) IN (5,6)
	ORDER BY [Name]

--	Problem 6
SELECT TownID, [Name] 
	FROM Towns
	WHERE LEFT([Name], 1)  IN ('M', 'K', 'B', 'E')
	ORDER BY [Name]

--	Problem 7
SELECT TownID, [Name] 
	FROM Towns
	WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
	ORDER BY [Name]

--	Problem 8
CREATE VIEW V_EmployeesHiredAfter2000 AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE 	DATEPART(yyyy,HireDate)  > 2000

SELECT * 
FROM V_EmployeesHiredAfter2000 
karamba

--	Problem 9
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

--	Problem 10.	
--	Rank Employees by Salary
SELECT  TOP 10 [EmployeeID], [FirstName], [LastName], [Salary],
	RANK() OVER( PARTITION BY Salary
		ORDER BY [EmployeeID] ) AS [Rank]
	FROM Employees

SELECT TOP 20 [EmployeeID], [FirstName], [LastName], [Salary],
	DENSE_RANK() OVER( PARTITION BY Salary
		ORDER BY [LastName] DESC) AS [Rank]
	FROM Employees

--	SOLVE:

SELECT  [EmployeeID], [FirstName], [LastName], [Salary],
	DENSE_Rank() OVER( PARTITION BY Salary
		ORDER BY [EmployeeID] ) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC

---   Problem 11.	Find All Employees with Rank 2 *

SELECT * FROM
(SELECT  [EmployeeID], [FirstName], [LastName], [Salary],
	DENSE_Rank() OVER( PARTITION BY Salary
		ORDER BY [EmployeeID] ) AS [Rank]
	FROM Employees) AS E
	WHERE Salary BETWEEN 10000 AND 50000 AND [Rank] = 2
	ORDER BY Salary DESC

--	Problem 12.	Countries Holding ‘A’ 3 or More Times
USE Geography

SELECT CountryName AS [Country Name], IsoCode AS [Iso Code]
	FROM Countries
	WHERE CountryName LIKE '%A%A%A%'
	ORDER BY [Iso Code]

--	Problem 13.	 Mix of Peak and River Names

SELECT PeakName, RiverName,
		LOWER(P.PeakName + RIGHT(R.RiverName, LEN(R.RiverName)-1) ) AS Mix
	FROM Peaks AS P
	JOIN Rivers AS R ON LEFT(R.RiverName,1) = RIGHT(P.PeakName,1)
	ORDER BY Mix

SELECT PeakName, RiverName,
		LOWER(CONCAT(P.PeakName, RIGHT(R.RiverName, LEN(R.RiverName)-1) ) )AS Mix
	FROM Peaks AS P
	JOIN Rivers AS R ON LEFT(R.RiverName,1) = RIGHT(P.PeakName,1)
	ORDER BY Mix

SELECT P.PeakName , R.RiverName , LOWER(CONCAT(P.PeakName, RIGHT(R.RiverName, LEN(R.RiverName)-1) ) )AS Mix
	FROM Peaks AS P,  Rivers AS R
	WHERE LEFT(R.RiverName,1) = RIGHT(P.PeakName,1)
	ORDER BY Mix

--	Part III – Queries for Diablo Database
--	Problem 14.	Games from 2011 and 2012 year

USE Diablo

SELECT TOP 50 [Name], FORMAT([Start],'yyy-MM-dd') AS [Start]
	FROM Games
	WHERE DATEPART(year , [Start]) IN ( 2011, 2012)
	ORDER BY [Start], [Name]

--	Problem 15.	 User Email Providers

SELECT Username, RIGHT(Email,LEN(Email)-  CHARINDEX('@', Email) ) AS [Email Provider]
	FROM Users
	ORDER BY [Email Provider], Username

--	Problem 16.	 Get Users with IPAdress Like Pattern

SELECT Username, IpAddress AS [Ip Address]
	FROM Users
	WHERE IpAddress LIKE '___.1_%._%.___' 
	ORDER BY Username

--	Problem 17.	 Show All Games with Duration and Part of the Day

SELECT [Name] AS Game,

		CASE 
			WHEN DATEPART(hour,[Start])>=0 AND DATEPART(hour,[Start])<12 THEN 'Morning'
			WHEN DATEPART(hour,[Start])<18 THEN 'Afternoon'
			ELSE 'Evening'
		END	AS [Part of the Day], 

		CASE 
			WHEN Duration<=3 THEN 'Extra Short'
			WHEN Duration<=6 THEN 'Short'
			WHEN Duration>6 THEN 'Long '
			ELSE 'Extra Long'
		END	AS [Duration]
		
	FROM Games
	ORDER BY [Name], Duration, [Part of the Day]

--	Problem 18.	 Orders Table

SELECT ProductName, OrderDate, 
	DATEADD(day, 3, OrderDate) AS [Pay Due],
	DATEADD(month, 1, OrderDate) AS [Deliver Due]
	FROM Orders



