CREATE TABLE [dbo].[xref_job_change_reason] (
    [job_change_reason_key] INT           IDENTITY (1, 1) NOT NULL,
    [job_change_reason]     VARCHAR (250) NOT NULL,
    CONSTRAINT [PK_xref_job_change_reason] PRIMARY KEY CLUSTERED ([job_change_reason_key] ASC)
);

