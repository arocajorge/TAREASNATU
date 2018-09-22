CREATE TABLE [dbo].[Seg_Menu_x_usuario] (
    [IdUsuario]   VARCHAR (50) NOT NULL,
    [IdMenu]      INT          NOT NULL,
    [Lectura]     BIT          NOT NULL,
    [Escritura]   BIT          NOT NULL,
    [Eliminacion] BIT          NOT NULL,
    CONSTRAINT [PK_Seg_Menu_x_usuario] PRIMARY KEY CLUSTERED ([IdUsuario] ASC, [IdMenu] ASC),
    CONSTRAINT [FK_Seg_Menu_x_usuario_Seg_Menu] FOREIGN KEY ([IdMenu]) REFERENCES [dbo].[Seg_Menu] ([IdMenu]),
    CONSTRAINT [FK_Seg_Menu_x_usuario_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuario] ([IdUsuario])
);

