CREATE PROCEDURE [Scores].updateUserTokenResponseDetail
(
@userTokenResponse [Scores].[UserTokenResponseType] readonly,
@userTokenResponseDetail [Scores].UserTokenResponseDetailType READONLY
)
AS
BEGIN

	declare @userTokenResponseId int;

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
           ,[ModifiedDate] FROM @userTokenResponse;

	select @userTokenResponseId = SCOPE_IDENTITY();

	INSERT INTO [Scores].trUserTokenResponseDetail([UserTokenResponseId], 
	
	[ProcessedDate] ,
	[TokenLink] ,
	[Count] ,
	[Description] ,

	[AnalyzeEntities] ,
	[AnalyzeEntitiesTokens] ,
	[AnalyzeEntitiesScore] ,
	[AnalyzeEntitiesMagnitude] ,

	[AnalyzeEntitySentiment] ,
	[AnalyzeEntitySentimentTokens] ,
	[AnalyzeEntitySentimentScore] ,
	[AnalyzeEntitySentimentMagnitude] ,

	[AnalyzeSyntax] ,
	[AnalyzeSyntaxTokens] ,
	
	[ClassifyText] ,
	[ClassifyTextTokens],
	CreatedBy, CreatedDate, ModifiedBy, ModifiedDate
	) 
	SELECT @userTokenResponseId, 
	
	[ProcessedDate] ,
	[TokenLink] ,
	[Count] ,
	[Description] ,

	[AnalyzeEntities] ,
	[AnalyzeEntitiesTokens] ,
	[AnalyzeEntitiesScore] ,
	[AnalyzeEntitiesMagnitude] ,

	[AnalyzeEntitySentiment] ,
	[AnalyzeEntitySentimentTokens] ,
	[AnalyzeEntitySentimentScore] ,
	[AnalyzeEntitySentimentMagnitude] ,

	[AnalyzeSyntax] ,
	[AnalyzeSyntaxTokens] ,
	
	[ClassifyText] ,
	[ClassifyTextTokens],
	0, GETDATE(), 0, GETDATE()
	FROM @userTokenResponseDetail;

END