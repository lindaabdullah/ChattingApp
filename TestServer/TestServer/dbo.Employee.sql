﻿CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(50) NOT NULL,
	[Username] NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(50) NOT NULL
)
