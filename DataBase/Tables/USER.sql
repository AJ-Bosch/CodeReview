﻿CREATE TABLE [dbo].[USER]
(
	[USERID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [USERNAME] VARCHAR(50) NULL, 
    [PASSWORDHASH] VARCHAR(255) NULL, 
    [EMAIL] VARCHAR(50) NULL, 
    [ROLEID] INT NULL, 
    [COMPANYCODE] INT NULL, 
    [LASTUPDATE] DATETIME NULL,
    [ISDELETED] BIT NOT NULL DEFAULT 0,  -- Soft delete flag
    FOREIGN KEY ([ROLEID]) REFERENCES [dbo].[ROLE]([ROLEID]),
    FOREIGN KEY ([COMPANYCODE]) REFERENCES [dbo].[COMPANY]([COMPANYID])
)
