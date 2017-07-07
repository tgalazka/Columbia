CREATE TABLE [dbo].[department] (
    [department_key]         INT          IDENTITY (1, 1) NOT NULL,
    [department_number]      VARCHAR (3)  NULL,
    [department_description] VARCHAR (50) NULL,
    CONSTRAINT [PK_department] PRIMARY KEY CLUSTERED ([department_key] ASC)
);

