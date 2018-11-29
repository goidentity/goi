CREATE PROCEDURE [Scores].updateUserTokenResponse
(
	@userTokenResponse [Scores].UserTokenResponseType READONLY
)
AS
BEGIN
	INSERT INTO [Scores].trUserTokenResponse  ([UserId]
           ,[Token]
           ,[ProcessDate]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]) 
	SELECT [UserId]
           ,[Token]
           ,[ProcessDate]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[ModifiedBy]
           ,[ModifiedDate] FROM @userTokenResponse
END