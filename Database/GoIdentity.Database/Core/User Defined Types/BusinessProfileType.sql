CREATE TYPE [Core].[BusinessProfileType] AS TABLE
(
	[BusinessProfileId] INT NULL,
	UserId INT NULL,

	CompanyName varchar(500) not null,
	YearOfEstablishment smallint null,
	ComponySize int,
	Role varchar(2000)
)
