CREATE PROCEDURE [Core].[updateUserProfile]
	@userProfileId INT,
	@dob date,
	@area varchar(50),
	@gender varchar,
	@profession varchar(50),
	@rolesplayed varchar(500),
	@rolesinterested varchar(500),
	@userid INT
AS
BEGIN
	UPDATE Core.trUserProfile SET
			DOB = @dob,
			Area = @area,
			Gender = @gender,
			Profession = @profession,
			RolesPlayed = @rolesplayed,
			RolesInterested = @rolesinterested,
			UserId = @userid
	WHERE UserProfileId = @userProfileId;
END
