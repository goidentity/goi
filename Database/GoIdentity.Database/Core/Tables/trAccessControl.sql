CREATE TABLE [Core].[trAccessControl]
(
	[AccessControlId] INT NOT NULL PRIMARY KEY  IDENTITY(1,1),	
	[NavigationId] INT NOT NULL,
	[RoleId] INT NOT NULL,
	[IsView] BIT NOT NULL DEFAULT(0),
	[IsInsert] BIT NOT NULL DEFAULT(0),
	[IsEdit] BIT NOT NULL DEFAULT(0),
	[IsDelete] BIT NOT NULL DEFAULT(0),
	[IsPrint] BIT NOT NULL DEFAULT(0),

	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL,
	[ModifiedBy] INT NOT NULL,
	[ModifiedDate] DATETIME NOT NULL

	--CONSTRAINT FK_trAccessControl_trNavigation FOREIGN KEY([NavigationUid]) REFERENCES Core.trNavigation(NavigationUid)
	CONSTRAINT FK_trAccessControl_dmnRole FOREIGN KEY([RoleId]) REFERENCES Core.dmnRole(RoleId)
)
