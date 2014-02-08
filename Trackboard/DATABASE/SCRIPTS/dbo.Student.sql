CREATE TABLE [dbo].[Student] (
    [SID]     VARCHAR (10) NOT NULL,
    [SName]   NVARCHAR (8) NOT NULL,
    [SGender] BIT          NOT NULL,
    [SBirth]  DATE         NULL,
    [CID]     VARCHAR (10) NOT NULL,
    [SPhone]  VARCHAR (11) NULL,
    PRIMARY KEY CLUSTERED ([SID] ASC)
);

