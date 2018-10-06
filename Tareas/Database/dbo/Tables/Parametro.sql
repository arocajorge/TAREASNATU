﻿CREATE TABLE [dbo].[Parametro] (
    [IdParametro]           INT            NOT NULL,
    [CorreoCuenta]          VARCHAR (1000) NOT NULL,
    [CorreoClave]           VARCHAR (1000) NOT NULL,
    [Puerto]                INT            NOT NULL,
    [Host]                  VARCHAR (200)  NOT NULL,
    [PermitirSSL]           BIT            NOT NULL,
    [FtpUsuario]            VARCHAR (200)  NULL,
    [FtpClave]              VARCHAR (200)  NULL,
    [FtpURLArchivo]         VARCHAR (400)  NULL,
    [FtpURLAdjunto]         VARCHAR (400)  NULL,
    [IdEstadoCierreTarea]   INT            NOT NULL,
    [IdEstadoAprobarTarea]  INT            NOT NULL,
    [IdEstadoTareaDevuelta] INT            NOT NULL,
    [IntervaloEjecucionMin] INT            NOT NULL,
    CONSTRAINT [PK_Parametro] PRIMARY KEY CLUSTERED ([IdParametro] ASC),
    CONSTRAINT [FK_Parametro_Estado] FOREIGN KEY ([IdEstadoCierreTarea]) REFERENCES [dbo].[Estado] ([IdEstado]),
    CONSTRAINT [FK_Parametro_Estado1] FOREIGN KEY ([IdEstadoAprobarTarea]) REFERENCES [dbo].[Estado] ([IdEstado]),
    CONSTRAINT [FK_Parametro_Estado2] FOREIGN KEY ([IdEstadoTareaDevuelta]) REFERENCES [dbo].[Estado] ([IdEstado])
);



