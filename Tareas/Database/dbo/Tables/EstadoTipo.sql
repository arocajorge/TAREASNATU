CREATE TABLE [dbo].[EstadoTipo] (
    [IdEstadoTipo]      INT            NOT NULL,
    [Descripcion]       VARCHAR (1000) NOT NULL,
    [Estado]            BIT            NOT NULL,
    [IdUsuario]         VARCHAR (50)   NOT NULL,
    [IdUsuarioModifica] VARCHAR (50)   NULL,
    [IdUsuarioAnula]    VARCHAR (50)   NULL,
    [FechaTransaccion]  DATETIME       NULL,
    [FechaModificacion] DATETIME       NULL,
    [FechaAnulacion]    DATETIME       NULL,
    CONSTRAINT [PK_EstadoTipo] PRIMARY KEY CLUSTERED ([IdEstadoTipo] ASC)
);

