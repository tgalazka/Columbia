
-- =============================================
-- Author:		Ken Cooper
-- Create date: 4/25/17
-- Description:	Get indices row owned by dept
-- =============================================
CREATE PROCEDURE [dbo].[indices_owned_bydept]
	-- Add the parameters for the stored procedure here
	@dept int,
	@uni varchar(20)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;
	SELECT i.[index_key]
	      ,i.[index_orgn_code] 
	      ,i.[index_prog_code] 
	      ,i.[index_description]
	      ,i.[index_number_description] 
	FROM [dbo].[Index] as i inner join [dbo].[responsibility_matrix] io on i.index_key = io.index_key
	Where io.uni = @uni and i.[index_prog_code] = @dept
END
