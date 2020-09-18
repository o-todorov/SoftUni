
--8 Create Table Users
CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX)
		CHECK (DATALENGTH (ProfilePicture)<=900 * 1024),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL)


INSERT INTO Users( Username, [Password], ProfilePicture, LastLoginTime, IsDeleted )
	VALUES
	('Seagull', '35165', NULL, '10.5.2020',0),
	('user1', '5252', NULL, '10.5.2018',0),
	('user2', '2452', NULL, '12.5.2019',1),
	('user3', '868588', NULL, '11.5.2015',0),
	('user4', '247828', NULL, '05.5.2019',0)

SELECT * FROM Users

--9 Change Primary Key
ALTER TABLE Users
	DROP CONSTRAINT  [PK__Users__3214EC07DA855BD3]
	--DROP  PK__Users__3214EC07DA855BD3

ALTER TABLE Users
	ADD CONSTRAINT PK_Users_CompositeIdUsername
	PRIMARY KEY (Id, Username)

--10 Add Check Constraint
ALTER TABLE Users
	ADD CONSTRAINT CK_Users_PasswordLength
	CHECK (LEN([Password])>=5)

--11 Set Default Value of a Field
ALTER TABLE Users
	ADD CONSTRAINT DF_Users_LastLoginTime
	DEFAULT GETDATE() FOR LastLoginTime

--12 Set Unique Field
ALTER TABLE Users
	DROP CONSTRAINT PK_Users_CompositeIdUsername

ALTER TABLE Users
	ADD CONSTRAINT PK_Users_Id
	PRIMARY KEY (Id)

ALTER TABLE Users
	ADD CONSTRAINT CK_Users_UsernameLength
	CHECK (LEN( Username) >= 3 )
-----------
	
















