CREATE PROCEDURE [Core].[getMyUserProfile]
	@userId INT
AS
BEGIN
	SELECT  
	UserId as Id,
	FirstName as FirstName,
	MiddleName as MiddleName,
	LastName as LastName,
	Gender as Gender,
	Email as EmailId,
	MobileNumber as PhoneNumber,
	DOB as DOB,
	PlaceOfBirth as PlaceOfBirth,
	CurrentCity as CurrentCity,
	HomeTown as HomeTown,
	MartialStatus as MartialStatus,
	AadharCard as AadharCard
	FROM Core.trUser as truser left join Core.trMyUserProfile as userprofile on
	truser.UserId = userprofile.Id
	WHERE UserId = 1
END
