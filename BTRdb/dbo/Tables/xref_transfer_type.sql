CREATE TABLE [dbo].[xref_transfer_type] (
    [transfer_type_key] INT          NOT NULL,
    [transfer_type]     VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_transfer_type] PRIMARY KEY CLUSTERED ([transfer_type_key] ASC)
);

