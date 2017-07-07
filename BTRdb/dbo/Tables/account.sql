CREATE TABLE [dbo].[account] (
    [account_key]                INT             IDENTITY (1, 1) NOT NULL,
    [index_key]                  INT             NOT NULL,
    [account_number]             VARCHAR (6)     NULL,
    [account_description]        VARCHAR (100)   NULL,
    [account_number_description] VARCHAR (110)   NULL,
    [account_balance]            DECIMAL (17, 2) NULL,
    CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED ([account_key] ASC),
    CONSTRAINT [FK_account_index] FOREIGN KEY ([index_key]) REFERENCES [dbo].[index] ([index_key])
);

