CREATE PROCEDURE [Core].[updateMyUserProfile]
	@firstName varchar(max),
	@middleName varchar(50), 
	@lastName varchar(max), 
	@gender varchar(20), 
	@emailId varchar(max), 
	@phoneNumber varchar(max), 
	@dob DateTime,
	@placeOfBirth varchar(max), 
	@currentCity varchar(max), 
	@homeTown varchar(max), 
	@martialStatus varchar(20), 
	@aadharCard varchar(50),  
	@Id INT
AS
BEGIN

update [Core].[trUser] set
FirstName = @firstName,
LastName = @lastName,
Email = @emailId,
MobileNumber = @phoneNumber 
where UserId = @Id

IF EXISTS (SELECT 1 FROM [Core].[trMyUserProfile] WHERE Id =@Id) 
BEGIN
   Update [Core].[trMyUserProfile] set 
   MiddleName = @middleName,
   Gender = @gender,
   DOB = @dob,
   PlaceOfBirth = @placeOfBirth,
   CurrentCity = @currentCity,
   HomeTown = @homeTown,
   MartialStatus = @martialStatus,
   AadharCard = @aadharCard
   where Id = @Id
END
ELSE
BEGIN
    insert into [Core].[trMyUserProfile] values (
	@Id,@middleName,@gender,@dob,@placeOfBirth,@currentCity,@homeTown,@martialStatus,@aadharCard)
END
END
