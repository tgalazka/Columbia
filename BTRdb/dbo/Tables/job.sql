CREATE TABLE [dbo].[job] (
    [job_key]         INT           IDENTITY (1, 1) NOT NULL,
    [account_key]     INT           NULL,
    [job_number]      VARCHAR (6)   NULL,
    [job_description] VARCHAR (100) NULL,
    CONSTRAINT [PK_job] PRIMARY KEY CLUSTERED ([job_key] ASC)
);

