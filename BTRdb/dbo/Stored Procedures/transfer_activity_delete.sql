

-- =============================================
-- Author:		Kenneth Cooper
-- Create date: 5/23/2017
-- Description:	SP used to create new transfer activities records in an shorted form
-- =============================================
CREATE PROCEDURE [dbo].[transfer_activity_delete]
	-- Add the parameters for the stored procedure here
	@transfer_activity_key int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Delete from  [dbo].[transfer_activity]
	Where transfer_activity_key = @transfer_activity_key

END

