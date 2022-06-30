CREATE TABLE [dbo].[Chatting] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [SenderUsername]   NVARCHAR (100) NOT NULL,
    [RecieverUsername] NVARCHAR (100) NOT NULL,
    [DateSent]         NVARCHAR (100) NOT NULL,
    [Message]          NVARCHAR (100) NOT NULL,
    [ChattingType]     NVARCHAR (100) NOT NULL,
    [Encrypted]        NCHAR (10)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [chk_ChattingType] CHECK ([ChattingType]='Broadcast' OR [ChattingType]='Private')
);

