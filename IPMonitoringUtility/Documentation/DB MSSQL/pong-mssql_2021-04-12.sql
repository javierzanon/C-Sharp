USE [pong]
GO
/****** Object:  User [pong]    Script Date: 12/04/2021 15:13:47 ******/
CREATE USER [pong] FOR LOGIN [pong] WITH DEFAULT_SCHEMA=[pong]
GO
/****** Object:  Table [dbo].[actividad]    Script Date: 12/04/2021 15:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[actividad](
	[fecha] [datetime] NOT NULL,
	[dispositivoid] [bigint] NOT NULL,
	[estadoid] [bigint] NOT NULL,
 CONSTRAINT [PK_actividad] PRIMARY KEY CLUSTERED 
(
	[fecha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dispositivo]    Script Date: 12/04/2021 15:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dispositivo](
	[id] [bigint] NOT NULL,
	[dispositivo] [varchar](50) NOT NULL,
	[ip] [varchar](20) NOT NULL,
	[chequearpreviamenteid] [bigint] NOT NULL,
	[grupoid] [bigint] NOT NULL,
	[eliminado] [bigint] NOT NULL,
 CONSTRAINT [PK_dispositivo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estado]    Script Date: 12/04/2021 15:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estado](
	[id] [bigint] NOT NULL,
	[estado] [varchar](50) NULL,
 CONSTRAINT [PK_estado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[grupo]    Script Date: 12/04/2021 15:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grupo](
	[id] [bigint] NOT NULL,
	[grupo] [varchar](50) NULL,
 CONSTRAINT [PK_grupo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[actividad]  WITH CHECK ADD  CONSTRAINT [FK_actividad_dispositivo] FOREIGN KEY([dispositivoid])
REFERENCES [dbo].[dispositivo] ([id])
GO
ALTER TABLE [dbo].[actividad] CHECK CONSTRAINT [FK_actividad_dispositivo]
GO
ALTER TABLE [dbo].[actividad]  WITH CHECK ADD  CONSTRAINT [FK_actividad_estado] FOREIGN KEY([estadoid])
REFERENCES [dbo].[estado] ([id])
GO
ALTER TABLE [dbo].[actividad] CHECK CONSTRAINT [FK_actividad_estado]
GO
ALTER TABLE [dbo].[dispositivo]  WITH CHECK ADD  CONSTRAINT [FK_dispositivo_dispositivo1] FOREIGN KEY([chequearpreviamenteid])
REFERENCES [dbo].[dispositivo] ([id])
GO
ALTER TABLE [dbo].[dispositivo] CHECK CONSTRAINT [FK_dispositivo_dispositivo1]
GO
ALTER TABLE [dbo].[dispositivo]  WITH CHECK ADD  CONSTRAINT [FK_dispositivo_grupo] FOREIGN KEY([grupoid])
REFERENCES [dbo].[grupo] ([id])
GO
ALTER TABLE [dbo].[dispositivo] CHECK CONSTRAINT [FK_dispositivo_grupo]
GO
/****** Object:  StoredProcedure [dbo].[procListDispositivo]    Script Date: 12/04/2021 15:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[procListDispositivo]
AS
BEGIN

SELECT d.id AS ID, d.ip AS IP, dd.ip AS chequearPreviamenteIP
FROM pong.[dbo].dispositivo d
inner join pong.[dbo].dispositivo dd on dd.id = d.chequearpreviamenteid
WHERE d.eliminado = 0

END
GO
/****** Object:  StoredProcedure [dbo].[procListStatus]    Script Date: 12/04/2021 15:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[procListStatus]
AS
BEGIN

SELECT d.dispositivo, d.ip, e.estado, g.grupo, a.fecha FROM
(SELECT d.id AS dispositivoid, MAX(a.fecha) maxfecha
FROM actividad a 
INNER JOIN dispositivo d ON a.dispositivoid = d.id
GROUP BY d.id) act
INNER JOIN actividad a ON act.maxfecha = a.fecha
INNER JOIN dispositivo d ON a.dispositivoid = d.id
INNER JOIN estado e ON a.estadoid = e.id
INNER JOIN grupo g ON d.grupoid = g.id
WHERE d.eliminado = 0
ORDER BY estado desc, grupo, dispositivo

END
GO
/****** Object:  StoredProcedure [dbo].[procListStatusInactivo]    Script Date: 12/04/2021 15:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[procListStatusInactivo] AS 
BEGIN

SELECT d.dispositivo, d.ip, e.estado, g.grupo, a.fecha FROM
(SELECT d.id AS dispositivoid, MAX(a.fecha) maxfecha
FROM actividad a 
INNER JOIN dispositivo d ON a.dispositivoid = d.id
GROUP BY d.id) act
INNER JOIN actividad a ON act.maxfecha = a.fecha
INNER JOIN dispositivo d ON a.dispositivoid = d.id
INNER JOIN estado e ON a.estadoid = e.id
INNER JOIN grupo g ON d.grupoid = g.id
WHERE d.eliminado = 0 AND e.id = 0
ORDER BY estado desc, grupo, dispositivo

END
GO
/****** Object:  StoredProcedure [dbo].[procSetEstadoDispositivo]    Script Date: 12/04/2021 15:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[procSetEstadoDispositivo]
@dispositivoid BIGINT,
@estadoid BIGINT
AS
BEGIN

INSERT INTO pong.[dbo].actividad VALUES (CURRENT_TIMESTAMP,@dispositivoid, @estadoid);

END
GO
