
--14 Car Rental Database

CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) UNIQUE,
	DailyRate DECIMAL(8,2) NOT NULL,
	WeeklyRate DECIMAL(8,2),
	MonthlyRate DECIMAL(8,2),
	WeekendRate DECIMAL(8,2))


CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(15) UNIQUE NOT NULL, 
	Manufacturer VARCHAR (30) NOT NULL, 
	Model VARCHAR(30), 
	CarYear CHAR(4), 
	CategoryId INT NOT NULL, 
	Doors TINYINT, 
	Picture VARBINARY(MAX), 
	Condition VARCHAR(10), 
	Available BIT NOT NULL DEFAULT 1)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL, 
	LastName NVARCHAR(20), 
	Title NVARCHAR(10), 
	Notes NVARCHAR(MAX))

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber VARCHAR (20) UNIQUE NOT NULL, 
	FullName NVARCHAR(30) NOT NULL, 
	[Address] NVARCHAR(50), 
	City NVARCHAR(30), 
	ZIPCode VARCHAR (10), 
	Notes NVARCHAR(MAX))

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL, 
	CustomerId INT NOT NULL, 
	CarId INT NOT NULL, 
	TankLevel TINYINT NOT NULL, 
	KilometrageStart INT NOT NULL, 
	KilometrageEnd INT NOT NULL, 
	TotalKilometrage INT NOT NULL, 
	StartDate DATETIME DEFAULT GETDATE(), 
	EndDate DATETIME DEFAULT GETDATE()+1, 
	TotalDays TINYINT DEFAULT 1 NOT NULL, 
	RateApplied DECIMAL(8,2), 
	TaxRate DECIMAL(4,2), 
	OrderStatus VARCHAR (20), 
	Notes NVARCHAR(MAX))


INSERT INTO Categories(CategoryName,DailyRate,WeeklyRate,MonthlyRate,WeekendRate)
	VALUES
		('SEDAN', 55.50,300 , 5000, 40 ),
		('BUS', 70,300 , 5000, 40 ),
		('VAN', 65,300 , 5000, 40 )

INSERT INTO Cars(PlateNumber,Manufacturer,Model,CarYear,CategoryId,Doors,Picture,Condition,Available )
	VALUES
		('PL6895KL', 'RENAULT' , '300S', '2004', 1, 4, NULL, 'GOOD',1 ),
		('PL6896KL', 'RENAULT' , '300S', '2004', 2, 5, NULL, 'GOOD',0 ),
		('PL6897KL', 'RENAULT' , '300S', '2004', 1, 4, NULL, 'GOOD',0 )

INSERT INTO Employees(FirstName,LastName,Title,Notes)
	VALUES
		('Ivan', 'Petrov' , 'Mr', 'Excelent driver' ),
		('Stoyan', 'Petrov' , 'Mr', 'Excelent driver' ),
		('Ani', 'IvanovA' , 'Mrs', 'Excelent driver' )

INSERT INTO Customers(DriverLicenceNumber,FullName,[Address],City,ZIPCode, Notes )
	VALUES
		('6524897458', 'Ivan Petrov' , 'UL.Iscar No.5', 'Sofia', '1000', NULL ),
		('7024897458', 'Ivan Petrov' , 'UL.Iscar No.5', 'Sofia', '1000', NULL ),
		('9924897458', 'Ivan Petrov' , 'UL.Iscar No.5', 'Sofia', '1000', NULL )

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, 
					TotalKilometrage, RateApplied, TaxRate, OrderStatus, Notes)
	VALUES
		(2, 1 ,3,40, 56000, 56800, 800, 50.50, 20, 'ACTIVE', ''),
		(2, 2 ,2,80, 56000, 56800, 800, 50.50, 20, 'ACTIVE', ''),
		(3, 3 ,1,45, 56000, 56800, 800, 50.50, 20, 'ACTIVE', '')


--------------

SELECT * FROM Categories
SELECT * FROM Cars
SELECT * FROM Employees
SELECT * FROM Customers
SELECT * FROM RentalOrders


ALTER TABLE RentalOrders
	ADD CONSTRAINT DF_EndDate	DEFAULT GETDATE()+1 FOR EndDate,
		CONSTRAINT DF_TotalDays	DEFAULT 1 FOR TotalDays

ALTER TABLE Cars
	ADD CONSTRAINT FK_Cars_CategoryId
		FOREIGN KEY (CategoryId) REFERENCES Categories(Id)

ALTER TABLE RentalOrders
	ADD CONSTRAINT FK_RentalOrders_EmployeeId 
			FOREIGN KEY (EmployeeId) REFERENCES EmployeeS(Id),
		CONSTRAINT FK_RentalOrders_CustomerId
			FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
		CONSTRAINT FK_RentalOrders_CarId
			FOREIGN KEY (CarId) REFERENCES Cars(Id)




