
-- =============================================
-- Author:		Kenneth Cooper
-- Create date: 4/16/2017
-- Description:	Execute a query to return balance for an account from Banner
-- =============================================
Create PROCEDURE [dbo].[accountbalance_byaccountkey] 
	@account_key int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @RC int,
	@P_coas_code varchar(1),
	@P_fund_code varchar(1),
	@P_orgn_code varchar(6),
	@P_acct_code varchar(4),
	@P_prog_code varchar(3),
	@available_balance decimal(18,0)

	Select @P_coas_code = index_coas_code, @P_fund_code = index_fund_code, @P_orgn_code= index_orgn_code, @P_acct_code = a.account_number, @P_prog_code= index_prog_code 
	From [index] i inner join [account] a on i.index_key = a.index_key
	Where a.account_key = @account_key

	/*
	Select    @P_coas_code ,@P_fund_code	  ,@P_orgn_code	  ,@P_acct_code	  ,@P_prog_code
	*/

	EXECUTE @RC = [dbo].[Get_Account_Available_Balance]  @P_coas_code ,@P_fund_code ,@P_orgn_code  ,@P_acct_code  ,@P_prog_code  ,@available_balance OUTPUT

	Select [account_key],[index_key],[account_number],[account_description],[account_number_description], @available_balance as [account_balance] 
	From dbo.account 
	Where account_key = @account_key
END

