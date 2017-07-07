CREATE TABLE [dbo].[transfer_activity] (
    [transfer_activity_key]      INT              IDENTITY (1, 1) NOT NULL,
    [btr_key]                    INT              NOT NULL,
    [position_type_key]          INT              NOT NULL,
    [activity_btr_guid]          UNIQUEIDENTIFIER NULL,
    [activity_item_guid]         UNIQUEIDENTIFIER CONSTRAINT [DF_transfer_activity_item_guid] DEFAULT (newid()) NULL,
    [activity_number]            INT              CONSTRAINT [DF_transfer_activity_activity_number] DEFAULT ((1)) NOT NULL,
    [line_number]                INT              CONSTRAINT [DF_transfer_activity_line_number] DEFAULT ((1)) NOT NULL,
    [index_key]                  INT              NOT NULL,
    [account_key]                INT              NOT NULL,
    [explanation]                TEXT             NULL,
    [amount]                     DECIMAL (20, 2)  NOT NULL,
    [created_by]                 INT              NOT NULL,
    [created]                    DATETIME         CONSTRAINT [DF_transfer_activity_created] DEFAULT (getdate()) NOT NULL,
    [modified_by]                INT              NOT NULL,
    [modified]                   DATETIME         CONSTRAINT [DF_transfer_activity_modified] DEFAULT (getdate()) NULL,
    [jv_doc_id]                  VARCHAR (8)      NULL,
    [jv_complete]                BIT              NULL,
    [create_jv_error_message]    VARCHAR (MAX)    NULL,
    [complete_jv_status_message] VARCHAR (MAX)    NULL,
    [type_key]                   INT              NULL,
    [status_key]                 INT              NULL,
    [approval_status_key]        INT              CONSTRAINT [DF_transfer_activity_approval_status_key] DEFAULT ((0)) NULL,
    [approval_level]             INT              NULL,
    CONSTRAINT [PK_transfer_activity_1] PRIMARY KEY CLUSTERED ([transfer_activity_key] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_transfer_activity_btr_key]
    ON [dbo].[transfer_activity]([btr_key] ASC);

