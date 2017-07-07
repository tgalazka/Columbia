

-- =============================================
-- Author:		Kenneth Cooper
-- Create date: 5/23/2017
-- Description:	SP used to create new transfer activities records in an shorted form
-- =============================================
CREATE PROCEDURE [dbo].[transfer_activity_update]
	-- Add the parameters for the stored procedure here
	@transfer_activity_key int,
	@index_key int,
	@account_key int,
	@amount money,
	@modified_by int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Update  [dbo].[transfer_activity]
	Set 
		index_key = @index_key
		,account_key = @account_key
		,amount = @amount
		,modified_by = @modified_by
	Where transfer_activity_key = @transfer_activity_key

	Select * from [dbo].[vw_transfer_activities_datarecords] Where transfer_activity_key = @transfer_activity_key

END

