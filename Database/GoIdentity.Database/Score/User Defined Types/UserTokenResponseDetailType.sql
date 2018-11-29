CREATE TYPE [Scores].UserTokenResponseDetailType AS TABLE
(
	[UserTokenResponseDetailId] INT NOT NULL,
	[UserTokenResponseId] INT NOT NULL, 
	
	[ProcessedDate] DATETIME NULL,
	[TokenLink] VARCHAR(MAX) NULL,
	[Count] INT NULL,
	[Description] VARCHAR(MAX) NULL,

	[AnalyzeEntities] VARCHAR(MAX) NULL,
	[AnalyzeEntitiesTokens] VARCHAR(MAX) NULL,
	[AnalyzeEntitiesScore] DECIMAL(18,2) NULL,
	[AnalyzeEntitiesMagnitude] DECIMAL(18,2) NULL,

	[AnalyzeEntitySentiment] VARCHAR(MAX) NULL,
	[AnalyzeEntitySentimentTokens] VARCHAR(MAX) NULL,
	[AnalyzeEntitySentimentScore] DECIMAL(18,2) NULL,
	[AnalyzeEntitySentimentMagnitude] DECIMAL(18,2) NULL,

	[AnalyzeSyntax] VARCHAR(MAX) NULL,
	[AnalyzeSyntaxTokens] VARCHAR(MAX) NULL,
	
	[ClassifyText] VARCHAR(MAX) NULL,
	[ClassifyTextTokens] VARCHAR(MAX) NULL
)
