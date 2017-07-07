CREATE TABLE [dbo].[transfer_activity_reviewers] (
    [approval_key]          INT              IDENTITY (1, 1) NOT NULL,
    [btr_key]               INT              NOT NULL,
    [transfer_activity_key] INT              NOT NULL,
    [approval_matrix_key]   INT              NOT NULL,
    [index_key]             INT              NOT NULL,
    [account_key]           INT              NOT NULL,
    [approver_uni_key]      INT              NOT NULL,
    [role_level]            INT              NOT NULL,
    [status_key]            INT              NOT NULL,
    [created]               DATETIME         CONSTRAINT [DF_transfer_activity_reviews_created] DEFAULT (getdate()) NOT NULL,
    [modified]              DATETIME         CONSTRAINT [DF_transfer_activity_reviews_modified] DEFAULT (getdate()) NOT NULL,
    [workflow_guid]         UNIQUEIDENTIFIER NOT NULL
);

