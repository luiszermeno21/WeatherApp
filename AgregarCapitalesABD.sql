USE [CIUDADES]
GO
/****** Object:  StoredProcedure [dbo].[addcapitales]    Script Date: 02/11/2019 04:29:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[addcapitales](
	@nombre nvarchar(50),
	@capital nvarchar(50),
	@region nvarchar(50),
	@haserror bit out
)
as
begin try
	set @haserror = 0;
	insert into capitales
	values
	(@nombre,@capital,@region)
end try
begin catch
	set @haserror = 1;
end catch
