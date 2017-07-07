CREATE TABLE [dbo].[xref_position_type] (
    [type_key]         INT           IDENTITY (1, 1) NOT NULL,
    [type_code]        VARCHAR (10)  NULL,
    [type_description] VARCHAR (100) NULL,
    CONSTRAINT [PK_type] PRIMARY KEY CLUSTERED ([type_key] ASC)
);

