USE [CIUDADES]
GO
/****** Object:  StoredProcedure [dbo].[registrarusuario]    Script Date: 02/11/2019 04:32:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[registrarusuario]
(
	@usuario nvarchar(50),
	@contraseña nvarchar(50),
	@haserror bit out
)
as
begin try
	set @haserror = 0;
	insert into perfiles
	values
	(@usuario,@contraseña)
end try
begin catch
	set @haserror = 1;
end catch
