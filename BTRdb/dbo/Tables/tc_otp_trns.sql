CREATE TABLE [dbo].[tc_otp_trns] (
    [otp_trns_key_id]             INT           IDENTITY (1, 1) NOT NULL,
    [employee_key_id]             INT           NULL,
    [otp_trns_reason]             VARCHAR (200) NULL,
    [otp_trns_effective_date]     DATETIME      NULL,
    [otp_trns_submitter]          VARCHAR (10)  NULL,
    [otp_trns_processed]          BIT           NULL,
    [otp_trns_processed_datatime] DATETIME      NULL,
    CONSTRAINT [PK_tc_otp_trns] PRIMARY KEY CLUSTERED ([otp_trns_key_id] ASC),
    CONSTRAINT [FK_tc_otp_trns_tc_employee] FOREIGN KEY ([employee_key_id]) REFERENCES [dbo].[tc_employee] ([employee_key_id])
);

