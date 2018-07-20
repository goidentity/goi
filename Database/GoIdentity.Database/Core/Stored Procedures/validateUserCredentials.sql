CREATE PROCEDURE [Core].[validateUserCredentials]
	@userId INT,
	@userName VARCHAR(2000),
	@password VARCHAR(2000),
	@remoteIpAddress VARCHAR(2000),
	@localIpAddress VARCHAR(2000),
	@appKey VARCHAR(2000)
AS
BEGIN
	DECLARE @claims TABLE
	(
		ClaimType VARCHAR(200),
		ClaimValue VARCHAR(200)
	);	
	
	DECLARE @remarks VARCHAR(50) = '';

	IF (@appKey IS NOT NULL AND LEN(@appKey) > 0)
	BEGIN
		SELECT @userId = U.UserId
		, @userName = U.UserName
		, @password = U.[Password]
		FROM Core.trUser U
		where U.ApiKey = @appKey;
	END

	IF(@userId IS NULL OR @userId = 0)
	BEGIN
		SELECT @userId = UserId FROM Core.trUser
		WHERE UserName = @userName;
	END
	ELSE
	BEGIN
		SELECT @userName = UserId, @password = Core.decryptData(Password) FROM Core.trUser WHERE UserId = @userId;
	END

	IF (@userId IS NULL)
	BEGIN
		SET @userId = 0;
		SET @remarks = @userName;
	END

		IF EXISTS (SELECT * FROM Core.trUser WHERE UserName = @userName AND Core.decryptData(Password) = @password AND IsLocked = 0 AND IsSuspended=0)
		BEGIN
		INSERT INTO @claims (ClaimType, ClaimValue) VALUES('Status', 'Success');
		INSERT INTO @claims (ClaimType, ClaimValue) VALUES('AuthenticationMethod', 'iSuitePro');

		INSERT INTO @claims (ClaimType, ClaimValue) values('UserId', @userId);
		INSERT INTO @claims (ClaimType, ClaimValue) values('UserName', @userName);

		
		INSERT INTO @claims (ClaimType, ClaimValue)
		SELECT 'RoleId', RoleId FROM Core.trMapUserRole WHERE UserId = @userId
		UNION
		select 'RoleId', R.RoleId from Core.trUser E
		JOIN Core.dmnRole R ON E.DefaultRole = R.Title;

	END
	ELSE IF EXISTS (SELECT * FROM Core.trUser WHERE UserName = @userName AND IsSuspended = 1)
	BEGIN
		INSERT INTO @claims (ClaimType, ClaimValue) VALUES('Status', 'Supended');
	END
	ELSE IF EXISTS (SELECT * FROM Core.trUser WHERE UserName = @userName AND IsLocked = 1)
	BEGIN
		INSERT INTO @claims (ClaimType, ClaimValue) VALUES('Status', 'Locked');
	END
	
	SELECT * FROM @claims;
END