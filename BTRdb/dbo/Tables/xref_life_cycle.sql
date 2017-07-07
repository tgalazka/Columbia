CREATE TABLE [dbo].[xref_life_cycle] (
    [life_cycle_key] INT          NOT NULL,
    [life_cycle]     VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_xref_lifecycle] PRIMARY KEY CLUSTERED ([life_cycle_key] ASC)
);

