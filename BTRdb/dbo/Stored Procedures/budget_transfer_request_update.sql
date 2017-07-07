

-- =============================================
-- Author:		Kenneth Cooper
-- Create date: 5/23/2017
-- Description:	SP used to create new BTR records in an expanded form
-- =============================================
CREATE PROCEDURE [dbo].[budget_transfer_request_update]
	-- Add the parameters for the stored procedure here
	@btr_key int,
	@title varchar(200),
	@budget_type_key int,
	@total_amount money,
	@explanation varchar(300),
	@requestor_uni_key int,
	@transfer_type_key int,
	@life_cycle_key int,
	@modified_by int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	--Write data to archive table

	Update [dbo].[budget_transfer_request]
	Set	budget_type_key =@budget_type_key
		,total_amount = @total_amount
		,explanation = @explanation
		,requestor_uni_key = @requestor_uni_key
		,transfer_type_key = @transfer_type_key
		,title = @title
		,modified_by = @modified_by
		,life_cycle_key = @life_cycle_key
		,modified = GetDate()
	Where btr_key = @btr_key
	
	Select * from [dbo].[vw_budget_transfer_request_records] Where btr_key = @btr_key
END


