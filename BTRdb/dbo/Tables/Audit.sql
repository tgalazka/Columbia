CREATE TABLE [dbo].[Audit] (
    [audit_key]           INT           IDENTITY (1, 1) NOT NULL,
    [audit_data]          VARCHAR (500) NOT NULL,
    [audit_action]        VARCHAR (50)  NOT NULL,
    [audit_user_uni_code] VARCHAR (50)  NULL,
    [audit_user_uni_key]  INT           NOT NULL,
    [audit_data_element]  VARCHAR (50)  NOT NULL
);

