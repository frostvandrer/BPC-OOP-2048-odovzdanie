CREATE TABLE [dbo].[Player] (
    [Id]          INT           NOT NULL,
    [PlayerName]  VARCHAR (255) NULL,
    [PlayerScore] INT           NULL,
    [PlayerMoves] INT           NULL,
	[GameBoard]   VARCHAR(1000) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
