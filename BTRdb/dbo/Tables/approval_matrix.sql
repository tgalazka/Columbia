CREATE TABLE [dbo].[approval_matrix] (
    [approval_matrix_key] INT             IDENTITY (1, 1) NOT NULL,
    [index_key]           INT             NOT NULL,
    [role_title]          VARCHAR (25)    NULL,
    [role_level]          INT             NOT NULL,
    [approval_limit]      DECIMAL (18, 2) NOT NULL,
    [next_approval_level] INT             NOT NULL,
    [uni_key]             INT             NOT NULL,
    CONSTRAINT [PK_approval_matrix] PRIMARY KEY CLUSTERED ([approval_matrix_key] ASC),
    CONSTRAINT [FK_approval_matrix_index] FOREIGN KEY ([index_key]) REFERENCES [dbo].[index] ([index_key])
);

