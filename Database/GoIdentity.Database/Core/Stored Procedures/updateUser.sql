CREATE PROCEDURE [Core].[updateUser]
	@user [Core].[UserType] Readonly,
	@userPersonnelInfo [Core].[UserPersonnelInfoType] Readonly,
	@userExperience [Core].[UserExperienceType] Readonly,
	@userEducation [Core].[UserEducationType] Readonly,
	@userBusiness [Core].[BusinessProfileType] Readonly
AS
BEGIN

	update A
		set 
		A.FirstName = B.FirstName
		,A.LastName = B.LastName
		,A.Email = B.Email
		,A.MobileNumber = B.MobileNumber

		,ModifiedDate = GETDATE()

	from Core.trUser A
	join @user B ON A.UserId = B.UserId;

	declare @userId INT;

	select @userId = UserId from @user;

	delete from Core.trUserPersonnelInfo where UserId = @userId;
	delete from Core.trUserExperience where UserId = @userId;
	delete from Core.trUserEducation where UserId = @userId;
	delete from Core.trBusinessProfile where UserId = @userId;
	
	INSERT INTO Core.trUserPersonnelInfo ([UserId], DoB,Gender,PlaceOfBirth,CityOfLiving,
	CityOfWork,MaritalStatus,BirthOfOrigin,Nationality,Citizenship,PRStatus,
	PrimaryIndustryOfWork,SecondaryIndustryOfWork,
	PrimaryIndustryOfBusiness,SecondaryIndustryOfBusiness,
	FutureRole,FutureIndustryOfWork,FutureIndustryOfBusiness,
	CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)
	SELECT 	@userId, DoB,Gender,PlaceOfBirth,CityOfLiving,
	CityOfWork,MaritalStatus,BirthOfOrigin,Nationality,Citizenship,PRStatus,
	PrimaryIndustryOfWork,SecondaryIndustryOfWork,
	PrimaryIndustryOfBusiness,SecondaryIndustryOfBusiness,
	FutureRole,FutureIndustryOfWork,FutureIndustryOfBusiness,
	@userId,GETDATE(), @userId, GETDATE() 
	FROM @userPersonnelInfo;

	INSERT INTO Core.trUserExperience ([UserId], OrganizationName , Designation , Roles , StartDate , EndDate , IsCurrent ,ReasonForChange,
	CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)
	SELECT [UserId], OrganizationName , Designation , Roles , StartDate , EndDate , IsCurrent ,ReasonForChange,
	@userId,GETDATE(), @userId, GETDATE() FROM @userExperience;

	INSERT INTO Core.trUserEducation([UserId], DegreeType, Title , UniversityOrBoard , InstitutionOrBoard , YearOfPass , Specialization ,
	CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)
	SELECT [UserId], DegreeType, Title , UniversityOrBoard , InstitutionOrBoard , YearOfPass , Specialization ,
	@userId,GETDATE(), @userId, GETDATE() FROM @userEducation;

	INSERT INTO Core.trBusinessProfile([UserId], CompanyName, YearOfEstablishment, ComponySize, Role ,
	CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)
	SELECT [UserId], CompanyName, YearOfEstablishment, ComponySize, Role ,
	@userId,GETDATE(), @userId, GETDATE() FROM @userBusiness;

END
