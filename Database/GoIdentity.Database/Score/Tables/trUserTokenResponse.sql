﻿CREATE TABLE [Scores].[trUserTokenResponse]
(
	[UserTokenResponseId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	[UserId] INT NOT NULL, 	
	[Token] varchar(max) null,
	[ProcessDate] DATETIME NULL,

    [CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [ModifiedDate] DATETIME NOT NULL
)
