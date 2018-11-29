CREATE TYPE [Scores].[UserTokenResponseType] AS TABLE
(
	[UserId] INT NOT NULL, 

	[Token] VARCHAR(8000) NOT NULL,
	
	[ProcessDate] DATETIME NULL,

    [CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [ModifiedDate] DATETIME NOT NULL
)
