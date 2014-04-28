CREATE TABLE [dbo].[Job] (
    [SID]     VARCHAR(10)           NOT NULL,
    [Company] NVARCHAR (50) NULL,
    [Salary]  INT           NULL,
    [City]    NVARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([SID] ASC)
);

