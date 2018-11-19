CREATE PROCEDURE [Core].[createUser]
	@user [Core].[UserType] Readonly,
	@password varchar(500)
AS
BEGIN
declare @userId int;

	insert into Core.trUser (UserName
,Password
,FirstName
,LastName
,Email
,MobileNumber
,UniqueId
,JsonFeed
,AccountType
,DefaultRole
,IsLocked
,LockedDate
,IsSuspended
,SuspendedDate
,ApiKey
,CreatedBy
,CreatedDate
,ModifiedBy
,ModifiedDate)
select UserName
,Core.encryptData(@password)
,FirstName
,LastName
,Email
,MobileNumber
,NEWID()
,NULL
,1
,'User'
,0
,NULL
,0
,NULL
,NEWID()
,0
,GETDATE()
,0
,GETDATE() from @user;

select @userId = SCOPE_IDENTITY();

select * from COre.trUser where UserId = @userId;

END
