CREATE TABLE [Core].[trBusinessProfile]
(
	[BusinessProfileId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[UserId] INT NOT NULL,

	CompanyName varchar(500) not null,
	YearOfEstablishment smallint null,
	ComponySize int,
	Role varchar(2000),

	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [ModifiedDate] DATETIME NOT NULL 
)
