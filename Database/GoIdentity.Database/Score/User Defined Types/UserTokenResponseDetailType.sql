CREATE TYPE [Scores].UserTokenResponseDetailType AS TABLE
(
	[UserTokenResponseId] INT NOT NULL, 
	
	[ProcessedDate] DATETIME NULL,
	[ResponseDataFileName] VARCHAR(8000) null,

	[NlpEntitiesFileName]  VARCHAR(8000) null,
	[NlpEntities]  VARCHAR(max) null,

	[NlpSentimentFileName]  VARCHAR(8000) null,
	[NlpSentiment]  VARCHAR(max) null,

	[NlpSyntaxFileName]  VARCHAR(8000) null,
	[NlpSyntax]  VARCHAR(max) null,

	[NlpClassifyFileName]  VARCHAR(8000) null,
	[NlpClassify]  VARCHAR(max) null,
	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [ModifiedDate] DATETIME NOT NULL
)
