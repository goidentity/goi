create view Core.vUserScore
AS
with recentV
AS
(
	select UserId, max(CreatedOn) as MaxDate from Core.trUserScore
	group by UserId
)
select map.IndustryId, I.Name as Industry, I.Weightage as IndustryWeightage
,map.CategoryId, C.Name as Category, TS.UserId, TS.Score
 from Core.trUserScore TS
JOIN Core.dmnIndustryCategoryMap map on TS.ICMapId = map.Id
JOIN Core.dmnIndustry I ON map.IndustryId = I.Id
JOIN Core.dmnCategory C ON map.CategoryId = C.Id
JOIN recentV R ON TS.UserId = R.UserId and TS.CreatedOn = R.MaxDate

