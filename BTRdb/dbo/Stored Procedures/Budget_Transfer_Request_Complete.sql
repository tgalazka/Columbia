-- Batch submitted through debugger: SQLQuery1.sql|7|0|C:\Users\themaster\AppData\Local\Temp\2\~vs4E4.sql
-- =============================================
-- Author:		Joe M.
-- Create date: 6/26/2017
-- Description:	Used to submit the JV, modified by Ken C to use btr_key instead of btr_guid
-- =============================================
CREATE PROCEDURE [dbo].[Budget_Transfer_Request_Complete] 
	-- Add the parameters for the stored procedure here
	@btr_key int,
	@jv_doc_id		varchar(8) OUT,
	@P_status_ind	varchar(1) OUT,
	@P_status_message varchar(4000) OUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN
		EXEC Update_Transfer_Activity_Total_Amount @btr_key
	END
	BEGIN
		EXEC Create_JV @btr_key, @jv_doc_id OUTPUT, @P_status_ind OUTPUT, @P_status_message OUTPUT
	END
END
