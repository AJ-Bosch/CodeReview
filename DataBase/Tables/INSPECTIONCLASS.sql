﻿CREATE TABLE [dbo].[INSPECTIONCLASS]
(
	[CLASSID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CLASSNAME] VARCHAR(50) NULL, 
    [DESCRIPTION] VARCHAR(MAX) NULL,
    [ISDELETED] BIT NOT NULL DEFAULT 0,  -- Soft delete flag
)
