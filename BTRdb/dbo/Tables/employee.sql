CREATE TABLE [dbo].[employee] (
    [employee_key]    INT           IDENTITY (1, 1) NOT NULL,
    [job_key]         INT           NOT NULL,
    [employee_fname]  VARCHAR (30)  NULL,
    [employee_lname]  VARCHAR (50)  NULL,
    [employee_mi]     VARCHAR (4)   NULL,
    [employee_prefix] VARCHAR (4)   NULL,
    [employee_suffix] VARCHAR (5)   NULL,
    [employee_name]   VARCHAR (120) NULL,
    [employee_uni]    VARCHAR (20)  NULL,
    CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED ([employee_key] ASC)
);

