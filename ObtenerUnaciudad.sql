USE [CIUDADES]
GO
/****** Object:  StoredProcedure [dbo].[unaciudad]    Script Date: 02/11/2019 04:31:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[unaciudad]
(
	@nombre nvarchar(50),
	@haserror bit out
)
as
set @haserror = 1
begin try
if exists(select top 1 1 from ciudad where nombre = @nombre)
begin
	set @haserror = 0
	select top 1 1 from ciudad where nombre = @nombre
end
end try
begin catch
	set @haserror = 1;
end catch
