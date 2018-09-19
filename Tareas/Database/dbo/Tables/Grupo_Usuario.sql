CREATE TABLE [dbo].[Grupo_Usuario] (
    [IdGrupo]     INT           NOT NULL,
    [IdUsuario]   VARCHAR (50)  NOT NULL,
    [Observacion] VARCHAR (100) NULL,
    CONSTRAINT [PK_Grupo_Usuario] PRIMARY KEY CLUSTERED ([IdGrupo] ASC, [IdUsuario] ASC),
    CONSTRAINT [FK_Grupo_Usuario_Grupo] FOREIGN KEY ([IdGrupo]) REFERENCES [dbo].[Grupo] ([IdGrupo]),
    CONSTRAINT [FK_Grupo_Usuario_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuario] ([IdUsuario])
);

