CREATE TABLE [dbo].[Tutorials] (
    [TutorialID]        INT           IDENTITY (1, 1) NOT NULL,
    [CategoryID]        INT           NOT NULL,
    [DateCreated]       DATETIME      NOT NULL,
    [TypeID]            INT           NOT NULL,
    [TutorialTitle]     VARCHAR (100) NOT NULL,
    [TutorialLink]      VARCHAR (250) NULL,
    [TutorialThumbnail] VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([TutorialID] ASC),
    CONSTRAINT [FK_Tutorials_Type] FOREIGN KEY ([TypeID]) REFERENCES [dbo].[Type] ([TypeID]),
    CONSTRAINT [FK_Tutorials_Categories] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([CategoryID])
);

