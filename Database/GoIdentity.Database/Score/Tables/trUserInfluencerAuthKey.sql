CREATE TABLE [dbo].[trUserInfluencerAuthKey]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [InfluencerId] INT NOT NULL, 
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
