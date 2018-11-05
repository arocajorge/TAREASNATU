﻿CREATE TABLE [dbo].[Tarea] (
    [IdTarea]                   NUMERIC (18)  NOT NULL,
    [IdUsuarioSolicitante]      VARCHAR (50)  NOT NULL,
    [IdGrupo]                   INT           NOT NULL,
    [IdUsuarioAsignado]         VARCHAR (50)  NOT NULL,
    [EstadoActual]              INT           NOT NULL,
    [FechaEntrega]              DATE          NOT NULL,
    [AsuntoTarea]               VARCHAR (MAX) NULL,
    [DescripcionTarea]          VARCHAR (MAX) NULL,
    [IdEstadoPrioridad]         INT           NOT NULL,
    [TareaConcurrente]          BIT           NOT NULL,
    [AprobadoSolicitado]        BIT           NOT NULL,
    [AprobadoEncargado]         BIT           NOT NULL,
    [FechaAprobacion]           DATETIME      NULL,
    [FechaFinConcurrencia]      DATE          NULL,
    [DiasIntervaloProximaTarea] INT           NULL,
    [FechaCierreEncargado]      DATETIME      NULL,
    [FechaCierreSolicitante]    DATETIME      NULL,
    [Estado]                    BIT           NOT NULL,
    [IdUsuario]                 VARCHAR (50)  NOT NULL,
    [IdUsuarioModifica]         VARCHAR (50)  NULL,
    [IdUsuarioAnula]            VARCHAR (50)  NULL,
    [FechaTransaccion]          DATETIME      NULL,
    [FechaModificacion]         DATETIME      NULL,
    [FechaAnulacion]            DATETIME      NULL,
    [IdTareaPadre]              DECIMAL (18)  NULL,
    CONSTRAINT [PK_Tarea] PRIMARY KEY CLUSTERED ([IdTarea] ASC),
    CONSTRAINT [FK_Tarea_Estado] FOREIGN KEY ([EstadoActual]) REFERENCES [dbo].[Estado] ([IdEstado]),
    CONSTRAINT [FK_Tarea_Estado1] FOREIGN KEY ([IdEstadoPrioridad]) REFERENCES [dbo].[Estado] ([IdEstado]),
    CONSTRAINT [FK_Tarea_Grupo] FOREIGN KEY ([IdGrupo]) REFERENCES [dbo].[Grupo] ([IdGrupo]),
    CONSTRAINT [FK_Tarea_Usuario] FOREIGN KEY ([IdUsuarioSolicitante]) REFERENCES [dbo].[Usuario] ([IdUsuario]),
    CONSTRAINT [FK_Tarea_Usuario1] FOREIGN KEY ([IdUsuarioAsignado]) REFERENCES [dbo].[Usuario] ([IdUsuario])
);











