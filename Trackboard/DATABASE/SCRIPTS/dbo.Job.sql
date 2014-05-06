CREATE TABLE [dbo].[Job] (
    [ID]      INT           IDENTITY (1, 1) NOT NULL,
    [SID]     VARCHAR (10)  NOT NULL,
    [Company] NVARCHAR (50) NULL,
    [Salary]  INT           NULL,
    [City]    NVARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    UNIQUE NONCLUSTERED ([SID] ASC)
);

