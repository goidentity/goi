CREATE TABLE [Core].[trUserProfile]
(
	[UserProfileId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DOB] NCHAR(10) NULL, 
    [Area] NCHAR(10) NULL, 
    [Gender] NCHAR(10) NULL, 
    [Profession] NCHAR(10) NULL, 
    [RolesPlayed] NCHAR(10) NULL, 
    [RolesInterested] NCHAR(10) NULL, 
    [UserId] NCHAR(10) NOT NULL, 
    --CONSTRAINT [FK_trUserProfile_trUser] FOREIGN KEY ([Column]) REFERENCES [ToTable]([ToTableColumn]) 
)
