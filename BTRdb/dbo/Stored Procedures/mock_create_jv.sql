
-- =============================================
-- Author:		Kenneth Cooper
-- Create date: 7/8/2016
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[mock_create_jv]
	-- Add the parameters for the stored procedure here
	@jv_doc_id		varchar(8) OUT,
	@P_acci_code varchar(6), 
	@P_coas_code varchar(1), 
	@P_fund_code varchar(6), 
	@P_orgn_code varchar(6), 
	@P_acct_code varchar(6), 
	@P_prog_code varchar(6),  
	@P_actv_code varchar(6),
	@P_locn_code varchar(6), 
	@P_dr_cr_ind varchar(1), 
	@P_line_amt  decimal, 
	@P_doc_total_amt decimal, 
	@P_change_type varchar(1), 
	@P_user_id_in varchar(30),
	@P_status_ind	varchar(1) OUT,
	@P_status_message varchar(4000) OUT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    --START BY CREATING THE JV DOC ID
	DECLARE @create_jv_error_message varchar(4000)

	Set @P_status_ind = 'C'
	Select @jv_doc_id = floor((rand(2000) * 1000))
	Set @P_status_message = 'Good'
END