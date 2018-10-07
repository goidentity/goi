CREATE PROCEDURE [Scores].[updateEngineLogs]
	@logs [Scores].[EngineResponseType] readonly
AS
BEGIN

	Update A
	SET A.LastRefreshedDate = B.TransactionDate
	FROM [Scores].[trUserInfluencerAuth] A	
	JOIN @logs B on A.UserId = B.UserId AND A.InfluencerId = B.InfluencerId
	WHERE B.PullStatus = 'Success';

	insert into [Scores].[trEngineLog] (UserInfluencerAuthId, [UserId], [InfluencerId], PullStatus, Response, Remarks, TransactionDate,
	[CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate] )
	select B.Id as UserInfluencerAuthId, B.UserId, B.InfluencerId, A.PullStatus, A.Response, A.Remarks, B.LastRefreshedDate,
	0, GETDATE(), 0, GETDATE()
	from @logs A
	JOIN [Scores].[trUserInfluencerAuth] B ON A.UserId = B.UserId and A.InfluencerId = B.InfluencerId;

	SELECT TOP 1 * FROM Core.trUser;

END
