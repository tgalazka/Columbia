CREATE TABLE [dbo].[responsibility_matrix] (
    [responsibility_matrix_key] INT           IDENTITY (1, 1) NOT NULL,
    [index_key]                 INT           NOT NULL,
    [name]                      VARCHAR (100) NULL,
    [uni]                       VARCHAR (20)  NULL,
    CONSTRAINT [PK_responsibility_matrix] PRIMARY KEY CLUSTERED ([responsibility_matrix_key] ASC),
    CONSTRAINT [FK_responsibility_matrix_index] FOREIGN KEY ([index_key]) REFERENCES [dbo].[index] ([index_key])
);

