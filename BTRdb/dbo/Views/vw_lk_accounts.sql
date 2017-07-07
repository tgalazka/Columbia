
CREATE VIEW [dbo].[vw_lk_accounts] AS

SELECT [account_key]
      ,[index_key]
      ,[account_number_description]
      ,[account_balance]
FROM [dbo].[Account]
--Order by index_key, account_number

