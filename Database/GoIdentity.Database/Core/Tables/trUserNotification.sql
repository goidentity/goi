CREATE TABLE [Core].[trUserNotification]
(
	[UserNotificationId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	UserId INT,
	NotificationDate DATETIME,
	MessageHeader VARCHAR(500),
	MessageContent VARCHAR(500),

	MessageStatus tinyint DEFAULT(0),

	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [ModifiedDate] DATETIME NOT NULL
)
