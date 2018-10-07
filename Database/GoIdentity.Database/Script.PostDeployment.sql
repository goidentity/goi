	--User
	IF NOT EXISTS(SELECT 1 FROM Core.trUser)
	BEGIN
		INSERT INTO Core.trUser([UserName],[Password],[FirstName],[LastName],[Email],[MobileNumber],
				[UniqueId],[JsonFeed],
				
				[DefaultRole],
				[IsLocked],[LockedDate],[IsSuspended],[SuspendedDate],[ApiKey],
				[CreatedBy],[CreatedDate], [ModifiedBy], [ModifiedDate])
		VALUES('Admin', [Core].[encryptData]('test'), 'Admin', 'Admin', 'info@goidentity.in', '0000000000' ,
				NEWID(), NULL,
				
				'User',
				0, NULL, 0, NULL, NEWID(),
				0, GETDATE(), 0, GETDATE());
	END


	--Role
	IF NOT EXISTS(SELECT 1 FROM Core.dmnRole)
	BEGIN
		INSERT INTO Core.dmnRole(Title,DefaultPage,IsActive,IsAdmin,
				[CreatedBy],[CreatedDate], [ModifiedBy], [ModifiedDate])
		VALUES('Admin', '', 1, 1,
				0, GETDATE(), 0, GETDATE());

		INSERT INTO Core.dmnRole(Title,DefaultPage,IsActive,IsAdmin,
				[CreatedBy],[CreatedDate], [ModifiedBy], [ModifiedDate])
		VALUES('Regular', '', 1, 0,
				0, GETDATE(), 0, GETDATE());
	END


	declare @navigationId INT
	--Navigation
	IF NOT EXISTS(SELECT 1 FROM Core.trNavigation)
	BEGIN
		--Person
		INSERT INTO Core.trNavigation([Title], [NavigationPath], [LevelId], [ParentNavigationId], [ImagePath], [SortId],
				[CreatedBy],[CreatedDate], [ModifiedBy], [ModifiedDate])
		VALUES('Core', '', 0, NULL, '', 1,
				0, GETDATE(), 0, GETDATE());
		select @navigationId = SCOPE_IDENTITY();

		INSERT INTO Core.trNavigation([Title], [NavigationPath], [LevelId], [ParentNavigationId], [ImagePath], [SortId],
				[CreatedBy],[CreatedDate], [ModifiedBy], [ModifiedDate])
		VALUES('Member', '', 1, @navigationId, '', 1,
				0, GETDATE(), 0, GETDATE());
		select @navigationId = SCOPE_IDENTITY();

		INSERT INTO Core.trNavigation([Title], [NavigationPath], [LevelId], [ParentNavigationId], [ImagePath], [SortId],
				[CreatedBy],[CreatedDate], [ModifiedBy], [ModifiedDate])
		VALUES('Dashboard', '/ops/dashboard', 2, @navigationId, '', 1,
				0, GETDATE(), 0, GETDATE());
		INSERT INTO Core.trNavigation([Title], [NavigationPath], [LevelId], [ParentNavigationId], [ImagePath], [SortId],
				[CreatedBy],[CreatedDate], [ModifiedBy], [ModifiedDate])
		VALUES('My Identity', '/ops/myidentity', 2, @navigationId, '', 2,
				0, GETDATE(), 0, GETDATE());
		INSERT INTO Core.trNavigation([Title], [NavigationPath], [LevelId], [ParentNavigationId], [ImagePath], [SortId],
				[CreatedBy],[CreatedDate], [ModifiedBy], [ModifiedDate])
		VALUES('My Profile', '/ops/myprofile', 2, @navigationId, '', 3,
				0, GETDATE(), 0, GETDATE());
		INSERT INTO Core.trNavigation([Title], [NavigationPath], [LevelId], [ParentNavigationId], [ImagePath], [SortId],
				[CreatedBy],[CreatedDate], [ModifiedBy], [ModifiedDate])
		VALUES('Notifications', '/ops/notifications', 2, @navigationId, '', 4,
				0, GETDATE(), 0, GETDATE());
		INSERT INTO Core.trNavigation([Title], [NavigationPath], [LevelId], [ParentNavigationId], [ImagePath], [SortId],
				[CreatedBy],[CreatedDate], [ModifiedBy], [ModifiedDate])
		VALUES('About', '/ops/about', 2, @navigationId, '', 5,
				0, GETDATE(), 0, GETDATE());
		INSERT INTO Core.trNavigation([Title], [NavigationPath], [LevelId], [ParentNavigationId], [ImagePath], [SortId],
				[CreatedBy],[CreatedDate], [ModifiedBy], [ModifiedDate])
		VALUES('Contact us', '/ops/contactus', 2, @navigationId, '', 6,
				0, GETDATE(), 0, GETDATE());

	END

	IF NOT EXISTS (SELECT 1 FROM Core.dmnIndustry)
	BEGIN
		INSERT INTO Core.dmnIndustry ([Name], [Weightage]) VALUES ('Entertainment Industry', 20)
		INSERT INTO Core.dmnIndustry ([Name], [Weightage]) VALUES ('Political Industry', 28.4)
		INSERT INTO Core.dmnIndustry ([Name], [Weightage]) VALUES ('Educational Industry', 7.2)
		INSERT INTO Core.dmnIndustry ([Name], [Weightage]) VALUES ('Healthcare Industry', 13.7)
		INSERT INTO Core.dmnIndustry ([Name], [Weightage]) VALUES ('Mechanical Industry',9.5)
		INSERT INTO Core.dmnIndustry ([Name], [Weightage]) VALUES ('Chemical Industry',17.9)
		INSERT INTO Core.dmnIndustry ([Name], [Weightage]) VALUES ('Textile Industry',15.8)
	END

	IF NOT EXISTS (SELECT 1 FROM Core.dmnCategory)
	BEGIN
		INSERT INTO Core.dmnCategory ([Name]) VALUES ('Profile')
		INSERT INTO Core.dmnCategory ([Name]) VALUES ('Education')
		INSERT INTO Core.dmnCategory ([Name]) VALUES ('SelfIndustry')
		INSERT INTO Core.dmnCategory ([Name]) VALUES ('Proffession')
		INSERT INTO Core.dmnCategory ([Name]) VALUES ('Business')
		INSERT INTO Core.dmnCategory ([Name]) VALUES ('Social')
	END

	IF NOT EXISTS (SELECT 1 FROM Core.dmnIndustryCategoryMap)
	BEGIN
		INSERT INTO Core.dmnIndustryCategoryMap([IndustryId] ,[CategoryId] ,[Weightage])
		VALUES (1,1,5.6)
		INSERT INTO Core.dmnIndustryCategoryMap([IndustryId] ,[CategoryId] ,[Weightage])
		VALUES (1,2,9.4)
		INSERT INTO Core.dmnIndustryCategoryMap([IndustryId] ,[CategoryId] ,[Weightage])
		VALUES (1,3,20)
		INSERT INTO Core.dmnIndustryCategoryMap([IndustryId] ,[CategoryId] ,[Weightage])
		VALUES (1,4,23.7)
		INSERT INTO Core.dmnIndustryCategoryMap([IndustryId] ,[CategoryId] ,[Weightage])
		VALUES (1,5,22.3)
		INSERT INTO Core.dmnIndustryCategoryMap([IndustryId] ,[CategoryId] ,[Weightage])
		VALUES (1,6,19)
	END

	IF NOT EXISTS (SELECT 1 FROM Core.trUserScore)
	BEGIN
		INSERT INTO Core.trUserScore (UserId, ICMapId, Score, CreatedOn) VALUES (1, 1, 7, GETDATE())
		INSERT INTO Core.trUserScore (UserId, ICMapId, Score, CreatedOn) VALUES (1, 2, 28, GETDATE())
		INSERT INTO Core.trUserScore (UserId, ICMapId, Score, CreatedOn) VALUES (1, 3, 42, GETDATE())
		INSERT INTO Core.trUserScore (UserId, ICMapId, Score, CreatedOn) VALUES (1, 4, 4, GETDATE())
		INSERT INTO Core.trUserScore (UserId, ICMapId, Score, CreatedOn) VALUES (1, 5, 36, GETDATE())
		INSERT INTO Core.trUserScore (UserId, ICMapId, Score, CreatedOn) VALUES (1, 6, 29, GETDATE())
	END

	IF NOT EXISTS (SELECT 1 FROM [Scores].[dmnInfluencer])
	BEGIN
		INSERT INTO [Scores].[dmnInfluencer] VALUES (1, 'Google', 'Social', '010411868023207416729:pkel_dw1rf8', '', '', NULL, NULL, NULL, 1 ,0, GETDATE(),0, GETDATE())
		INSERT INTO [Scores].[dmnInfluencer] VALUES (2, 'Twitter', 'Social', '5xgdLaKReD2Z1irzTcTM9IK4c', '', '', '5xfKvmddPhsvqEL6zG6hK15rhyzcusCHWUQDtCmTMZxOti0ra6', '1034118272361218049-tm8qIKXhDToZDYg0QRWrbjsGP13Y7Z', 'IlL7Y8eIWkSm8XiHyWyzIFg5tCF8AFq6BVG0hrvbbyRD1', 1 ,0, GETDATE(),0, GETDATE())
	END