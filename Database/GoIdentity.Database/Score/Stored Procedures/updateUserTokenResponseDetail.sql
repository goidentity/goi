CREATE PROCEDURE [Scores].updateUserTokenResponseDetail
(
	@userTokenResponseDetail [Scores].UserTokenResponseDetailType READONLY
)
AS
BEGIN
	INSERT INTO [Scores].trUserTokenResponseDetail([UserTokenResponseId]
           ,[ProcessedDate]
           ,[ResponseDataFileName]
           ,[NlpEntitiesFileName]
           ,[NlpEntities]
           ,[NlpSentimentFileName]
           ,[NlpSentiment]
           ,[NlpSyntaxFileName]
           ,[NlpSyntax]
           ,[NlpClassifyFileName]
           ,[NlpClassify]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]) 
	SELECT * FROM @userTokenResponseDetail
END