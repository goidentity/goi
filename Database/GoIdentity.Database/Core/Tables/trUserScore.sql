CREATE TABLE [Core].[trUserScore]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [ICMapId] INT NOT NULL, 
    [Score] DECIMAL(18, 2) NOT NULL, 
    [CreatedOn] DATETIME NOT NULL
)
