CREATE TABLE [Core].[trNavigation]
(
	[NavigationId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	
	[Title] [nvarchar](200) NOT NULL,
	[NavigationPath] [varchar] (2000) NULL,
	[LevelId] [TinyInt] NOT NULL,
	[ParentNavigationId] [int] NULL,
	[ImagePath] [varchar] (2000) NOT NULL,	
	[SortId] [int] NOT NULL,
	
	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL,
	[ModifiedBy] INT NOT NULL,
	[ModifiedDate] DATETIME NOT NULL

)

/*
	Level 0 = Module
	Level 1 = Sub Navigation Group
	Level 2 = Direct Link
*/