
--15 Hotel Database

CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(15) ,
	Notes VARCHAR(MAX) 	)

CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(20)NOT NULL,
	EmergencyName NVARCHAR(50) NOT NULL,
	EmergencyNumber VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX) 	)

CREATE TABLE RoomStatus(
	RoomStatus VARCHAR(20) UNIQUE NOT NULL,
	Notes VARCHAR(MAX) 	)

CREATE TABLE RoomTypes (
	RoomType VARCHAR(20) UNIQUE NOT NULL,
	Notes VARCHAR(MAX) 	)

CREATE TABLE BedTypes (
	BedType VARCHAR(20) UNIQUE NOT NULL,
	Notes VARCHAR(MAX) 	)

CREATE TABLE Rooms (
	RoomNumber INT PRIMARY KEY NOT NULL,
	RoomType VARCHAR(20) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
	BedType VARCHAR(20) FOREIGN KEY REFERENCES BedTypeS(BedType) NOT NULL,
	Rate DECIMAL(8,2) NOT NULL,
	RoomStatus VARCHAR(20) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
	Notes VARCHAR(MAX) 	)

CREATE TABLE Payments (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	PaymentDate DATETIME2 DEFAULT GETDATE() NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES CustOmers(AccountNumber) NOT NULL,
	FirstDateOccupied DATETIME2  NOT NULL,
	LastDateOccupied DATETIME2 NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(8,2) NOT NULL,
	TaxRate DECIMAL(4,2) NOT NULL, 
	TaxAmount DECIMAL(8,2) NOT NULL, 
	PaymentTotal DECIMAL(8,2) NOT NULL,
	Notes VARCHAR(MAX) 	)

CREATE TABLE Occupancies (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	DateOccupied DATETIME2  NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES CustOmers(AccountNumber) NOT NULL,
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
	RateApplied DECIMAL(8,2) NOT NULL,
	PhoneCharge DECIMAL(8,2) NOT NULL,
	Notes VARCHAR(MAX) 	)

INSERT INTO Employees (FirstName ,	LastName ,	Title  ,Notes )
	VALUES
	('Peter','Petrov','Mr',NULL),
	('Ivan','Petrov','Mr',NULL),
	('Ani','PetrovA','Mrs',NULL)

INSERT INTO Customers (FirstName ,	LastName ,	PhoneNumber ,EmergencyName,EmergencyNumber ,Notes )
	VALUES
	('Peter','Petrov','256488655','Kolev','556698555',NULL),
	('Ivan','Petrov','256488655','Kolev','556698555',NULL),
	('Ani','PetrovA','256488655','Kolev','556698555',NULL)

INSERT INTO RoomStatus (RoomStatus ,Notes )
	VALUES
	('Occupied',NULL),
	('Ready',NULL),
	('Reserved',NULL)

INSERT INTO RoomTypes (RoomType ,Notes )
	VALUES
	('Double',NULL),
	('Single',NULL),
	('Apartment',NULL)

INSERT INTO BedTypes (BedType ,Notes )
	VALUES
	('Double',NULL),
	('Single',NULL),
	('Kingsize',NULL)

INSERT INTO Rooms (RoomNumber ,	RoomType ,	BedType ,	Rate ,	RoomStatus, Notes )
	VALUES
	(105, 'Single'		,'Single'	,50		,'Ready'	,NULL),
	(120, 'Double'		,'Double'	,150	,'Reserved'	,NULL),
	(305, 'Apartment'	,'Kingsize'	,200	,'Ready'	,NULL)

INSERT INTO Payments (EmployeeId, PaymentDate,	AccountNumber,	FirstDateOccupied,	LastDateOccupied,	TotalDays,
	AmountCharged,	TaxRate,	TaxAmount, 	PaymentTotal, Notes )
	VALUES
	(1, GETDATE()	,'2'	,'05.21.2019','06.30.2019',55,1500,20,300,1800	,NULL),
	(2, GETDATE()	,'1'	,'05.21.2019','06.30.2019',55,1500,20,300,1800	,NULL),
	(1, GETDATE()	,'2'	,'05.21.2019','06.30.2019',55,1500,20,300,1800	,NULL)

INSERT INTO Occupancies (EmployeeId, DateOccupied,	AccountNumber,	RoomNumber,	RateApplied, PhoneCharge, Notes )
	VALUES
	(1, '05.21.2019'	,'2'	,120,50,55,NULL),
	(2, '05.21.2019'	,'1'	,105,80,55,NULL),
	(1, '05.21.2019'	,'2'	,305,120,55,NULL)

------------------
SELECT * FROM Employees

--Problem 23.	Decrease Tax Rate
UPDATE Payments
	SET TaxRate *= 1.03

SELECT TaxRate FROM Payments

--Problem 24.	Delete All Records
DELETE  FROM Occupancies

------------------------------

SELECT * FROM Occupancies