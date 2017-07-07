-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE account_byIndex
@index_key int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT [account_key],[index_key],[account_number],[account_description],[account_number_description],[account_balance]
  FROM [dbo].[Account] 
  Where [index_key] = @index_key
END
