-- =============================================
-- Author:		Sebastián Rojas Vargas
-- Create date: 1/19/26
-- Description:	Editar Vehiculo
-- =============================================
CREATE PROCEDURE EditarVehiculo
	-- Add the parameters for the stored procedure here
	@Id As uniqueidentifier
    ,@IdModelo As uniqueidentifier
    ,@Placa AS varchar(MAX)
    ,@Color AS varchar(MAX)
    ,@Anio AS int
    ,@Precio AS decimal(18,0)
    ,@CorreoPropietario AS varchar(MAX)
    ,@TelefonoPropietario AS varchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    BEGIN TRANSACTION
        UPDATE [dbo].[Vehiculo]
       SET [IdModelo] = @IdModelo
          ,[Placa] = @Placa
          ,[Color] = @Color
          ,[Anio] = @Anio
          ,[Precio] = @Precio
          ,[CorreoPropietario] = @CorreoPropietario
          ,[TelefonoPropietario] = @TelefonoPropietario
         WHERE Id = @Id
         SELECT @Id
     COMMIT TRANSACTION
END