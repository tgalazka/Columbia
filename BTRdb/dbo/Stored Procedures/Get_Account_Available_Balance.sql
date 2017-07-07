

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Get_Account_Available_Balance]
	-- Add the parameters for the stored procedure here
	@P_coas_code	varchar(1),
	@P_fund_code	varchar(1),
	@P_orgn_code	varchar(6),
	@P_acct_code	varchar(4),
	@P_prog_code	varchar(3),
	@available_balance decimal OUT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN
		Select @available_balance = account_balance from account where account_number = @P_acct_code
		--Select @available_balance
		-- This is only available from banner
		--EXEC ('BEGIN bzebxfr.f_get_avail_bal(?,?,?,?,?,?); END;', @P_coas_code, @P_fund_code, @P_orgn_code, @P_acct_code, @P_prog_code, @available_balance OUTPUT) AT [BANNER-PPRD]	
	END    	 
END

