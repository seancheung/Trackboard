CREATE TABLE [dbo].[Student] (
    [ID]      INT          IDENTITY (1, 1) NOT NULL,
    [SID]     VARCHAR (10) NOT NULL,
    [SName]   NVARCHAR (8) NOT NULL,
    [SGender] BIT          NOT NULL,
    [SBirth]  DATE         NULL,
    [CID]     VARCHAR (10) NOT NULL,
    [SPhone]  VARCHAR (11) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    UNIQUE NONCLUSTERED ([SID] ASC)
);

