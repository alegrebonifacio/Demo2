-- =============================================
-- Author:		Cláudio Teixeira
-- Create date: 2017/10/28
-- Description:	Dado o id de um pais, devolve o paisId atual
-- =============================================
CREATE FUNCTION PaisAtual 
(
	-- Add the parameters for the function here
	@PaisId int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	declare @paisAtualId int


	--select @paisAtualId = pais.PaisAtualId from pais where PaisId = @PaisId

	if @paisAtualId is not null
		return @paisAtualId

	-- Return the result of the function
	RETURN @paisId

END
