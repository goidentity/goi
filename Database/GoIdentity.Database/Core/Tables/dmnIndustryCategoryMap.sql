CREATE TABLE [Core].[dmnIndustryCategoryMap]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IndustryId] INT NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [Weightage] DECIMAL(18, 2) NOT NULL
)
