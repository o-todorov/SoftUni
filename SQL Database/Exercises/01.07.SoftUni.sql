
--16 Create SoftUni Database

CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
	Id		INT PRIMARY KEY IDENTITY,
	[Name]	NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Addresses(
	Id			INT PRIMARY KEY IDENTITY,
	AddressText	NVARCHAR(100) NOT NULL,
	TownId		INT NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)
	
CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Employees (
	Id			INT PRIMARY KEY IDENTITY,
	FirstName	NVARCHAR(50) NOT NULL,
	MiddleName	NVARCHAR(50),
	LastName	NVARCHAR(50) NOT NULL,
	JobTitle	NVARCHAR(30) NOT NULL,
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id),
	HireDate	DATE NOT NULL,
	Salary		DECIMAL(7,2) NOT NULL,
	AddressId	INT FOREIGN KEY REFERENCES Addresses(Id)
)

--18 Basic Insert

INSERT INTO Towns([NAME])
	VALUES
		('Sofia'),
		('Plovdiv'),
		('Varna'),
		('Burgas')

INSERT INTO Departments([NAME])
	VALUES
		('Engineering'),
		('Sales'),
		('Marketing'),
		('Software Development'),
		('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
	VALUES
		('Ivan'		, 'Ivanov'	, 'Ivanov'	, '.NET Developer'	, 4	, '02/01/2013'	, 3500.00),
		('Petar'	, 'Petrov'	, 'Petrov'	, 'Senior Engineer'	, 1	, '03/02/2004'	, 4000.00),
		('Maria'	, 'Petrova'	, 'Ivanova'	, 'Intern'			, 5	, '08/28/2016'	, 525.25),
		('Georgi'	, 'Teziev'	, 'Ivanov'	, 'CEO'				, 2	, '12/09/2007'	, 3000.00),
		('Peter'	, 'Pan'		, 'Pan'		, 'Intern'			, 3	, '08/28/2016'	, 599.88)

--19 Basic Select All Fields


SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

--20 Basic Select All Fields and Order Them
SELECT * FROM Towns
ORDER BY [NAME] ASC

SELECT * FROM Departments
ORDER BY [NAME] ASC

SELECT * FROM Employees
ORDER BY Salary DESC

--21 Basic Select Some Fields
SELECT [Name] FROM Towns
ORDER BY [NAME] ASC

SELECT [Name] FROM Departments
ORDER BY [NAME] ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees 
ORDER BY Salary DESC

--22 Increase Employees Salary
UPDATE  Employees
SET Salary = Salary * 1.1

SELECT  Salary FROM Employees
 
------------------------------------------





--SELECT * FROM Addresses

ALTER TABLE Addresses
	ADD CONSTRAINT FK_Addresses_TownId FOREIGN KEY (TownId) REFERENCES Towns(Id)

ALTER TABLE Employees
	ADD CONSTRAINT FK_Employees_DepartmentId FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
		CONSTRAINT FK_Employees_AddressId FOREIGN KEY (AddressId) REFERENCES Addresses(Id)

DROP TABLE Employees



