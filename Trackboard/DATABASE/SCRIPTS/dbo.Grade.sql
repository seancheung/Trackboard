CREATE TABLE [dbo].[Grade] (
    [ID]    INT          IDENTITY (1, 1) NOT NULL,
    [SID]   VARCHAR (10) NOT NULL,
    [CoID]  VARCHAR (10) NOT NULL,
    [GMark] INT          NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    UNIQUE NONCLUSTERED ([CoID] ASC, [SID] ASC)
);

