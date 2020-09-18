
CREATE DATABASE MyTest
GO
USE MyTest


USE master
GO
DROP DATABASE MyTest

--   1. ONE TO ONE RELATIONSHIPS




CREATE TABLE Passports(
	PassportID	INT  PRIMARY KEY ,
	PassportNumber	CHAR(8) NOT NULL)

CREATE TABLE Persons(
	PersonID	INT  PRIMARY KEY,
	FirstName	NVARCHAR(50) NOT NULL,
	Salary		DECIMAL(7,2) ,
	PassportID	INT NOT NULL FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE)

INSERT INTO Passports (PassportID, PassportNumber)
	VALUES
		(101, 'N34FG21B'),
		(102, 'K65LO4R7'),
		(103, 'ZE657QP2')

INSERT INTO Persons (PersonID, FirstName,	Salary,	PassportID)
	VALUES
		(1,'Roberto', 43300, 102),
		(2,'Tom',		56100, 103),
		(3,'Yana',	60200, 101)


SELECT * FROM Persons
SELECT * FROM Passports

DROP TABLE Passports
DROP TABLE Persons

--   2. ONE TO MANY RELATIONSHIPS

CREATE TABLE Manufacturers(
	ManufacturerID	INT  PRIMARY KEY ,
	[Name]	VARCHAR(20) UNIQUE NOT NULL,
	EstablishedOn DATE )

CREATE TABLE Models(
	ModelID	INT  PRIMARY KEY NOT NULL,
	[Name]	VARCHAR(30) NOT NULL,
	ManufacturerID	INT NOT NULL FOREIGN KEY REFERENCES Manufacturers(ManufacturerID) )

INSERT INTO Manufacturers (ManufacturerID, [Name],EstablishedOn)
	VALUES
		(1,'BMW', '03.07.1916'),
		(2,'Tesla',	'01.01.2003'),
		(3,'Lada',	'05.01.1966')

INSERT INTO Models (ModelID, [Name], ManufacturerID)
	VALUES
		(101, 'X1',		1),
		(102, 'i6',		1),
		(103, 'Model S',2),
		(104, 'Model X',2),
		(105, 'Model 3',3),
		(106, 'Nova',	3)


SELECT * FROM Models
SELECT * FROM Manufacturers

DROP TABLE Models
DROP TABLE Manufacturers


--   3. MANY TO MANY RELATIONSHIPS

CREATE TABLE Students(
	StudentID	INT  PRIMARY KEY ,
	[Name]	VARCHAR(30)  NOT NULL)

CREATE TABLE Exams(
	ExamID	INT  PRIMARY KEY ,
	[Name]	VARCHAR(30)  NOT NULL)

CREATE TABLE StudentsExams(
	StudentID	INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
	ExamID	INT  NOT NULL FOREIGN KEY REFERENCES Exams(ExamID) ,
	PRIMARY KEY (StudentID,ExamID))

INSERT INTO Students ( StudentID,[Name])
	VALUES
		(1,'Mila'),
		(2,'Toni'),
		(3,'Ron')

INSERT INTO Exams ( ExamID,[Name])
	VALUES
		(101,'SpringMVC'),
		(102,'Neo4j'),
		(103,'Oracle 11g')

INSERT INTO StudentsExams ( StudentID,ExamID)
	VALUES
		(1, 101),
		(1, 102),
		(2, 101),
		(3, 103),
		(2, 102),
		(2, 103)

SELECT * FROM Students

SELECT * FROM Exams

SELECT * FROM StudentsExams

DROP TABLE StudentsExams

DROP TABLE Students

DROP TABLE Exams

--    4.	Self-Referencing 

CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY ,
	[Name] VARCHAR(50)  NOT NULL,
	ManagerID INT NOT NULL FOREIGN KEY 
		REFERENCES Teachers(TeacherID) )

DROP TABLE Teachers


--    Problem 5.	Online Store Database

CREATE TABLE Cities(
	CityID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)  NOT NULL)

CREATE TABLE ItemTypes(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)  NOT NULL)

CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)  NOT NULL,
	Birthday DATE ,
	CityID INT NOT NULL FOREIGN KEY REFERENCES Cities(CityID ))

CREATE TABLE Items(
	ItemID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)  NOT NULL,
	ItemTypeID INT NOT NULL FOREIGN KEY REFERENCES ItemTypes(ItemTypeID ))

CREATE TABLE Orders(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID ) )

CREATE TABLE OrderItems(
	OrderID INT  NOT NULL FOREIGN KEY REFERENCES Orders(OrderID ),
	ItemID INT NOT NULL FOREIGN KEY REFERENCES Items(ItemID ) 
	PRIMARY KEY (OrderID, ItemID))

SELECT * FROM OrderItems
SELECT * FROM Items
SELECT * FROM ItemTypes
SELECT * FROM Orders
SELECT * FROM Customers
SELECT * FROM Cities


DROP TABLE OrderItems
DROP TABLE Items
DROP TABLE ItemTypes
DROP TABLE Orders
DROP TABLE Customers
DROP TABLE Cities

USE master
DROP DATABASE MyTest

--	Problem 6.	University Database

CREATE DATABASE University

USE University

CREATE TABLE Subjects(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName VARCHAR(50)  NOT NULL)

CREATE TABLE Majors(
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)  NOT NULL)

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber VARCHAR(10) UNIQUE NOT NULL,
	StudentName VARCHAR(50)  NOT NULL,
	MajorID INT NOT NULL FOREIGN KEY REFERENCES Majors(MajorID ) )

CREATE TABLE Payments(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATE ,
	PaymentAmount DECIMAL(7,2) ,
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID ) )

CREATE TABLE Agenda(
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID ) ,
	SubjectID INT NOT NULL FOREIGN KEY REFERENCES Subjects(SubjectID ) ,
	PRIMARY KEY (StudentID, SubjectID))

DROP TABLE Agenda
DROP TABLE Subjects
DROP TABLE Payments
DROP TABLE Students
DROP TABLE Majors


USE master
GO
DROP DATABASE University

--	09. *Peaks in Rila

USE Geography

SELECT M.MountainRange, P.PeakName,P.Elevation
	FROM Peaks AS P
	JOIN Mountains AS M ON M.Id=P.MountainId
	WHERE M.MountainRange LIKE 'Rila'
	ORDER BY P.Elevation DESC

