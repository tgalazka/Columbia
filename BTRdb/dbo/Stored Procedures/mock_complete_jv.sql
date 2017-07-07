-- =============================================
-- Author:      Kenneth Cooper
-- Create Date: <Create Date, , >
-- Description: Mock stored proc for completing a jv
-- =============================================
CREATE PROCEDURE mock_complete_jv
(
    -- Add the parameters for the stored procedure here
    @jv_doc_id int Output,
	@P_user_id_in varchar(30),
	@P_status_ind varchar(1) OUTPUT, 
	@P_status_message varchar(4000) OUTPUT
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

	Set @P_status_ind = 'C'
	Set @P_status_message = 'Good'
END
