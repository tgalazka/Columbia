CREATE TABLE [dbo].[xref_approval_status] (
    [approval_status_key] INT          NOT NULL,
    [approval_status]     VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_xref_approval_status] PRIMARY KEY CLUSTERED ([approval_status_key] ASC)
);

