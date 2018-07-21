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
,map.CategoryId, C.Name as Category, TS.CreatedOn, TS.UserId, cast(I.Weightage * TS.Score / 100 as decimal(18,2)) as Score, 
'CurrentScore' as ScoreType
 from Core.trUserScore TS
JOIN Core.dmnIndustryCategoryMap map on TS.ICMapId = map.Id
JOIN Core.dmnIndustry I ON map.IndustryId = I.Id
JOIN Core.dmnCategory C ON map.CategoryId = C.Id
JOIN recentV R ON TS.UserId = R.UserId and TS.GroupId = R.GroupId
UNION
select map.IndustryId, I.Name as Industry, I.Weightage as IndustryWeightage
,map.CategoryId, C.Name as Category, TS.CreatedOn, TS.UserId, cast(I.Weightage * TS.Score / 100 as decimal(18,2)) as Score, 'LastScore'
 from Core.trUserScore TS
JOIN Core.dmnIndustryCategoryMap map on TS.ICMapId = map.Id
JOIN Core.dmnIndustry I ON map.IndustryId = I.Id
JOIN Core.dmnCategory C ON map.CategoryId = C.Id
JOIN nextRecentV R ON TS.UserId = R.UserId and TS.GroupId = R.GroupId