CREATE TABLE [Scores].[dmnInfluencer]
(
	[InfluencerId] SMALLINT NOT NULL PRIMARY KEY,
	Title varchar(500),
	Category varchar(100),

	ApiKey VARCHAR(8000),
	UserName VARCHAR(8000),
	Password VARCHAR(8000),

	Other1 VARCHAR(8000),
	Other2 VARCHAR(8000),
	Other3 VARCHAR(8000),

	IsActive BIT DEFAULT(1),

	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [ModifiedDate] DATETIME NOT NULL
)
