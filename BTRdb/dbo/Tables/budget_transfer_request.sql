CREATE TABLE [dbo].[budget_transfer_request] (
    [btr_key]            INT              IDENTITY (1, 1) NOT NULL,
    [btr_guid]           UNIQUEIDENTIFIER CONSTRAINT [DF_budgetTransferRequest_btrGUID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [budget_type_key]    INT              NOT NULL,
    [life_cycle_key]     INT              CONSTRAINT [DF_budgetTransferRequest_lifeCycleId] DEFAULT ((1)) NOT NULL,
    [internal_state_key] INT              CONSTRAINT [DF_budgetTransferRequest_internalStateId] DEFAULT ((1)) NOT NULL,
    [total_amount]       MONEY            CONSTRAINT [DF_budgetTransferRequest_totalAmount] DEFAULT ((0)) NOT NULL,
    [explanation]        VARCHAR (300)    NULL,
    [priority_flag]      BIT              CONSTRAINT [DF_budgetTransferRequest_priorityFlag] DEFAULT ((0)) NOT NULL,
    [requestor_uni_key]  INT              NOT NULL,
    [transfer_type_key]  INT              NULL,
    [title]              VARCHAR (200)    NULL,
    [modified]           DATETIME         CONSTRAINT [budget_transfer_request_modified] DEFAULT (getdate()) NOT NULL,
    [created]            DATETIME         CONSTRAINT [budget_transfer_request_created] DEFAULT (getdate()) NOT NULL,
    [modified_by]        INT              NOT NULL,
    [created_by]         INT              NOT NULL,
    CONSTRAINT [PK_budgetTransferRequest] PRIMARY KEY CLUSTERED ([btr_key] ASC),
    CONSTRAINT [FK_btr_budget_type] FOREIGN KEY ([budget_type_key]) REFERENCES [dbo].[xref_budget_type] ([budget_type_key]),
    CONSTRAINT [FK_btr_internal_key] FOREIGN KEY ([internal_state_key]) REFERENCES [dbo].[xref_internal_state] ([internal_state_key]),
    CONSTRAINT [FK_btr_life_cycle] FOREIGN KEY ([life_cycle_key]) REFERENCES [dbo].[xref_life_cycle] ([life_cycle_key]),
    CONSTRAINT [FK_btr_uni_key] FOREIGN KEY ([requestor_uni_key]) REFERENCES [dbo].[users] ([uni_key])
);

