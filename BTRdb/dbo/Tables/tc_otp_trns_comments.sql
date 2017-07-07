CREATE TABLE [dbo].[tc_otp_trns_comments] (
    [otp_trns_comments_key_id]   INT            IDENTITY (1, 1) NOT NULL,
    [otp_trns_key_id]            INT            NULL,
    [otp_trns_comments]          VARCHAR (4000) NULL,
    [otp_trns_commentor]         VARCHAR (10)   NULL,
    [otp_trns_comments_datetime] DATETIME       NULL,
    CONSTRAINT [PK_tc_otp_trns_comments] PRIMARY KEY CLUSTERED ([otp_trns_comments_key_id] ASC),
    CONSTRAINT [FK_tc_otp_trns_comments_tc_otp_trns] FOREIGN KEY ([otp_trns_key_id]) REFERENCES [dbo].[tc_otp_trns] ([otp_trns_key_id])
);

