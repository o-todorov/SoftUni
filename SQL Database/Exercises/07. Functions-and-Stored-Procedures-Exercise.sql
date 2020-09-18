USE SoftUni
GO
-----------------
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
SELECT FirstName AS [First Name], LastName AS [Last Name]
	FROM Employees
	WHERE Salary > 35000


EXEC usp_GetEmployeesSalaryAbove35000
GO
-----------------------------
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@AboveSalary DECIMAL(18,4))
AS
	SELECT FirstName AS [First Name], LastName AS [Last Name]
		FROM Employees
		WHERE Salary >= @AboveSalary

EXEC usp_GetEmployeesSalaryAboveNumber 48100
GO
-----------------------------------

CREATE PROC usp_GetTownsStartingWith  ( @startwith VARCHAR (50) )
AS
BEGIN
	SELECT [Name] AS Town
		FROM Towns
		WHERE LEFT([Name],LEN(@startwith))=  @startwith 
END

EXEC usp_GetTownsStartingWith 'b'
GO
------------------------------------

CREATE PROC usp_GetEmployeesFromTown   ( @TownName VARCHAR (50) )
AS
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name]
		FROM Employees AS E
		JOIN Addresses AS A ON A.AddressID = E.AddressID
		JOIN Towns AS T ON T.TownID = A.TownID
		WHERE T.[Name] = @TownName
END

EXEC usp_GetEmployeesFromTown 'Sofia'
GO

--------------------------------------

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(14,2)) 
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @SalaryLevel  VARCHAR(7);
		IF @salary < 30000 
			BEGIN
				SET	@SalaryLevel = 'Low'
			END
		ELSE IF @salary <= 50000
			BEGIN
				SET	@SalaryLevel = 'Average'
			END
		ELSE
			BEGIN
				SET	@SalaryLevel = 'High'
			END
		RETURN @SalaryLevel
END;
GO

SELECT	FirstName,
		LastName,
		[dbo].[ufn_GetSalaryLevel](Salary) AS [Salary Level]
	FROM Employees

--------------------------------------
GO

CREATE  PROC usp_EmployeesBySalaryLevel (@SalaryLevel  VARCHAR(7)) 
AS
	SELECT	FirstName AS[First Name],
			LastName AS [Last Name]
		FROM Employees
		WHERE [dbo].[ufn_GetSalaryLevel](Salary) = @SalaryLevel


EXEC usp_EmployeesBySalaryLevel 'High'

--------------------------------------
GO

CREATE OR ALTER FUNCTION ufn_IsWordComprised ( @setOfLetters VARCHAR(50), @word VARCHAR(50)) 
RETURNS BIT
AS
BEGIN
	DECLARE @IsComprised BIT = 1;
	DECLARE @PosWord TINYINT = 1;

	WHILE ( @PosWord <= LEN( @word ) )
	BEGIN
		DECLARE @CH CHAR = SUBSTRING( @word, @PosWord, 1 );
		IF ( CHARINDEX ( @CH, @setOfLetters ) = 0)
		BEGIN
			SET @IsComprised = 0;
			BREAK;
		END
		SET @PosWord = @PosWord + 1;
	END
	RETURN @IsComprised;
END

GO
SELECT	dbo.ufn_IsWordComprised('BVIHLVCSJO','VHJBLOSC')

------------------------------------------------
GO
USE master
--DROP DATABASE SoftUni
USE SoftUni
SELECT * FROM Departments
SELECT * FROM EmployeesProjects

------------------------------------------------
GO		
CREATE PROC usp_DeleteEmployeesFromDepartment  (@departmentId INT)
AS
	ALTER TABLE Departments
		ALTER COLUMN ManagerID INT  NULL

	UPDATE Departments
		SET ManagerID = NULL 
		WHERE ManagerID IN (SELECT EmployeeID FROM Employees
							WHERE DepartmentID = @departmentId)

	DELETE	FROM EmployeesProjects
		WHERE EmployeeID IN (SELECT EmployeeID FROM Employees
							WHERE DepartmentID = @departmentId)

	UPDATE Employees
		SET ManagerID = NULL 
		WHERE ManagerID IN (SELECT EmployeeID FROM Employees
							WHERE DepartmentID = @departmentId)

	DELETE FROM Employees 
		WHERE DepartmentID = @departmentId

	DELETE FROM Departments
		WHERE DepartmentID = @departmentId

	SELECT COUNT(*)
		FROM Employees
		WHERE DepartmentID = @departmentId


GO

EXEC usp_DeleteEmployeesFromDepartment  2		
GO	

----------------------------------------------------

SELECT * FROM Employees ORDER BY DepartmentID


--===============================================================
--===============================================================
USE Bank

-------------------------------------------
GO

CREATE PROC usp_GetHoldersFullName 
AS
	SELECT CONCAT(FirstName, ' ', LastName) AS[Full Name]
		FROM AccountHolders

EXEC usp_GetHoldersFullName
------------------------------------------------
GO

CREATE PROC usp_GetHoldersWithBalanceHigherThan (@SUM MONEY)
AS
	SELECT FirstName AS [First Name], LastName AS [Last Name]
		FROM AccountHolders AS AH
		WHERE (SELECT  SUM( A.Balance )
				FROM Accounts AS A
				WHERE A.AccountHolderId = AH.Id
				GROUP BY A.AccountHolderId) > @SUM
	ORDER BY FirstName, LastName
GO
EXEC usp_GetHoldersWithBalanceHigherThan 10000

----------------------------------------
GO

CREATE FUNCTION ufn_CalculateFutureValue 
	(@sum DECIMAL (14,4), @yearlyRate FLOAT, @years TINYINT) 
RETURNS DECIMAL (14,4)
AS
BEGIN
	DECLARE @RETSUM DECIMAL (14,4)

	SET @RETSUM = POWER(1 + @yearlyRate,@years) * @sum

	RETURN @RETSUM
END

GO
SELECT dbo.ufn_CalculateFutureValue( 1000, 0.1, 5)
	
	--==================================================
GO

CREATE PROC usp_CalculateFutureValueForAccount (@AccountId INT, @yearlyRate FLOAT)
AS
	DECLARE @YEARS TINYINT;
	SET @YEARS = 5;
	SELECT A.Id AS [Account Id], AH.FirstName AS [First Name], AH.LastName AS [First Name], A.Balance AS [Current Balance], 
			dbo.ufn_CalculateFutureValue( A.Balance, 0.1, @YEARS) AS [Balance in 5 years]
		FROM Accounts AS A
		INNER JOIN AccountHolders AS AH ON AH.Id = A.AccountHolderId
		WHERE A.Id = @AccountId
GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1

--=====================================================
--3.	Queries for Diablo Database

USE Diablo
--=====================================================

GO
CREATE FUNCTION ufn_CashInUsersGames   ( @Game NVARCHAR(50)) 
RETURNS TABLE
AS
RETURN(
	SELECT SUM(SEL.Cash) AS SumCash FROM
		(SELECT	Cash, ROW_NUMBER ()OVER (PARTITION BY GameId 
				ORDER BY Cash DESC) AS RowNum
			FROM UsersGames
			JOIN Games AS G ON G.Id = UsersGames.GameId
			WHERE G.[Name] = @Game) AS SEL
	WHERE RowNum % 2 = 1
)
GO

SELECT 	[dbo].[ufn_CashInUsersGames] ('Love in a mist')

DROP [ufn_ufn_CashInUsersGames]
























