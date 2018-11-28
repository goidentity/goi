create proc Scores.getProfileScore
@userId INT
AS
BEGIN

declare @profileScore TABLE
(
	Profile DECIMAL(18,2),
	Educational DECIMAL(18,2),
	Industry DECIMAL(18,2),
	Professional DECIMAL(18,2),
	Business DECIMAL(18,2),
	Social DECIMAL(18,2),
	Total DECIMAL(18,2)
);

declare @basicScore DECIMAL (18,2) = 5;
declare @educationalScore DECIMAL (18,2) = 0;
declare @industryScore DECIMAL (18,2) = 0;
declare @professionalScore DECIMAL (18,2) = 0;
declare @businessScore DECIMAL (18,2) = 0;
declare @socialScore DECIMAL (18,2) = 5;

declare @esFactor DECIMAL (18,2) = .5
declare @isFactor DECIMAL (18,2) = .5
declare @psFactor DECIMAL (18,2) = .5
declare @bsFactor DECIMAL (18,2) = .5
declare @ssFactor DECIMAL (18,2) = 1

IF EXISTS (SELECT * FROM Core.trUserPersonnelInfo
WHERE UserId = @userId
AND 
	(LEN(CityOfLiving) > 1 AND
	LEN(CityOfWork) > 1
	)
)
BEGIN
	SET @basicScore = @basicScore + 5;
END
ELSE
BEGIN
	SET @basicScore = @basicScore + 0;
END

IF EXISTS (SELECT * FROM Core.trUserEducation WHERE UserId = @userId and EducationType = 'Highest')
BEGIN
	SET @basicScore = (@basicScore + 2)*@esFactor;
	SET @educationalScore = @educationalScore + 2;
END

IF EXISTS (SELECT * FROM Core.trUserEducation WHERE UserId = @userId and EducationType = 'Professional')
BEGIN
	SET @educationalScore = @educationalScore + 2;
END

IF EXISTS (SELECT * FROM Core.trUserEducation WHERE UserId = @userId and EducationType = 'Certification')
BEGIN
	SET @educationalScore = @educationalScore + 2;
END

IF EXISTS (SELECT * FROM Core.trUserEducation WHERE UserId = @userId and EducationType = 'Award')
BEGIN
	SET @educationalScore = @educationalScore + 2;
END

IF EXISTS (SELECT * FROM Core.trUserEducation WHERE UserId = @userId and EducationType = 'Publication')
BEGIN
	SET @educationalScore = @educationalScore + 2;
END

IF EXISTS (SELECT * FROM Core.trUserPersonnelInfo WHERE UserId = @userId and LEN(PrimaryIndustryOfWork) > 1)
BEGIN
	SET @basicScore = (@basicScore + 15)*@isFactor;
	SET @industryScore = 7.5;
END

IF EXISTS (SELECT * FROM Core.trUserPersonnelInfo WHERE UserId = @userId and LEN(SecondaryIndustryOfWork) > 1)
BEGIN
	SET @industryScore = @industryScore + 7.5;
END

IF EXISTS (SELECT * FROM Core.trUserExperience WHERE UserId = @userId and LEN(OrganizationName) > 1)
BEGIN
	SET @basicScore = (@basicScore + 15)*@psFactor;
	SET @professionalScore = 15;
END

IF EXISTS (SELECT * FROM Core.trUserExperience WHERE UserId = @userId and LEN(PersonalURL) > 1)
BEGIN
	SET @professionalScore = 7.5;
END

IF EXISTS (SELECT * FROM Core.trUserExperience WHERE UserId = @userId and LEN(ListingURL) > 1)
BEGIN
	SET @professionalScore = 7.5;
END

IF EXISTS (SELECT * FROM Core.trBusinessProfile WHERE UserId = @userId and LEN(CompanyName) > 1)
BEGIN
	SET @basicScore = (@basicScore + 10)*@bsFactor;
	SET @businessScore = 10;
END

IF EXISTS (select UI.Id from Scores.trUserInfluencerAuth UI
		JOIN Scores.dmnInfluencer I ON UI.InfluencerId = I.InfluencerId
		 WHERE UserId = @userId and Title = 'Twitter')
BEGIN
	SET @socialScore = @socialScore + 5;
END

IF EXISTS (select UI.Id from Scores.trUserInfluencerAuth UI
		JOIN Scores.dmnInfluencer I ON UI.InfluencerId = I.InfluencerId
		 WHERE UserId = @userId and Title = 'Facebook')
BEGIN
	SET @socialScore = @socialScore + 5;
END

IF EXISTS (select UI.Id from Scores.trUserInfluencerAuth UI
		JOIN Scores.dmnInfluencer I ON UI.InfluencerId = I.InfluencerId
		 WHERE UserId = @userId and Title = 'LinkedIn')
BEGIN
	SET @socialScore = @socialScore + 10;
END

SET @educationalScore = @educationalScore*@esFactor
SET @industryScore = @industryScore*@isFactor
SET @professionalScore = @professionalScore*@psFactor
SET @businessScore = @businessScore*@bsFactor
SET @socialScore = @socialScore*@psFactor

INSERT INTO @profileScore (Profile , Educational , Industry ,Professional , Business , Social , Total)
values (@basicScore, @educationalScore, @industryScore, @professionalScore, @businessScore, @socialScore, 
	@basicScore + @educationalScore + @industryScore + @professionalScore + @businessScore + @socialScore);

select * from @profileScore

END

