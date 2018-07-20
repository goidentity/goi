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
