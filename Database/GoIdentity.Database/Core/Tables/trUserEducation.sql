CREATE TABLE [Core].[trUserEducation]
(
	[UserEducationId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[UserId] INT NOT NULL,

	EducationType varchar(500),
	DegreeType varchar(500),
	Title varchar(500),
	UniversityOrBoard varchar(500),
	InstitutionOrBoard varchar(500),
	YearOfPass varchar(500),
	Specialization varchar(500),

	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [ModifiedDate] DATETIME NOT NULL 
)
