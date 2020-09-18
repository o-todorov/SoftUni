

CREATE TABLE Cities(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
	)

CREATE TABLE Hotels(
	Id INT PRIMARY KEY IDENTITY,
	[Name]	NVARCHAR(30) NOT NULL,
	CityId	INT REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15,2)
	)



CREATE TABLE Rooms(
	Id INT PRIMARY KEY IDENTITY,
	Price	DECIMAL(15,2) NOT NULL,
	[Type]	NVARCHAR(20) NOT NULL,
	Beds	INT NOT NULL,
	HotelId INT REFERENCES Hotels(Id) NOT NULL
	)



CREATE TABLE Trips(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT REFERENCES Rooms(Id) NOT NULL,
	BookDate DATETIME2 NOT NULL,
	ArrivalDate DATETIME2 NOT NULL,
	ReturnDate	DATETIME2 NOT NULL,
	CancelDate	DATETIME2,
	CHECK( BookDate < ArrivalDate),
	CHECK( ArrivalDate < ReturnDate)
	)

CREATE TABLE Accounts(
	Id INT PRIMARY KEY IDENTITY,
	FirstName	NVARCHAR(50) NOT NULL,
	MiddleName	NVARCHAR(20) ,
	LastName	NVARCHAR(50) NOT NULL,
	CityId		INT REFERENCES Cities(Id) NOT NULL,
	BirthDate	DATETIME2 NOT NULL,
	Email	VARCHAR(100) NOT NULL UNIQUE
	)

CREATE TABLE AccountsTrips(
	AccountId	INT REFERENCES Accounts(Id) NOT NULL,
	TripId		INT REFERENCES Trips(Id)	NOT NULL,
	Luggage		INT CHECK(Luggage >= 0) NOT NULL,
	)


















































