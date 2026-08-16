USE [ClientesDb]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes]') AND type in (N'U'))
DROP TABLE [dbo].[Clientes]
GO

CREATE TABLE [dbo].[Clientes](
	[ClienteId] [int] identity(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[ApellidoPaterno] [nvarchar](100) NOT NULL,
	[ApellidoMaterno] [nvarchar](100) NULL,
	[CorreoElectronico] [nvarchar](200) NOT NULL,
	[Telefono] [nvarchar](20) NULL,
	[FechaNacimiento] [date] NULL,
	[Direccion] [nvarchar](250) NULL,
	[Ciudad] [nvarchar](100) NOT NULL,
	[CodigoPostal] [nvarchar](10) NULL,
	[Activo] [bit] NOT NULL,
	[FechaRegistro] [datetime2](7) NOT NULL,
	[FechaModificacion] [datetime2](7) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Clientes] UNIQUE NONCLUSTERED 
(
	[CorreoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_Activo]  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_FechaRegistro]  DEFAULT (sysdatetime()) FOR [FechaRegistro]
GO


