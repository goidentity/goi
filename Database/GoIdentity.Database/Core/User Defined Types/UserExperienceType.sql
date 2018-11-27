CREATE TYPE [Core].[UserExperienceType] AS TABLE
(
	[UserExperienceId] INT NOT NULL,
	[UserId] INT NOT NULL,
	
	OrganizationName varchar(500),
	Designation varchar(500),
	Roles varchar(500),
	StartDate Datetime,
	EndDate DateTime,
	IsCurrent bit,
	ReasonForChange varchar(500),

	PersonalURL VARCHAR(500),
	PersonalUrlKeyWords VARCHAR(5000),

	ListingURL VARCHAR(500),
	ListingUrlKeyWords VARCHAR(5000)
)
