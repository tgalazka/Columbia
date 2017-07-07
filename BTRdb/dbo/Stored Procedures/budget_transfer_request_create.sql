
-- =============================================
-- Author:		Kenneth Cooper
-- Create date: 5/23/2017
-- Description:	SP used to create new BTR records in an expanded form
-- =============================================
CREATE PROCEDURE [dbo].[budget_transfer_request_create]
	-- Add the parameters for the stored procedure here
	@title varchar(200),
	@budget_type_key int,
	@total_amount money,
	@explanation varchar(300),
	@requestor_uni_key int,
	@transfer_type_key int,
	@created_by int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Declare @modified_by int, @newKey int;

	Set @modified_by = @created_by

	INSERT INTO [dbo].[budget_transfer_request]
		(budget_type_key
		,total_amount
		,explanation
		,requestor_uni_key
		,transfer_type_key
		,title
		,modified_by
		,created_by)
	VALUES
		(@budget_type_key
		,@total_amount
		,@explanation
		,@requestor_uni_key
		,@transfer_type_key
		,@title
		,@modified_by
		,@created_by)

	Set @newKey = (SELECT btr_key FROM [budget_transfer_request] WHERE btr_key = SCOPE_IDENTITY())
	Select * from [dbo].[vw_budget_transfer_request_records] Where btr_key = @newKey

END

