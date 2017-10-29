CREATE TABLE [dbo].[Laureado] (
    [LaureadoId]   INT      NOT NULL,
    [LaureadoTipo] CHAR (1) NOT NULL,
    CONSTRAINT [PK_Laureado] PRIMARY KEY CLUSTERED ([LaureadoId] ASC),
    CONSTRAINT [CK_Laureado] CHECK ([LaureadoTipo]='O' OR [LaureadoTipo]='I')
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Laureado é Individuo ou Organização', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Laureado', @level2type = N'CONSTRAINT', @level2name = N'CK_Laureado';

