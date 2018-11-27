CREATE TYPE [Core].[UserEducationType] AS TABLE
(
	[UserEducationId] INT NOT NULL,
	[UserId] INT NOT NULL,

	EducationType varchar(500),
	DegreeType varchar(500),
	Title varchar(500),
	UniversityOrBoard varchar(500),
	InstitutionOrBoard varchar(500),
	YearOfPass varchar(500),
	Specialization varchar(500)
)
