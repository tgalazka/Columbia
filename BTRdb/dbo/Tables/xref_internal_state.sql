CREATE TABLE [dbo].[xref_internal_state] (
    [internal_state_key] INT          NOT NULL,
    [internal_state]     VARCHAR (50) NULL,
    CONSTRAINT [PK_xref_internalstate] PRIMARY KEY CLUSTERED ([internal_state_key] ASC)
);

