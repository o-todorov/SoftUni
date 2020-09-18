
--	Problem 1.	Employee Address
USE SoftUni

SELECT TOP 5 EmployeeID, JobTitle, e.AddressID, a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	ORDER BY e.AddressID

SELECT * FROM Employees

--	Problem 2.	Addresses with Towns

SELECT TOP 50 e.FirstName, e.LastName, t.[Name] AS Town, a.AddressText
	FROM Addresses AS a
	RIGHT JOIN Employees AS e ON a.AddressID = e.AddressID
	LEFT JOIN Towns AS t ON t.TownID = a.TownID
	ORDER BY e.FirstName, e.LastName
	
--	Problem 3.	Sales Employee

SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS [DepartmentName]
	FROM  Employees AS e 
	JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name='Sales'
	ORDER BY e.EmployeeID

--	Problem 4.	Employee Departments

SELECT TOP 5 E.EmployeeID, E.FirstName, E.Salary, d.[Name] AS [DepartmentName]
	FROM Employees AS E
	JOIN Departments AS d ON d.DepartmentID = E.DepartmentID
	WHERE E.Salary>15000
	ORDER BY d.DepartmentID

--	Problem 5.	Employees Without Project

SELECT TOP 3 E.EmployeeID, E.FirstName
	FROM EmployeesProjects AS EP
	RIGHT JOIN Employees AS E ON E.EmployeeID = EP.EmployeeID
	WHERE EP.EmployeeID IS NULL
	ORDER BY E.EmployeeID

--	Problem 6.	Employees Hired After

SELECT  E.FirstName, E.LastName, E.HireDate, 
		d.[Name] AS 'DeptName'
	FROM Employees AS E
	JOIN Departments AS d ON d.DepartmentID = E.DepartmentID
	WHERE E.HireDate>'1999-01-01' 
		AND d.[Name] IN ('Sales', 'Finance')
	ORDER BY E.HireDate

--	Problem 7.	Employees with Project

SELECT TOP 5 E.EmployeeID, E.FirstName, P.[Name] AS ProjectName
	FROM EmployeesProjects AS EP
	JOIN Employees AS E ON E.EmployeeID = EP.EmployeeID
	JOIN Projects AS P ON P.ProjectID = EP.ProjectID
	WHERE P.StartDate>'2002-08-13' 
		AND P.EndDate IS NULL
	ORDER BY E.EmployeeID

	--Problem 8.	Employee 24

SELECT E.EmployeeID, E.FirstName,
		CASE
			WHEN DATEPART(year, P.StartDate) >= 2005
				THEN NULL
			ELSE  P.[Name]
		END AS ProjectName
	FROM EmployeesProjects AS EP
	JOIN Employees AS E ON E.EmployeeID = EP.EmployeeID
	JOIN Projects AS P ON P.ProjectID = EP.ProjectID
	WHERE E.EmployeeID = 24

SELECT E.EmployeeID, E.FirstName, P.[Name], P.StartDate
	FROM EmployeesProjects AS EP
	JOIN Employees AS E ON E.EmployeeID = EP.EmployeeID
	JOIN Projects AS P ON P.ProjectID = EP.ProjectID
	WHERE E.EmployeeID = 24

--	Problem 9.	Employee Manager

SELECT E.EmployeeID, E.FirstName, E.ManagerID, M.FirstName AS ManagerName
	FROM Employees AS E
	JOIN Employees AS M ON E.ManagerID=M.EmployeeID
	WHERE M.EmployeeID IN (3, 7)
	ORDER BY E.EmployeeID

	-- Problem 10.	Employee Summary

SELECT * 
	FROM 
(SELECT M.FirstName + ' ' + M.LastName AS ManagerName,
		D.[Name] AS DepartmentName
	FROM Departments AS D
	JOIN Employees AS M ON D.ManagerID = M.EmployeeID) AS S
	
SELECT  TOP 50 E.EmployeeID, 
		E.FirstName + ' ' + E.LastName AS EmployeeName,
		M.FirstName + ' ' + M.LastName AS ManagerName, 
		D.[Name] AS DepartmentName
	FROM Employees AS E
	JOIN Departments AS D ON D.DepartmentID = E.DepartmentID
	JOIN Employees AS M ON E.ManagerID = M.EmployeeID
	ORDER BY E.EmployeeID

	-- Problem 11.	Min Average Salary

USE SoftUni

SELECT TOP 1 AVG(E.Salary) AS MinAverageSalary
	FROM Employees AS E
	GROUP BY E.DepartmentID
	ORDER BY MinAverageSalary 

	 -- OR

SELECT MIN(A.AverageSalary) AS MinAverageSalary
	FROM 
	(SELECT AVG(E.Salary) AS AverageSalary
		FROM Employees AS E
		GROUP BY E.DepartmentID ) AS A

		-- Problem 12.	Highest Peaks in Bulgaria

USE Geography

SELECT CM.CountryCode, CM.MountainRange, P.PeakName, P.Elevation
	FROM Peaks AS P
	JOIN 
	(SELECT C.CountryCode, M.MountainRange, M.Id
		FROM MountainsCountries AS MK
		JOIN Mountains AS M ON M.Id = MK.MountainId
		JOIN Countries AS C ON C.CountryCode = MK.CountryCode
		WHERE C.CountryName = 'Bulgaria') AS CM
		ON P.MountainId = CM.Id
	WHERE P.Elevation > 2835
	ORDER BY P.Elevation DESC

	-- Problem 13.	Count Mountain Ranges

SELECT MC.CountryCode, COUNT(MountainId)
	FROM MountainsCountries AS MC
	JOIN Countries AS C ON C.CountryCode = MC.CountryCode
	WHERE C.CountryName IN ('United States', 'Russia', 'Bulgaria')
	GROUP BY MC.CountryCode

	--Problem 14.	Countries with Rivers
SELECT C.CountryName 
	FROM Continents AS CON
	JOIN Countries AS C ON C.ContinentCode = CON.ContinentCode

SELECT TOP 5 C.CountryName,R.RiverName
	FROM CountriesRivers AS CR
	RIGHT JOIN Countries AS C ON C.CountryCode = CR.CountryCode
	LEFT JOIN Rivers AS R ON R.Id = CR.RiverId
	JOIN Continents AS CON ON CON.ContinentCode = C.ContinentCode
	WHERE CON.ContinentName = 'Africa'
	ORDER BY C.CountryName

	--Problem 15.	*Continents and Currencies

SELECT  C1.ContinentCode, C1.CurrencyCode, COUNT(C1.CurrencyCode) AS CurrencyUsage
	FROM Countries C1
	GROUP BY C1.ContinentCode, C1.CurrencyCode
	HAVING COUNT(C1.CurrencyCode)> 1 AND 
		COUNT(C1.CurrencyCode)=  (SELECT TOP 1  COUNT(CurrencyCode) AS CurrencyC
									FROM Countries AS C2
									WHERE C2.ContinentCode = C1.ContinentCode
									GROUP BY C2.ContinentCode, C2.CurrencyCode
									ORDER BY CurrencyC DESC )
	ORDER BY C1.ContinentCode

--Problem 16.	Countries without any Mountains

SELECT COUNT(*)
	FROM MountainsCountries AS MC
	RIGHT JOIN Countries AS C ON C.CountryCode = MC.CountryCode
	WHERE MC.CountryCode IS NULL

	--Problem 17.	Highest Peak and Longest River by Country

SELECT TOP 5 C.CountryName, 
			(SELECT MAX(P.Elevation) FROM Peaks AS P
				RIGHT JOIN Mountains AS M ON M.Id = P.MountainId
				RIGHT JOIN MountainsCountries AS MC ON MC.MountainId = M.Id
				WHERE MC.CountryCode = C.CountryCode
			) AS HighestPeakElevation,

			(SELECT MAX(R.Length) FROM Rivers AS R  
				JOIN CountriesRivers AS CR ON CR.RiverId = R.Id
				WHERE CR.CountryCode = C.CountryCode
			) AS LongestRiverLength

	FROM Countries AS C
	ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, C.CountryName

	--OR ---
	
SELECT TOP 5 C.CountryName, 
			MAX(P.Elevation)	AS HighestPeakElevation,
			MAX(R.[Length])		AS LongestRiverLength

	FROM Countries AS C
	LEFT JOIN MountainsCountries AS MC	ON MC.CountryCode = C.CountryCode
	LEFT JOIN Mountains			AS M	ON M.Id = MC.MountainId
	LEFT JOIN Peaks				AS P	ON P.MountainId = M.Id
	LEFT JOIN CountriesRivers	AS CR	ON CR.CountryCode = C.CountryCode
	LEFT JOIN Rivers			AS R	ON  R.Id = CR.RiverId
	GROUP BY C.CountryName
	ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, C.CountryName

	--Problem 18.	* Highest Peak Name and Elevation by Country




SELECT TOP 5 C.CountryName AS Country, 
			CASE 
					WHEN	P.PeakName IS NULL
					THEN	'(no highest peak)' 
					ELSE	P.PeakName
			END AS [Highest Peak Name],

			CASE 
					WHEN	P.PeakName IS NULL
					THEN	0 
					ELSE	P.Elevation
			END AS [Highest Peak Elevation],

			CASE 
					WHEN	P.PeakName IS NULL
					THEN	'(no mountain)'
					ELSE	M.MountainRange
			END AS [Mountain]
			
	FROM Countries AS C
	LEFT JOIN MountainsCountries AS MC ON MC.CountryCode = C.CountryCode
	LEFT JOIN Mountains AS M ON M.Id = MC.MountainId
	LEFT JOIN Peaks AS P ON P.MountainId = M.Id

	WHERE	 
			P.Elevation = (
					SELECT MAX(P.Elevation) FROM Peaks AS P
					RIGHT JOIN Mountains AS M ON M.Id = P.MountainId
					RIGHT JOIN MountainsCountries AS MC ON MC.MountainId = M.Id
					WHERE MC.CountryCode = C.CountryCode
				)
			 OR P.Elevation IS NULL
	ORDER BY C.CountryName, [Highest Peak Elevation] DESC