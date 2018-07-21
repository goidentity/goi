CREATE TABLE [Core].[trUserProfile] (
    [UserProfileId]   INT            IDENTITY (1, 1) NOT NULL,
    [DOB]             NVARCHAR (50)  NULL,
    [Area]            NVARCHAR (50)  NULL,
    [Gender]          NVARCHAR (50)  NULL,
    [Profession]      NVARCHAR (50)  NULL,
    [RolesPlayed]     NVARCHAR (MAX) NULL,
    [RolesInterested] NVARCHAR (MAX) NULL,
    [UserId]          INT            NOT NULL,
    [CreatedBy]       INT  NULL,
    [CreatedDate]     DATETIME       NULL,
    [ModifiedBy]      INT  NULL,
    [ModifiedDate]    DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([UserProfileId] ASC)
);

