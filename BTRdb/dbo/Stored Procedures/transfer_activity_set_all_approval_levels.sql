



-- =============================================
-- Author:		Kenneth Cooper
-- Create date: 6/10/2017
-- Description:	Used to populate all the approval levels for all transfer activities for a budget transfer request
-- =============================================
CREATE PROCEDURE [dbo].[transfer_activity_set_all_approval_levels]
	-- Add the parameters for the stored procedure here
	@btr_key int,
	@approval_level int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Update  [dbo].[transfer_activity]
	Set 
		approval_level = @approval_level
	Where btr_key = @btr_key

	Select * from [dbo].[vw_transfer_activities_datarecords] Where btr_key = @btr_key

END



