USE [CIUDADES]
GO
/****** Object:  StoredProcedure [dbo].[addcity]    Script Date: 02/11/2019 04:30:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[addcity]
(
	@name nvarchar(50),
	@pais nvarchar(50),
	@tiempohorario int,
	@amanecer int,
	@anochecer int,
	@temperatura float,
	@temperaturamax float,
	@temperaturamin float,
	@haserror bit out
)
as
begin try
	set @haserror = 0;
	insert into ciudad
	values
	(@name, @pais, @tiempohorario, @amanecer, @anochecer, @temperatura, @temperaturamax, @temperaturamin)
end try
begin catch
	set @haserror = 1;
end catch
