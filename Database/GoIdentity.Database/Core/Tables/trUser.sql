CREATE TABLE [Core].[trUser]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	
	[UserName] VARCHAR(500) NULL,
	[Password] VARBINARY(8000) NULL DEFAULT(NULL),

	[FirstName] VARCHAR(100) NOT NULL,
	[LastName] VARCHAR(100) NOT NULL,
	[Email] VARCHAR(500) NULL,
	[MobileNumber] VARCHAR(15) NULL,

	[UniqueId] UNIQUEIDENTIFIER DEFAULT(NEWID()),
	[JsonFeed] VARCHAR(8000) NULL,
	
    [AccountType] INT NULL DEFAULT (1),

	[DefaultRole] VARCHAR(50) NOT NULL DEFAULT('Regular'),
	[IsLocked] BIT NOT NULL DEFAULT(0),
	[LockedDate] DATETIME NULL,
	[IsSuspended] BIT DEFAULT(0),
	[SuspendedDate] DATETIME NULL,
	[ApiKey] VARCHAR(200) NULL,

	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [ModifiedDate] DATETIME NOT NULL 
)
