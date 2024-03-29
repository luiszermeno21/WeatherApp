USE [CIUDADES]
GO
/****** Object:  StoredProcedure [dbo].[validarusuario]    Script Date: 02/11/2019 04:32:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[validarusuario]
(
	@usuario nvarchar(50),
	@contraseña nvarchar(50),
	@haserror bit out
)
as
begin try
if exists(select top 1 1 from perfiles where usuario = @usuario and contraseña = @contraseña)
begin
	set @haserror = 0
end
end try
begin catch
	set @haserror = 1;
end catch
