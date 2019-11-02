USE [CIUDADES]
GO
/****** Object:  StoredProcedure [dbo].[getcity]    Script Date: 02/11/2019 04:30:54 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[getcity]
(
	@nombre nvarchar(50)
)
as
select * from ciudad where nombre like '%' + @nombre + '%'
