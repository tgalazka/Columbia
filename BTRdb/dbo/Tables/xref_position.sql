CREATE TABLE [dbo].[xref_position] (
    [position_key] INT           IDENTITY (1, 1) NOT NULL,
    [position]     VARCHAR (150) NOT NULL,
    CONSTRAINT [PK_positions] PRIMARY KEY CLUSTERED ([position_key] ASC)
);

