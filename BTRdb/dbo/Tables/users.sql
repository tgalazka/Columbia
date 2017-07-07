CREATE TABLE [dbo].[users] (
    [uni_key]        INT          NOT NULL,
    [uni_name]       VARCHAR (80) NOT NULL,
    [uni_first_name] VARCHAR (30) NOT NULL,
    [uni_last_name]  VARCHAR (50) NOT NULL,
    [uni_email]      VARCHAR (90) NOT NULL,
    [uni_code]       VARCHAR (20) NULL,
    CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED ([uni_key] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_users_code]
    ON [dbo].[users]([uni_code] ASC);

