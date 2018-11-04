CREATE TABLE [Core].[trMyUserProfile] (
    [Id]   INT        NOT NULL ,
	[MiddleName] NVARCHAR(50) NULL,
    [Gender]            NVARCHAR (20)  NULL,
    [DOB]             DATETIME  NULL,
    [PlaceOfBirth]            NVARCHAR (MAX)  NULL,
    [CurrentCity]          NVARCHAR (MAX)  NULL,
    [HomeTown]      NVARCHAR (MAX)  NULL,
    [MartialStatus]      NVARCHAR (20)  NULL,
    [AadharCard]     NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY (Id) REFERENCES [Core].[trUser](UserId)
);

