CREATE TABLE [dbo].[Categoria] (
    [CategoriaId] INT           IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED ([CategoriaId] ASC)
);

