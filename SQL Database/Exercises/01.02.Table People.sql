USE Minions

--7 
CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) 
	CHECK (DATALENGTH (Picture)<=9000 * 1024),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX) )

INSERT INTO People ( [Name], Picture, Height, [Weight], Gender, Birthdate, Biography )
	VALUES
	('Steve', NULL, 1.85, 85, 'm', '05.21.1980',NULL),
	('George', NULL, 1.72, 65, 'm', '10.6.1980',NULL),
	('Elena', NULL, 1.68, 55, 'f', '05.26.1980',NULL),
	('Jene', NULL, 1.72, 58, 'f', '06.02.1980',NULL),
	('Peter', NULL, 1.85, 90, 'm', '12.10.1980',NULL)

-----------
SELECT * FROM People