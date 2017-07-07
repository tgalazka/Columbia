

CREATE VIEW [dbo].[vw_Indices_lk_byowner] AS
SELECT i.[index_key]
      ,i.[index_orgn_code] as index_code
      ,i.[index_prog_code] as dept_code
      ,i.[index_description]
      ,i.[index_number_description] as index_code_description
	  ,io.uni as uni
FROM [dbo].[Index] as i inner join [dbo].[responsibility_matrix] io on i.index_key = io.index_key

