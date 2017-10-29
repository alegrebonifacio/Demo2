CREATE TABLE [dbo].[LaureadoIndividuo] (
    [LaureadoId]         INT           NOT NULL,
    [Nome]               VARCHAR (100) NOT NULL,
    [DataNascimento]     DATE          NOT NULL,
    [DataMorte]          DATE          NULL,
    [CidadeNascimentoId] INT           NOT NULL,
    [CidadeMorteId]      INT           NULL,
    [Sexo]               CHAR (1)      NOT NULL,
    CONSTRAINT [PK_Individuo] PRIMARY KEY CLUSTERED ([LaureadoId] ASC),
    CONSTRAINT [FK_Individuo_Cidade] FOREIGN KEY ([CidadeNascimentoId]) REFERENCES [dbo].[Cidade] ([CidadeId]),
    CONSTRAINT [FK_Individuo_Cidade1] FOREIGN KEY ([CidadeMorteId]) REFERENCES [dbo].[Cidade] ([CidadeId]),
    CONSTRAINT [FK_Individuo_Laureado] FOREIGN KEY ([LaureadoId]) REFERENCES [dbo].[Laureado] ([LaureadoId])
);

