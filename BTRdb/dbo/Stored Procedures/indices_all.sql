
-- =============================================
-- Author:		Ken Cooper
-- Create date: 4/25/17
-- Description:	Get all of the indexes
-- =============================================
create PROCEDURE [dbo].[indices_all]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT i.[index_key]
		  ,i.[index_orgn_code]
		  ,i.[index_prog_code]
		  ,i.[index_description]
		  ,i.[index_number_description] as index_code_description
	FROM [dbo].[Index] i
END
