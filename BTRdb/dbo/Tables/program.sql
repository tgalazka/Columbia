CREATE TABLE [dbo].[program] (
    [program_key]         INT          IDENTITY (1, 1) NOT NULL,
    [program_number]      VARCHAR (5)  NOT NULL,
    [program_description] VARCHAR (50) NULL,
    CONSTRAINT [PK_program] PRIMARY KEY CLUSTERED ([program_key] ASC)
);

