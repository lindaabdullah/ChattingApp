CREATE TABLE [dbo].[LoginLog] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (50) NOT NULL,
    [Time]     DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);