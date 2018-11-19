CREATE TABLE [Core].[trUserExperience]
(
	[UserExperienceId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[UserId] INT NOT NULL,
	
	OrganizationName varchar(500),
	Designation varchar(500),
	Roles varchar(500),
	StartDate Datetime,
	EndDate DateTime,
	IsCurrent bit,
	ReasonForChange varchar(500),

	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [ModifiedDate] DATETIME NOT NULL 
)
