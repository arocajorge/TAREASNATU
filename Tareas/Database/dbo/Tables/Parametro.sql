CREATE TABLE [dbo].[Parametro] (
    [IdParametro]   INT            NOT NULL,
    [CorreoCuenta]  VARCHAR (1000) NOT NULL,
    [CorreoClave]   VARCHAR (1000) NOT NULL,
    [Puerto]        INT            NOT NULL,
    [Host]          VARCHAR (200)  NOT NULL,
    [PermitirSSL]   BIT            NOT NULL,
    [FtpUsuario]    VARCHAR (200)  NULL,
    [FtpClave]      VARCHAR (200)  NULL,
    [FtpURLArchivo] VARCHAR (400)  NULL,
    [FtpURLAdjunto] VARCHAR (400)  NULL,
    CONSTRAINT [PK_Parametro] PRIMARY KEY CLUSTERED ([IdParametro] ASC)
);

