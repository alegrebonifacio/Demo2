CREATE TABLE [dbo].[LaureadoIndividuoFiliacao] (
    [LaureadoId] INT NOT NULL,
    [FiliacaoId] INT NOT NULL,
    CONSTRAINT [PK_LaureadoIndividuoFiliacao] PRIMARY KEY CLUSTERED ([LaureadoId] ASC, [FiliacaoId] ASC),
    CONSTRAINT [FK_LaureadoIndividuoFiliacao_Filiacao] FOREIGN KEY ([FiliacaoId]) REFERENCES [dbo].[Filiacao] ([FiliacaoId]),
    CONSTRAINT [FK_LaureadoIndividuoFiliacao_LaureadoIndividuo] FOREIGN KEY ([LaureadoId]) REFERENCES [dbo].[LaureadoIndividuo] ([LaureadoId])
);

