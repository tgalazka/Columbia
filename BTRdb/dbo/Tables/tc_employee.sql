CREATE TABLE [dbo].[tc_employee] (
    [employee_key_id] INT          IDENTITY (1, 1) NOT NULL,
    [employee_uni]    VARCHAR (10) NULL,
    CONSTRAINT [PK_tc_employee] PRIMARY KEY CLUSTERED ([employee_key_id] ASC)
);

