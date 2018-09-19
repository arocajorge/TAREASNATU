CREATE TABLE [dbo].[Grupo] (
    [IdGrupo]           INT            NOT NULL,
    [IdUsuario]         VARCHAR (50)   NOT NULL,
    [Descripcion]       VARCHAR (1000) NOT NULL,
    [Estado]            BIT            NOT NULL,
    [IdUsuarioCreacion] VARCHAR (50)   NOT NULL,
    [IdUsuarioModifica] VARCHAR (50)   NULL,
    [IdUsuarioAnula]    VARCHAR (50)   NULL,
    [FechaTransaccion]  DATETIME       NULL,
    [FechaModificacion] DATETIME       NULL,
    [FechaAnulacion]    DATETIME       NULL,
    CONSTRAINT [PK_Grupo] PRIMARY KEY CLUSTERED ([IdGrupo] ASC),
    CONSTRAINT [FK_Grupo_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuario] ([IdUsuario])
);

