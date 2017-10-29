CREATE TABLE [dbo].[Cidade] (
    [CidadeId]      INT           IDENTITY (1, 1) NOT NULL,
    [Nome]          VARCHAR (100) NOT NULL,
    [PaisId]        INT           NOT NULL,
    [CidadeAtualId] INT           NULL,
    CONSTRAINT [PK_Cidade] PRIMARY KEY CLUSTERED ([CidadeId] ASC),
    CONSTRAINT [FK_Cidade_Cidade] FOREIGN KEY ([CidadeAtualId]) REFERENCES [dbo].[Cidade] ([CidadeId]),
    CONSTRAINT [FK_Cidade_Pais] FOREIGN KEY ([PaisId]) REFERENCES [dbo].[Pais] ([PaisId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Cidade]
    ON [dbo].[Cidade]([Nome] ASC, [PaisId] ASC);

