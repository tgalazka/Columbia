
-- =============================================
-- Author:		Kenneth Cooper
-- Create date: 4/15/2017
-- Description:	Execute a query to return balances associated with index keys that were sent
-- =============================================
CREATE PROCEDURE [dbo].[accountbalances_byindexkeys] 
	@indexKeys varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @sqlStmt nvarchar(500);  

	Set @indexKeys = ',' + @indexKeys + ','
	Set @sqlStmt = N'Select [account_key],[index_key],[account_number],[account_description],[account_number_description],[account_balance] from account where charindex('','' + CAST(index_key as nvarchar(20)) + '','',''' + @indexKeys +''') > 0'	
	--Select @sqlStmt

	
    -- Insert statements for procedure here
	EXECUTE sp_executesql @sqlStmt
END

