-- =============================================
-- Author:		Cláudio Teixeira
-- Create date: 28/10/2017
-- Description:	Devolve a contagem de Pessoas Laureados Nobel, agrupados por pais atual (de nascimento)
--				Devolve a contagem de laureados e não a contagem de prémios atribuídos
-- =============================================
CREATE PROCEDURE LaureadosPorPaisAtual
	-- Add the parameters for the stored procedure here
	@paisId int = 0
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	
	select sum(x.partialSum) as [count], x.nome
	 from
	 (	
		select count(LaureadoIndividuo.LaureadoId) as partialSum, pais.Nome from LaureadoIndividuo
		inner join cidade on Cidade.CidadeId = LaureadoIndividuo.CidadeNascimentoId
		inner join pais on pais.PaisId = cidade.PaisId
		where pais.PaisAtualId is null and (@paisId = 0 or pais.PaisId = @paisId)
		group by pais.Nome
		union all
		select count(LaureadoIndividuo.LaureadoId) as partialSum, paisAtual.Nome from LaureadoIndividuo
		inner join cidade on Cidade.CidadeId = LaureadoIndividuo.CidadeNascimentoId
		inner join pais on pais.PaisId = cidade.PaisId
		inner join pais as paisAtual on pais.PaisAtualId = paisAtual.PaisId
		where  (@paisId = 0 or paisAtual.PaisId = @paisId)
		group by paisAtual.Nome
		) x
	group by x.Nome
	order by [count] desc

END
