CREATE TABLE [Scores].[trUserInfluencerAuth]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [UserId] INT NOT NULL, 
    [InfluencerId] smallint NOT NULL, 
    [UserName] NVARCHAR(MAX) NULL,
	
    [Secret] NVARCHAR(MAX) NULL, 
    [Secret1] NVARCHAR(MAX) NULL, 
    [Secret2] NVARCHAR(MAX) NULL, 
    [Secret3] NVARCHAR(MAX) NULL, 
	
	[Other1] NVARCHAR(MAX) NULL,
	[Other2] NVARCHAR(MAX) NULL,
    
	[LastRefreshedDate] DATETIME NULL, 

    [CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [ModifiedDate] DATETIME NOT NULL
)
