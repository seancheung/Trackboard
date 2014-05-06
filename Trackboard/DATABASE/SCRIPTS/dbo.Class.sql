﻿CREATE TABLE [dbo].[Class] (
    [ID]    INT           IDENTITY (1, 1) NOT NULL,
    [CID]   VARCHAR (10)  NOT NULL,
    [CName] NVARCHAR (10) NOT NULL,
    [TID]   NCHAR (10)    NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    UNIQUE NONCLUSTERED ([CID] ASC)
);

