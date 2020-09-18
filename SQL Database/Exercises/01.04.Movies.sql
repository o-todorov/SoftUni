
--13 Movies Database
CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	DirectorName NVARCHAR(50) UNIQUE NOT NULL,
	Notes NVARCHAR(50))

CREATE TABLE Genres(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	GenreName NVARCHAR(50) UNIQUE NOT NULL,
	Notes NVARCHAR(MAX))

CREATE TABLE Categories(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	CategoryName NVARCHAR(50) UNIQUE NOT NULL,
	Notes NVARCHAR(MAX))

CREATE TABLE Movies(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	DirectorId INT NOT NULL,
	CopirightYear DATETIME2,
	[Length] DECIMAL(3,2),
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating TINYINT,
	Notes NVARCHAR(MAX))

ALTER TABLE Movies
	ADD CONSTRAINT FK_Movies_DirectorId 
			FOREIGN KEY (DirectorId) REFERENCES Directors(Id),
		CONSTRAINT FK_Movies_GenreId 
			FOREIGN KEY (GenreId) REFERENCES Genres(Id),
		CONSTRAINT FK_Movies_CategoryId
			FOREIGN KEY (CategoryId) REFERENCES Categories(Id)


INSERT INTO Directors (DirectorName, Notes)
	VALUES
	('Steven Spielberg', 'Some movie info'),
	('Spilberg1', 'Some  info'),
	('Spilberg2', 'Some  info'),
	('Spilberg3', 'Some  info'),
	('Spilberg4', 'Some  info')


INSERT INTO Genres(GenreName, Notes)
	VALUES
	('SiFi', 'About this genre...'),
	('Action', 'About this genre...'),
	('Drama', 'About this genre...'),
	('Horror', 'About this genre...'),
	('Romantic', 'About this genre...')

INSERT INTO Categories(CategoryName, Notes)
	VALUES
	('Categori1', 'About this CATEGORY...'),
	('Categori2', 'About this CATEGORY...'),
	('Categori3', 'About this CATEGORY...'),
	('Categori4', 'About this CATEGORY...'),
	('Categori5', 'About this CATEGORY...')

INSERT INTO Movies(Title, DirectorId, CopirightYear, [Length], GenreId, CategoryId, Rating, Notes)
	VALUES
	('It',2,'05.20.1985', 2.30, 1, 5, 10, 'About the movie...'),
	('Star Wars',4,'05.20.1985', 2.30, 2, 4, 8, 'About the movie...'),
	('Star Wars1',3,'05.20.1985', 2.30, 3, 3, 9, 'About the movie...'),
	('Star Wars2',5,'05.20.1985', 2.30, 4, 2, 10, 'About the movie...'),
	('Star Wars3',1,'05.20.1985', 2.30, 5, 1, 10, 'About the movie...')

----------------

DROP TABLE Movies, Directors, Genres, Categories

SELECT * FROM Movies 
SELECT * FROM Directors
SELECT * FROM Genres
SELECT * FROM Categories

DROP TABLE Movies

TRUNCATE TABLE Movies