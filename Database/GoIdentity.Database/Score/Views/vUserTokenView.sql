CREATE VIEW [Core].[vUserTokenView]
AS 
	
SELECT 1 as RowNo, U.UserId, 'Basic' as TokenName, U.FirstName + ' ' + U.LastName + ' ' + ISNULL(UPI.CityOfLiving, '') as Token FROM Core.trUser U
LEFT JOIN Core.trUserPersonnelInfo UPI ON U.UserId = UPI.UserId

UNION

SELECT ROW_NUMBER() OVER (PARTITION BY U.UserId ORDER BY UPI.Title) as RowNo, U.UserId, 'Education' as TokenName, U.FirstName + ' ' + U.LastName + ISNULL(UPI.Title, '') as Token FROM Core.trUser U
LEFT JOIN Core.trUserEducation UPI ON U.UserId = UPI.UserId and UPI.EducationType = 'Highest'

UNION

SELECT 1 as RowNo ,U.UserId, 'PrimaryIndustry' as TokenName, U.FirstName + ' ' + U.LastName + ISNULL(UPI.PrimaryIndustryOfWork, '') as Token FROM Core.trUser U
LEFT JOIN Core.trUserPersonnelInfo UPI ON U.UserId = UPI.UserId

UNION

SELECT ROW_NUMBER() OVER (PARTITION BY U.UserId ORDER BY UPI.OrganizationName) as RowNo, U.UserId, 'Professional' as TokenName, U.FirstName + ' ' + U.LastName + ISNULL(UPI.OrganizationName, '') as Token FROM Core.trUser U
LEFT JOIN Core.trUserExperience UPI ON U.UserId = UPI.UserId

UNION

SELECT ROW_NUMBER() OVER (PARTITION BY U.UserId ORDER BY UPI.CompanyName) as RowNo, U.UserId, 'Business' as TokenName, U.FirstName + ' ' + U.LastName + ISNULL(UPI.CompanyName, '') as Token FROM Core.trUser U
LEFT JOIN Core.trBusinessProfile UPI ON U.UserId = UPI.UserId