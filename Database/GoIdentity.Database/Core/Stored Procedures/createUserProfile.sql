CREATE PROCEDURE [Core].[createUserProfile]
	@dob date,
	@area varchar(50),
	@gender varchar,
	@profession varchar(50),
	@rolesplayed varchar(500),
	@rolesinterested varchar(500),
	@userid INT
AS
BEGIN
	INSERT INTO trUserProfile (DOB,Area,Gender,Profession,RolesPlayed,RolesInterested) values (@dob,@area,@gender,@profession,@rolesplayed,@rolesinterested);
END
