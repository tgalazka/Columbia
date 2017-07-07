-- =============================================
-- Author:		Kenneth Cooper
-- Create date: 6/20/2017
-- Description:	Creates one time payment entries
-- =============================================
CREATE PROCEDURE [one_time_payment_create_record]
	-- Add the parameters for the stored procedure here
	@employee_key int, 
    @current_position_key int,
    @position_key int,
	@suffix varchar(20),
    @job_status varchar(50),
	@effective_date datetime,
	@job_change_reason_key int,
	@job_change_reason varchar(250),
    @personnel_date datetime,
    @salary money,
    @rate int,
    @hours_per_pay_period int,
    @factor int,
    @index_key int,
    @account_key int,
    @fund varchar(50),
    @percent numeric(18,0),
    @created_by int,
    @modified_by int,
    @comment varchar(255),
    @supervisor_name varchar(80),
    @payroll_key int,
    @dept_key int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO [dbo].[one_time_payment]
           ([employee_key]
           ,[current_position_key]
           ,[position_key]
           ,[suffix]
           ,[job_status]
           ,[effective_date]
           ,[job_change_reason]
           ,[personnel_date]
           ,[salary]
           ,[rate]
           ,[hours_per_pay_period]
           ,[factor]
           ,[index_key]
           ,[account_key]
           ,[fund]
           ,[percent]
           ,[created_by]
           ,[modified_by]
           ,[comment]
           ,[supervisor_name]
           ,[job_change_reason_key]
           ,[payroll_key]
           ,[dept_key])
     VALUES
           (@employee_key
           ,@current_position_key
           ,@position_key
           ,@suffix
           ,@job_status
           ,@effective_date
           ,@job_change_reason
           ,@personnel_date
           ,@salary 
           ,@rate
           ,@hours_per_pay_period
           ,@factor
           ,@index_key
           ,@account_key
           ,@fund 
           ,@percent
           ,@created_by
           ,@modified_by
           ,@comment
           ,@supervisor_name
           ,@job_change_reason_key
           ,@payroll_key
           ,@dept_key)
END
