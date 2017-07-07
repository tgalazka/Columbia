-- =============================================
-- Author:		Kenneth Cooper
-- Create date: 6/20/2017
-- Description:	Return one record from the OTP table and xref tables
-- =============================================
CREATE PROCEDURE [one_time_payment_read_record]
	-- Add the parameters for the stored procedure here
	@one_time_payment_key int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT otp.[employee_key]
	  ,employee_name
      ,otp.[current_position_key]
	  ,p.[position] as [current_position]
      ,otp.[position_key]
	  ,p2.[position] as [position]
      ,otp.[suffix]
      ,otp.[job_status]
      ,otp.[effective_date]
	  ,otp.[job_change_reason_key]
      ,job.[job_change_reason]
      ,otp.[job_change_reason_other]
      ,otp.[personnel_date]
      ,otp.[salary]
      ,otp.[rate]
      ,otp.[hours_per_pay_period]
      ,otp.[factor]
      ,otp.[index_key]
      ,otp.[account_key]
      ,otp.[fund]
      ,otp.[percent]
      ,otp.[created]
      ,otp.[created_by]
      ,otp.[modified]
      ,otp.[modified_by]
      ,otp.[comment]
      ,otp.[supervisor_name]
      ,otp.[payroll_key]
      ,otp.[dept_key]
	  ,d.[department_number]
	  ,d.[department_description]
      ,otp.[approval_status_key]
  FROM [dbo].[one_time_payment] otp 
  left join employee e on (otp.employee_key = e.employee_key)
  left join xref_position p on (otp.current_position_key = p.position_key)
  left join xref_position p2 on (otp.position_key = p2.position_key)
  left join xref_job_change_reason job on (otp.job_change_reason_key = job.job_change_reason_key)
  left join department d on (otp.dept_key = d.[department_key])
	Where otp.one_time_payment_key = @one_time_payment_key
END
