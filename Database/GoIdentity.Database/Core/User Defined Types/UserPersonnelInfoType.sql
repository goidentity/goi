﻿CREATE TYPE [Core].[UserPersonnelInfoType] AS TABLE
(
	[UserPersonnelInfoId] INT NOT NULL,
	[UserId] INT NOT NULL,

	DoB datetime,
	Gender varchar(20),
	PlaceOfBirth varchar(500),
	CityOfLiving varchar(500),

	CityOfWork varchar(500),
	MaritalStatus varchar(500),
	BirthOfOrigin varchar(500),
	Nationality varchar(500),
	Citizenship varchar(500),
	PRStatus varchar(500),

	PrimaryIndustryOfWork varchar(500),
	SecondaryIndustryOfWork varchar(500),

	PrimaryIndustryOfBusiness varchar(500),
	SecondaryIndustryOfBusiness varchar(500),

	FutureRole varchar(500),
	FutureIndustryOfWork varchar(500),
	FutureIndustryOfBusiness varchar(500)
)
