CREATE TABLE [dbo].[Employee] (
    [SSN]      INT           NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Surname]  NVARCHAR (50) NOT NULL,
    [Username] NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [Email]    NVARCHAR (50) NOT NULL,
    [Address]  NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([SSN] ASC)
);

