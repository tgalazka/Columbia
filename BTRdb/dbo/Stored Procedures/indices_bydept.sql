-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[indices_bydept]
	-- Add the parameters for the stored procedure here
	@dept int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT i.[index_key]
      ,i.[index_orgn_code] 
      ,i.[index_prog_code] 
      ,i.[index_description]
      ,i.[index_number_description] 
FROM [dbo].[Index] i
Where i.[index_prog_code] = @dept
END

