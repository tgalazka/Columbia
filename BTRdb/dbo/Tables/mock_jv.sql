CREATE TABLE [dbo].[mock_jv] (
    [jv_key]        INT          IDENTITY (1, 1) NOT NULL,
    [created]       DATETIME     CONSTRAINT [DF_mock_jv_created] DEFAULT (getdate()) NOT NULL,
    [btr_key_value] VARCHAR (10) NULL
);

