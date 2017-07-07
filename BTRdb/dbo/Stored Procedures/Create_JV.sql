
-- =============================================
-- Author:		Joe Messina
-- Create date: 7/8/2016
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Create_JV]
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
	PRINT N'Entering _______________________________________________';  
    --START BY CREATING THE JV DOC ID
	DECLARE @create_jv_error_message varchar(4000)
	BEGIN TRY
		BEGIN
			SET @create_jv_error_message = 'Creating JV Doc ID!'
			DECLARE @jv_doc_id_old varchar(8)
			SET @jv_doc_id_old = (SELECT TOP 1 jv_doc_id FROM transfer_activity WHERE btr_key = @btr_key ORDER BY transfer_activity_key) --changed by KJC
			IF (@jv_doc_id_old IS NULL OR LEN(RTRIM(@jv_doc_id_old)) < 2)
				BEGIN
					EXEC Get_JV @jv_doc_id OUTPUT
					SELECT @jv_doc_id
				END
			ELSE
				BEGIN
					SET @jv_doc_id = @jv_doc_id_old					
				END
		END
	PRINT N'>>> @jv_doc_id=' + @jv_doc_id;  
		BEGIN
		
			DECLARE @intLOOP int
			DECLARE @P_acci_code varchar(6), @P_coas_code varchar(1), @P_fund_code varchar(6), @P_orgn_code varchar(6), @P_acct_code varchar(6), @P_prog_code varchar(6),  @P_actv_code varchar(6),
					@P_locn_code varchar(6), @P_dr_cr_ind varchar(1), @P_line_amt  decimal, @P_doc_total_amt decimal, @P_change_type varchar(1), @P_user_id_in varchar(30),@transfer_activity_key int, @activity_btr_key int --changed by KJC
			SET @intLOOP = 0
		
			DECLARE transfer_activity_cursor CURSOR FOR	SELECT * FROM v_Transfer_Activity_Create_JV WHERE btr_key = @btr_key ORDER BY transfer_activity_key;
--SELECT index_number, index_coas_code, index_fund_code, index_orgn_code, account_number, index_prog_code, index_actv_code, index_locn_code, P_dr_cr_ind, ta.amount, total_amount, change_type, creation_user, transfer_activity_key, ta.btr_key FROM v_Transfer_Activity_Create_JV WHERE btr_key = @btr_key ORDER BY transfer_activity_key;

			OPEN transfer_activity_cursor
PRINT N'>>> Open Cursor';  			
			FETCH NEXT FROM transfer_activity_cursor INTO @P_acci_code,@P_coas_code,@P_fund_code,@P_orgn_code,@P_acct_code,@P_prog_code,@P_actv_code,@P_locn_code,@P_dr_cr_ind,@P_line_amt,@P_doc_total_amt,@P_change_type,@P_user_id_in,@transfer_activity_key,@activity_btr_key --changed by KJC
			
PRINT N'>>> Fetch from Next';  			
			WHILE @@FETCH_STATUS = 0
				BEGIN
					--INITIATE CREATION OF HEADER
					WHILE @intLOOP < 2
						BEGIN
							SET @create_jv_error_message = 'Creating Header! - Loop Number=' + CONVERT(VARCHAR, @intLoop) 
							EXEC [dbo].[mock_create_jv]	@jv_doc_id = @jv_doc_id OUTPUT,	@P_acci_code = @P_acci_code, @P_coas_code = @P_coas_code, @P_fund_code = @P_fund_code, @P_orgn_code = @P_orgn_code,	@P_acct_code = @P_acct_code, @P_prog_code = @P_prog_code, @P_actv_code = @P_actv_code, @P_locn_code = @P_locn_code, @P_dr_cr_ind = @P_dr_cr_ind, @P_line_amt = @P_line_amt, @P_doc_total_amt = @P_doc_total_amt, @P_change_type = @P_change_type, @P_user_id_in = @P_user_id_in, @P_status_ind = @P_status_ind OUTPUT,@P_status_message = @P_status_message OUTPUT
							PRINT N'>>> @P_status_ind  = ' + @P_status_ind   			
							IF @P_status_ind = 'C'
								BEGIN
									UPDATE transfer_activity SET jv_doc_id = @jv_doc_id WHERE transfer_activity_key = @transfer_activity_key
									SET @intLOOP = 2
								END
							ELSE
								BEGIN
									UPDATE transfer_activity SET jv_doc_id = @jv_doc_id, create_jv_error_message = @P_status_message WHERE transfer_activity_key = @transfer_activity_key
								END
							SET @intLOOP = @intLOOP + 1
							
						END--END WHILE
					--START ENTERING DETAIL RECORDS
					IF @P_status_ind = 'C'
						BEGIN
							SET @create_jv_error_message = 'Creating Detail!' 
							EXEC [dbo].[mock_create_jv]	@jv_doc_id = @jv_doc_id OUTPUT,	@P_acci_code = @P_acci_code, @P_coas_code = @P_coas_code, @P_fund_code = @P_fund_code, @P_orgn_code = @P_orgn_code,	@P_acct_code = @P_acct_code, @P_prog_code = @P_prog_code, @P_actv_code = @P_actv_code, @P_locn_code = @P_locn_code, @P_dr_cr_ind = @P_dr_cr_ind, @P_line_amt = @P_line_amt, @P_doc_total_amt = @P_doc_total_amt, @P_change_type = @P_change_type, @P_user_id_in = @P_user_id_in, @P_status_ind = @P_status_ind OUTPUT,@P_status_message = @P_status_message OUTPUT
							IF @P_status_ind = 'C'
								BEGIN
									UPDATE transfer_activity SET jv_doc_id = @jv_doc_id WHERE transfer_activity_key = @transfer_activity_key
								END
							ELSE
								BEGIN
									RETURN @P_status_message
								END
							FETCH NEXT FROM transfer_activity_cursor INTO @P_acci_code,@P_coas_code,@P_fund_code,@P_orgn_code,@P_acct_code,@P_prog_code,@P_actv_code,@P_locn_code,@P_dr_cr_ind,@P_line_amt,@P_doc_total_amt,@P_change_type,@P_user_id_in,@transfer_activity_key,@activity_btr_key
						END
									 
					ELSE
						BEGIN
							RETURN  @P_status_message
						END 
				END--END FETCH WHILE
			--COMPLETE THE JV
			SET @create_jv_error_message = 'Completing JV!' 
			EXEC [mock_complete_jv] @jv_doc_id = @jv_doc_id OUTPUT, @P_user_id_in = @P_user_id_in, @P_status_ind = @P_status_ind OUTPUT, @P_status_message = @P_status_message OUTPUT
			IF @P_status_ind = 'C'
				BEGIN
					UPDATE transfer_activity SET jv_complete = 1, complete_jv_status_message = @P_status_message WHERE btr_key = @btr_key
				END
			ELSE
				BEGIN
					UPDATE transfer_activity SET jv_complete = 0, complete_jv_status_message = @P_status_message WHERE btr_key = @btr_key
				END
			CLOSE transfer_activity_cursor;  
			DEALLOCATE transfer_activity_cursor;
		END
	END TRY
	BEGIN CATCH
		Print ERROR_MESSAGE()
		IF (SELECT CURSOR_STATUS('global','transfer_activity_cursor')) = 1
		BEGIN
			CLOSE transfer_activity_cursor;  
			DEALLOCATE transfer_activity_cursor;
		END
		UPDATE transfer_activity SET create_jv_error_message = @create_jv_error_message + ' - ' + (SELECT ERROR_MESSAGE()) WHERE transfer_activity_key = @transfer_activity_key
	END CATCH

END
