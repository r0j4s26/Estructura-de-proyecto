-- =============================================
-- Author:		Sebastián Rojas Vargas
-- Create date: 1/19/26
-- Description:	Agregar Vehiculo
-- =============================================
CREATE PROCEDURE AgregarVehiculo
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
    INSERT INTO [dbo].[Vehiculo]
           ([Id]
           ,[IdModelo]
           ,[Placa]
           ,[Color]
           ,[Anio]
           ,[Precio]
           ,[CorreoPropietario]
           ,[TelefonoPropietario])
     VALUES
           (@Id 
            ,@IdModelo 
            ,@Placa 
            ,@Color 
            ,@Anio 
            ,@Precio 
            ,@CorreoPropietario 
            ,@TelefonoPropietario)
END