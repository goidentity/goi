CREATE TABLE [Core].[trUserScore]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL,
	
    [ICMapId] INT NULL, 
    [ScoreType] varchar(500) NULL,

	[Score] DECIMAL(18, 2) NOT NULL default(0), 
	[ChangeScore] DECIMAL(18, 2) NOT NULL default(0), 

    [CreatedOn] DATETIME NOT NULL, 
    [GroupId] UNIQUEIDENTIFIER NULL
)
