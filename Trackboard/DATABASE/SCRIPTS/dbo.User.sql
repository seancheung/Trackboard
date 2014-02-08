CREATE TABLE [dbo].[User] (
    [UID]   VARCHAR (10) NOT NULL,
    [UPwd]  VARCHAR (20) NOT NULL,
    [UAuth] INT          NULL,
    PRIMARY KEY CLUSTERED ([UID] ASC)
);

