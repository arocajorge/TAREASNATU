CREATE TABLE [dbo].[Seg_Menu] (
    [IdMenu]                   INT           NOT NULL,
    [IdMenuPadre]              INT           NULL,
    [DescripcionMenu]          VARCHAR (255) NOT NULL,
    [PosicionMenu]             INT           NOT NULL,
    [Habilitado]               BIT           NOT NULL,
    [Tiene_FormularioAsociado] BIT           NOT NULL,
    [nom_Formulario]           VARCHAR (255) NULL,
    [web_nom_Area]             VARCHAR (200) NULL,
    [web_nom_Controller]       VARCHAR (200) NULL,
    [web_nom_Action]           VARCHAR (300) NULL,
    [nivel]                    INT           NULL,
    [Estado]                   BIT           NOT NULL,
    [IdUsuario]                VARCHAR (50)  NOT NULL,
    [IdUsuarioModifica]        VARCHAR (50)  NULL,
    [IdUsuarioAnula]           VARCHAR (50)  NULL,
    [FechaTransaccion]         DATETIME      NULL,
    [FechaModificacion]        DATETIME      NULL,
    [FechaAnulacion]           DATETIME      NULL,
    CONSTRAINT [PK_Seg_Menu] PRIMARY KEY CLUSTERED ([IdMenu] ASC)
);

