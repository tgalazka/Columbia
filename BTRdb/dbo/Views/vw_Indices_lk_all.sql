
CREATE VIEW [dbo].[vw_Indices_lk_all] AS
SELECT [index_key]
      ,[index_orgn_code] as index_code
      ,[index_prog_code] as dept_code
      ,[index_description]
      ,[index_number_description] as index_code_description
FROM [dbo].[Index]
