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
	SELECT * FROM @userTokenResponse
END