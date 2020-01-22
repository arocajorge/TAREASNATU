CREATE TABLE [dbo].[Usuario] (
    [IdUsuario]         VARCHAR (50)   NOT NULL,
    [Clave]             VARCHAR (200)  NOT NULL,
    [Nombre]            VARCHAR (500)  NOT NULL,
    [Correo]            VARCHAR (1000) NOT NULL,
    [TipoUsuario]       INT            NOT NULL,
    [Estado]            BIT            NOT NULL,
    [IdUsuarioCreacion] VARCHAR (50)   NOT NULL,
    [IdUsuarioModifica] VARCHAR (50)   NULL,
    [IdUsuarioAnula]    VARCHAR (50)   NULL,
    [FechaTransaccion]  DATETIME       NULL,
    [FechaModificacion] DATETIME       NULL,
    [FechaAnulacion]    DATETIME       NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([IdUsuario] ASC)
);

