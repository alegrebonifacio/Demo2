CREATE TABLE [dbo].[LaureadoOrganizacao] (
    [LaureadoId] INT           NOT NULL,
    [Nome]       VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_LaureadoOrganizacao_1] PRIMARY KEY CLUSTERED ([LaureadoId] ASC),
    CONSTRAINT [FK_LaureadoOrganizacao_Laureado] FOREIGN KEY ([LaureadoId]) REFERENCES [dbo].[Laureado] ([LaureadoId])
);

