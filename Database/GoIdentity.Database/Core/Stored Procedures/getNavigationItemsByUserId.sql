CREATE PROCEDURE [Core].[getNavigationItemsByUserId]
	@userId INT
AS
BEGIN
	DECLARE @isAdmin BIT = 0;
	DECLARE @rolesIds TABLE
	(
		RoleId INT
	);
	
	INSERT INTO @rolesIds
	SELECT RoleId FROM Core.dmnRole WHERE 
		RoleId IN (SELECT RoleId FROM Core.trMapUserRole WHERE UserId = @userId )

	IF EXISTS(SELECT 1 FROM Core.dmnRole WHERE 
		IsAdmin = 1 AND RoleId IN (SELECT RoleId FROM Core.trMapUserRole WHERE UserId = @userId ) )
	BEGIN
		SET @isAdmin = 1;
	END
	SET @isAdmin = 1;
	if(@isAdmin = 1)
	begin
		;WITH directLinkItems
		AS
		(
				SELECT N.* FROM Core.trNavigation N		
				--LEFT JOIN  Core.trMapNavigationRole  NR ON NR.NavigationUid = N.NavigationUid
				where N.LevelId = 2 AND (@isAdmin = 1)

				--TODO: check this
				--SELECT N.* FROM Core.trNavigation N		
				--LEFT JOIN  Core.trMapNavigationRole  NR ON NR.NavigationUid = N.NavigationUid
				--where N.LevelId = 2 AND (@isAdmin = 1 OR NR.RoleId IN (SELECT RoleId FROM @rolesIds))
		), subNaviationGroup
		AS
		(
			SELECT * FROM Core.trNavigation WHERE NavigationId in (SELECT ParentNavigationId FROM directLinkItems)
		),modules
		AS
		(
			SELECT * FROM Core.trNavigation WHERE NavigationId in (SELECT ParentNavigationId FROM subNaviationGroup)
		)
		SELECT * FROM modules
		UNION
		SELECT * FROM subNaviationGroup
		UNION
		SELECT * FROM directLinkItems;
	END
	ELSE
		begin
		;WITH directLinkItems
		AS
		(
			SELECT N.* FROM Core.trNavigation N		
			JOIN Core.trAccessControl ACC ON N.[NavigationId]= ACC.[NavigationId]
			where N.LevelId = 2 AND ACC.RoleId IN (SELECT RoleId FROM @rolesIds)  AND IsView =1
		), subNaviationGroup
		AS
		(
			SELECT * FROM Core.trNavigation WHERE NavigationId in (SELECT ParentNavigationId FROM directLinkItems)
		),modules
		AS
		(
			SELECT * FROM Core.trNavigation WHERE NavigationId in (SELECT ParentNavigationId FROM subNaviationGroup)
		)
			SELECT * FROM modules
			UNION
			SELECT * FROM subNaviationGroup
			UNION
			SELECT * FROM directLinkItems;
		END
END