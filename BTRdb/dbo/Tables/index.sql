CREATE TABLE [dbo].[index] (
    [index_key]                INT          IDENTITY (1, 1) NOT NULL,
    [index_coas_code]          VARCHAR (1)  NULL,
    [index_fund_code]          VARCHAR (6)  NULL,
    [index_orgn_code]          VARCHAR (6)  NULL,
    [index_prog_code]          VARCHAR (6)  NULL,
    [index_acct_code]          VARCHAR (6)  NULL,
    [index_actv_code]          VARCHAR (6)  NULL,
    [index_locn_code]          VARCHAR (6)  NULL,
    [index_number]             VARCHAR (6)  NULL,
    [index_description]        VARCHAR (35) NULL,
    [index_number_description] VARCHAR (45) NULL,
    [index_status]             VARCHAR (3)  NULL,
    CONSTRAINT [PK_index] PRIMARY KEY CLUSTERED ([index_key] ASC)
);

