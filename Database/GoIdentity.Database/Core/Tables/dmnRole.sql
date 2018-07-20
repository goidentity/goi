CREATE TABLE [Core].[dmnRole]
(
	[RoleId] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[Title] VARCHAR(200) NOT NULL,
	[DefaultPage] varchar(500) NULL,
	[IsActive] BIT NOT NULL DEFAULT(1),
	[IsAdmin] BIT NOT NULL DEFAULT(0),

	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL,
	[ModifiedBy] INT NOT NULL,
	[ModifiedDate] DATETIME NOT NULL,

	CONSTRAINT UK_Title_Role UNIQUE(Title)
)
