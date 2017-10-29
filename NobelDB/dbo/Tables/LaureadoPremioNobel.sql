CREATE TABLE [dbo].[LaureadoPremioNobel] (
    [LaureadoId]    INT NOT NULL,
    [PremioNobelId] INT NOT NULL,
    CONSTRAINT [PK_LaureadoPremioNobel] PRIMARY KEY CLUSTERED ([LaureadoId] ASC, [PremioNobelId] ASC),
    CONSTRAINT [FK_LaureadoPremioNobel_Laureado] FOREIGN KEY ([LaureadoId]) REFERENCES [dbo].[Laureado] ([LaureadoId]),
    CONSTRAINT [FK_LaureadoPremioNobel_PremioNobel] FOREIGN KEY ([PremioNobelId]) REFERENCES [dbo].[PremioNobel] ([PremioNobelId])
);

