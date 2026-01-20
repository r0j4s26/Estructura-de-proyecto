-- =============================================
-- Author:		Sebastián Rojas Vargas
-- Create date: 1/19/26
-- Description:	Eliminar Vehiculo
-- =============================================
CREATE PROCEDURE EliminarVehiculo
	-- Add the parameters for the stored procedure here
	@Id uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE 
	FROM     Vehiculo
	WHERE  (Id = @Id)
END