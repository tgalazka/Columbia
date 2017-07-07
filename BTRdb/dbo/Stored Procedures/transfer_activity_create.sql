
-- =============================================
-- Author:		Kenneth Cooper
-- Create date: 5/23/2017
-- Description:	SP used to create new transfer activities records in an shorted form
-- =============================================
CREATE PROCEDURE [dbo].[transfer_activity_create]
	-- Add the parameters for the stored procedure here
	@btr_key int,
	@position_type_key int,
	@index_key int,
	@account_key int,
	@amount money,
	@created_by int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[transfer_activity]
		(btr_key
		,position_type_key
		,index_key
		,account_key
		,amount
		,created_by
		,modified_by
		)
	VALUES
		(@btr_key
		,@position_type_key
		,@index_key
		,@account_key
		,@amount
		,@created_by
		,@created_by)

	Declare @newKey int
	Set @newKey = (SELECT transfer_activity_key FROM [transfer_activity] WHERE transfer_activity_key = SCOPE_IDENTITY())
	Select * from [dbo].[vw_transfer_activities_datarecords] Where transfer_activity_key = @newKey

END


