﻿CREATE TABLE [Core].[dmnIndustry]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(500) NOT NULL, 
    [Weightage] DECIMAL(18, 2) NULL
)
