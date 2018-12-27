create view Core.vUserScore
AS
with recentV
AS
(
	select top 1 UserId, GroupId, MAX(CreatedOn) as MaxDate from Core.trUserScore
	group by UserId, GroupId
	ORDER BY MAX(CreatedOn) DESC
), nextRecentV
AS(
select UserId, GroupId, MAX(CreatedOn) as MaxDate from Core.trUserScore
	group by UserId, GroupId
	ORDER BY MAX(CreatedOn) DESC
	OFFSET 1 ROWs
	FETCH NEXT 1 ROWS ONLY
)
select map.IndustryId, I.Name as Industry, I.Weightage as IndustryWeightage
,map.CategoryId, C.Name as Category, C.Weightage as CategoryWeightage, TS.CreatedOn, TS.UserId, TS.Score, TS.PositiveScore, TS.NeutralScore, TS.NegativeScore,
'CurrentScore' as ScoreType
 from Core.trUserScore TS
JOIN Core.dmnIndustryCategoryMap map on TS.ICMapId = map.Id
JOIN Core.dmnIndustry I ON map.IndustryId = I.Id
JOIN Core.dmnCategory C ON map.CategoryId = C.Id
JOIN recentV R ON TS.UserId = R.UserId and TS.GroupId = R.GroupId
UNION
select map.IndustryId, I.Name as Industry, I.Weightage as IndustryWeightage
,map.CategoryId, C.Name as Category, C.Weightage as CategoryWeightage, TS.CreatedOn, TS.UserId, TS.Score, TS.PositiveScore, TS.NeutralScore, TS.NegativeScore, 'LastScore'
 from Core.trUserScore TS
JOIN Core.dmnIndustryCategoryMap map on TS.ICMapId = map.Id
JOIN Core.dmnIndustry I ON map.IndustryId = I.Id
JOIN Core.dmnCategory C ON map.CategoryId = C.Id
JOIN nextRecentV R ON TS.UserId = R.UserId and TS.GroupId = R.GroupId