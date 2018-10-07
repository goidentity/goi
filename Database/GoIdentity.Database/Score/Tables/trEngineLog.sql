CREATE TABLE [Scores].[trEngineLog]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    UserInfluencerAuthId INT NOT NULL,
	[UserId] INT NOT NULL, 
	[InfluencerId] smallint not null,

	PullStatus VARCHAR(500),
	Response VARCHAR(MAX),
	Remarks VARCHAR(MAX),

	TransactionDate DATETIME,

	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [ModifiedDate] DATETIME NOT NULL
)
