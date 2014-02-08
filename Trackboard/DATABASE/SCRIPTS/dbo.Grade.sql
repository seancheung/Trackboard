CREATE TABLE [dbo].[Grade] (
    [SID]   VARCHAR (10) NOT NULL,
    [CoID]  VARCHAR (10) NOT NULL,
    [GMark] INT          NULL,
    PRIMARY KEY CLUSTERED ([CoID] ASC, [SID] ASC)
);

