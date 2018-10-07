CREATE TYPE [Scores].[EngineResponseType] AS TABLE
(
	UserId INT,
	InfluencerId SMALLINT,
	
	PullStatus VARCHAR(200),
	Response VARCHAR(MAX),
	Remarks VARCHAR(MAX),
	TransactionDate DATETIME
)
