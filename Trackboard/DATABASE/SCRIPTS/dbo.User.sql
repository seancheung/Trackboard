CREATE TABLE [dbo].[User] (
    [ID]    INT          IDENTITY (1, 1) NOT NULL,
    [UID]   VARCHAR (10) NOT NULL,
    [UPwd]  VARCHAR (20) NOT NULL,
    [UAuth] INT          NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    UNIQUE NONCLUSTERED ([UID] ASC)
);

