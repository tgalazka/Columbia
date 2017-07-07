


CREATE VIEW [dbo].[v_Transfer_Activity_Create_JV]
AS
SELECT i.index_number, i.index_coas_code, i.index_fund_code, i.index_orgn_code, a.account_number, i.index_prog_code, i.index_actv_code,
       i.index_locn_code, CASE WHEN ta.position_type_key = 1 THEN '+' WHEN ta.position_type_key = 2 THEN '-' END AS P_dr_cr_ind, 
	   ta.amount, 0 as total_amount, '' as change_type, u.uni_code as creation_user, ta.transfer_activity_key, ta.btr_key
FROM dbo.transfer_activity ta
INNER JOIN [index] i ON ta.index_key = i.index_key 
INNER JOIN account a ON ta.account_key = a.account_key
INNER JOIN users u ON ta.created_by = u.uni_key
