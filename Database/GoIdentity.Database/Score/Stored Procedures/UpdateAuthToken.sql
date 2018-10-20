CREATE PROCEDURE Scores.UpdateAuthToken
@userId INT, 
@influencerId SMALLINT, 
@userName NVARCHAR(MAX), 
@secret NVARCHAR(MAX), 
@secret1 NVARCHAR(MAX) = null, 
@secret2 NVARCHAR(MAX) = null, 
@secret3 NVARCHAR(MAX) = null, 
@other1 NVARCHAR(MAX) = null, 
@other2 NVARCHAR(MAX) = null
AS 
BEGIN

MERGE Scores.trUserInfluencerAuth AS TARGET
USING(SELECT @userId AS UserId, @influencerId InfluencerId, @userName AS UserName, @secret AS Secret, 
			@secret1 AS Secret1, @secret2 AS Secret2, @secret3 AS Secret3, @other1 AS Other1, @other2 AS Other2)AS SOURCE
ON TARGET.UserId = SOURCE.userId and TARGET.InfluencerId = SOURCE.influencerId
WHEN MATCHED THEN
	UPDATE SET UserName=  SOURCE.UserName,
		Secret = SOURCE.Secret, 
		Secret1 = SOURCE.Secret1,
		Secret2 = SOURCE.Secret2,
		Secret3 = SOURCE.Secret3,
		Other1 = SOURCE.Other1,
		Other2 = SOURCE.Other2,
		LastRefreshedDate = GETDATE(),
		ModifiedBy = SUSER_ID(),
		ModifiedDate = GETDATE()
WHEN NOT MATCHED THEN
	INSERT(UserId, InfluencerId, UserName, Secret, Secret1, Secret2, Secret3, 
			Other1, Other2, LastRefreshedDate, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)
	VALUES(SOURCE.UserId, SOURCE.InfluencerId, SOURCE.UserName, SOURCE.Secret, SOURCE.Secret1, SOURCE.Secret2, SOURCE.Secret3, 
			SOURCE.Other1, SOURCE.Other2, GETDATE(), SUSER_ID(), GETDATE(), SUSER_ID(),GETDATE());
	
END
GO