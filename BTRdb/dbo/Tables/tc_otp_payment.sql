CREATE TABLE [dbo].[tc_otp_payment] (
    [otp_trns_payment_key_id]         INT             NOT NULL,
    [otp_trns_key_id]                 INT             IDENTITY (1, 1) NOT NULL,
    [otp_trns_payment_index_number]   VARCHAR (6)     NULL,
    [otp_trns_payment_account_number] VARCHAR (6)     NULL,
    [otp_trns_payment_percentage]     INT             NULL,
    [otp_trns_payment_amount]         DECIMAL (20, 2) NULL,
    CONSTRAINT [PK_tc_otp_payment] PRIMARY KEY CLUSTERED ([otp_trns_payment_key_id] ASC),
    CONSTRAINT [FK_tc_otp_payment_tc_otp_trns] FOREIGN KEY ([otp_trns_key_id]) REFERENCES [dbo].[tc_otp_trns] ([otp_trns_key_id])
);

