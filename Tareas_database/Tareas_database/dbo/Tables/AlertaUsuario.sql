CREATE TABLE [dbo].[AlertaUsuario] (
    [IdUsuario]         VARCHAR (50)  NOT NULL,
    [FechaUltimaAlerta] DATETIME      NULL,
    [MensajeCorreo]     VARCHAR (MAX) NULL,
    CONSTRAINT [PK_AlertaUsuario] PRIMARY KEY CLUSTERED ([IdUsuario] ASC)
);

