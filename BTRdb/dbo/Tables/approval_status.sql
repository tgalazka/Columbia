CREATE TABLE [dbo].[approval_status] (
    [approval_status_key]         INT          IDENTITY (1, 1) NOT NULL,
    [approval_status_code]        VARCHAR (5)  NULL,
    [approval_status_description] VARCHAR (20) NULL,
    CONSTRAINT [PK_approval_status] PRIMARY KEY CLUSTERED ([approval_status_key] ASC)
);

