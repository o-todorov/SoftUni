USE Gringotts

SELECT * 
	FROM WizzardDeposits
	ORDER BY FirstName
	
SELECT COUNT ( * ) AS [Count] FROM WizzardDeposits

SELECT  MAX(w.MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits AS w

SELECT TOP 2 DepositGroup
	FROM (SELECT  W.DepositGroup, AVG(w.MagicWandSize) AS AvgSize
			FROM WizzardDeposits AS W
			GROUP BY W.DepositGroup ) AS Sm
	ORDER BY Sm.AvgSize

SELECT W.DepositGroup,SUM (W.[DepositAmount])
	FROM WizzardDeposits AS W
	GROUP BY W.DepositGroup


SELECT W.DepositGroup,SUM (W.[DepositAmount]) AS [TotalSum]
	FROM WizzardDeposits AS W
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY W.DepositGroup


SELECT DepositGroup,SUM (DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
	HAVING SUM (DepositAmount) < 150000
	ORDER BY TotalSum DESC
	   

SELECT DepositGroup,MagicWandCreator,MIN(W1.DepositCharge)
	FROM WizzardDeposits AS W1
	GROUP BY W1.DepositGroup,MagicWandCreator


SELECT AgeGroup,COUNT(*) AS WizardCount
	FROM (SELECT 
				(CASE 
					WHEN Age <=10 THEN	'[0-10]'
					WHEN Age <=20 THEN	'[11-20]'
					WHEN Age <=30 THEN	'[21-30]'
					WHEN Age <=40 THEN	'[31-40]'
					WHEN Age <=50 THEN	'[41-50]'
					WHEN Age <=60 THEN	'[51-60]'
					ELSE				'[61+]'
				END)AS AgeGroup
			FROM WizzardDeposits) AS AgeGroups
	GROUP BY AgeGroup

SELECT LEFT([FirstName],1) AS FirstLetter
	FROM WizzardDeposits
	WHERE DepositGroup = 'Troll Chest'
	GROUP BY LEFT([FirstName],1)
	ORDER BY FirstLetter

SELECT DepositGroup, IsDepositExpired,AVG(W.DepositInterest) AS AverageInterest
	FROM WizzardDeposits AS W
	WHERE DepositStartDate > '01-01-1985'
	GROUP BY DepositGroup, IsDepositExpired
	ORDER BY DepositGroup DESC, IsDepositExpired

SELECT * FROM WizzardDeposits

--10. * Rich Wizard, Poor Wizard

SELECT SUM([Difference]) AS SumDifference FROM
	(SELECT	FirstName AS [Host Wizard],
			DepositAmount AS [Host Wizard Deposit],
			LEAD(FirstName) OVER ( ORDER BY Id ) AS [Guest Wizard],
			LEAD(DepositAmount) OVER ( ORDER BY Id ) AS [Guest Wizard Deposit],
			DepositAmount - LEAD(DepositAmount) OVER ( ORDER BY Id ) AS [Difference]
		FROM WizzardDeposits) AS DIFF
		WHERE [Guest Wizard] IS NOT NULL

SELECT SUM([Difference]) AS SumDifference FROM
	(SELECT	w.FirstName AS [Host Wizard],
			w.DepositAmount AS [Host Wizard Deposit],
			w2.FirstName AS [Guest Wizard],
			w2.DepositAmount  AS [Guest Wizard Deposit],
			w.DepositAmount - w2.DepositAmount  AS [Difference]
		FROM	WizzardDeposits AS w,
				WizzardDeposits AS w2
		WHERE w.Id = w2.Id-1) AS Diff
	WHERE [Guest Wizard] IS NOT NULL
---------------------------
USE SoftUni

SELECT * FROM Employees

SELECT DepartmentID, SUM(Salary) AS TotalSalary
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY DepartmentID

SELECT DepartmentId, MIN(Salary) AS MinimumSalary
	FROM Employees
	WHERE HireDate > '01-01-2000'
	GROUP BY DepartmentID
	HAVING DepartmentID IN (2, 5, 7)

--13. Employees Average Salaries------------
SELECT * INTO #TBL
				FROM Employees
				WHERE Salary > 30000

DELETE  FROM #TBL
	WHERE  ManagerID=42

UPDATE #TBL
SET Salary = Salary + 5000
	WHERE DepartmentID = 1

SELECT DepartmentID, AVG (Salary) AS AverageSalary
	FROM #TBL
	GROUP BY DepartmentID

SELECT *  FROM #TBL

DROP TABLE #TBL

----------------------------

SELECT DepartmentID, MAX(Salary) AS MaxSalary
	FROM Employees
	GROUP BY DepartmentID
	HAVING MAX(Salary) < 30000 OR MAX(Salary) > 70000

SELECT	COUNT ( * )
	FROM Employees
	WHERE ManagerID IS NULL

	--16. *3rd Highest Salary
SELECT DepartmentID, Salary FROM Employees ORDER BY DepartmentID, Salary DESC

SELECT DepartmentID, Salary AS ThirdHighestSalary
	FROM	(SELECT DepartmentID,Salary,
					DENSE_RANK ( ) OVER ( PARTITION BY DepartmentID ORDER BY Salary DESC ) AS RankSelection
			FROM Employees
			GROUP BY DepartmentID, Salary) AS R
	WHERE RankSelection = 3 AND Salary IS NOT NULL


	--NOT WORKING
SELECT * FROM(
		SELECT DISTINCT	E.DepartmentID, 
				( SELECT E1.Salary
				FROM Employees AS E1
				WHERE E1.DepartmentID = E.DepartmentID
				ORDER BY E1.Salary DESC 
				OFFSET  2 ROWS 
				FETCH NEXT 1 ROWS ONLY	) AS ThirdHighestSalary
		FROM Employees AS E
		GROUP BY E.DepartmentID
		) AS SEC2
WHERE ThirdHighestSalary IS NOT NULL

	--17. **Salary Challenge




SELECT TOP 10	E.FirstName, 
				E.LastName,	
				E.DepartmentID
		FROM Employees AS E
		WHERE E.Salary > (
				SELECT AVG(E1.Salary)
					FROM Employees AS E1
					WHERE E1.DepartmentID = E.DepartmentID
					GROUP BY E1.DepartmentID )
		ORDER BY E.DepartmentID





