USE Minions

--1
CREATE DATABASE Minions


DROP DATABASE Minions

--2 
CREATE TABLE Minions(
	Id INT PRIMARY KEY  IDENTITY ,
	[Name] varchar(50) NOT NULL ,
	Age  INT)

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY ,
	[Name] varchar(50) NOT NULL)

--3 
ALTER TABLE Minions
	ADD TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL

ALTER TABLE Minions
	ALTER COLUMN Townid INT  NOT NULL
	
ALTER TABLE Minions
	DROP FK__Minions__TownId__38996AB5

ALTER TABLE Minions
	ADD CONSTRAINT FK_Minions_TownId 
	FOREIGN KEY (Townid) REFERENCES Towns(Id)

--4 
INSERT INTO Towns ([Name])
	VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna')

INSERT INTO Minions ( [Name], Age, TownId)
	VALUES
	('Kevin',22,1),
	('Bob',15,3),
	('Steward',NULL,2)

SELECT * FROM Towns

SELECT * FROM Minions

--5 
TRUNCATE  TABLE Minions

--6 
DROP TABLE Minions, Towns




	