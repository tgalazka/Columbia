

-- =============================================
-- Author:		Kenneth Cooper
-- Create date: 6/10/2017
-- Description:	Used to assign reviewers and populate the reviewers table
-- =============================================
CREATE PROCEDURE [dbo].[transfer_activity_assign_reviewers]
	-- Add the parameters for the stored procedure here
	@transfer_activity_key int,
	@approval_level int,
	@workflow_guid uniqueidentifier

AS
BEGIN
	SET NOCOUNT ON;

	Insert into [dbo].[transfer_activity_reviewers] (btr_key, transfer_activity_key,approval_matrix_key, index_key, account_key, approver_uni_key, role_level,status_key,workflow_guid)
	Select ta.btr_key, ta.transfer_activity_key, am.approval_matrix_key, ta.index_key, ta.account_key, am.uni_key, am.role_level, 1 as status_key , @workflow_guid as workflow_guid
	From transfer_activity ta inner join approval_matrix am on (ta.index_key = am.index_key)
	Where ta.transfer_activity_key = @transfer_activity_key and am.role_level = @approval_level

	Select tar.*, u.uni_name, u.uni_email, u.uni_code
	From [dbo].[transfer_activity_reviewers] tar inner join [dbo].[users] u on (tar.approver_uni_key = u.uni_key)
	Where transfer_activity_key = @transfer_activity_key and role_level = @approval_level and workflow_guid = @workflow_guid
	
END
