CREATE TABLE [dbo].[status] (
    [status_key]         INT          IDENTITY (1, 1) NOT NULL,
    [status_code]        VARCHAR (5)  NULL,
    [status_description] VARCHAR (20) NULL,
    CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED ([status_key] ASC)
);

