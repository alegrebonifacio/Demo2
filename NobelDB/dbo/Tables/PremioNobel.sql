CREATE TABLE [dbo].[PremioNobel] (
    [PremioNobelId] INT           IDENTITY (1, 1) NOT NULL,
    [Ano]           INT           NOT NULL,
    [CategoriaId]   INT           NOT NULL,
    [Titulo]        VARCHAR (200) NOT NULL,
    [Motivacao]     VARCHAR (MAX) NULL,
    CONSTRAINT [PK_PremioNobel] PRIMARY KEY CLUSTERED ([PremioNobelId] ASC),
    CONSTRAINT [FK_PremioNobel_Categoria] FOREIGN KEY ([CategoriaId]) REFERENCES [dbo].[Categoria] ([CategoriaId])
);

