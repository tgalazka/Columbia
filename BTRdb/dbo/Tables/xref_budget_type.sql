CREATE TABLE [dbo].[xref_budget_type] (
    [budget_type_key] INT          NOT NULL,
    [budget_type]     VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_xref_budgettype] PRIMARY KEY CLUSTERED ([budget_type_key] ASC)
);

