CREATE TABLE [dbo].[Filiacao] (
    [FiliacaoId] INT           IDENTITY (1, 1) NOT NULL,
    [Nome]       VARCHAR (200) NOT NULL,
    [CidadeId]   INT           NOT NULL,
    CONSTRAINT [PK_Filiacao] PRIMARY KEY CLUSTERED ([FiliacaoId] ASC),
    CONSTRAINT [FK_Filiacao_Cidade] FOREIGN KEY ([CidadeId]) REFERENCES [dbo].[Cidade] ([CidadeId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Filiacao]
    ON [dbo].[Filiacao]([Nome] ASC);

