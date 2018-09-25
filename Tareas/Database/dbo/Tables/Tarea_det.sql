CREATE TABLE [dbo].[Tarea_det] (
    [IdTarea]           NUMERIC (18)  NOT NULL,
    [Secuancial]        INT           NOT NULL,
    [Descripcion]       VARCHAR (MAX) NULL,
    [FechaInicio]       DATE          NOT NULL,
    [FechaFin]          DATE          NOT NULL,
    [NumHoras]          FLOAT (53)    NOT NULL,
    [IdUsuario]         VARCHAR (50)  NOT NULL,
    [IdEstado]          INT           NOT NULL,
    [FechaUltimaModif]  DATETIME      NOT NULL,
    [Observacion]       VARCHAR (MAX) NULL,
    [NumHorasReales]    FLOAT (53)    NULL,
    [FechaTerminoTarea] DATETIME      NULL,
    CONSTRAINT [PK_Tarea_det] PRIMARY KEY CLUSTERED ([IdTarea] ASC, [Secuancial] ASC),
    CONSTRAINT [FK_Tarea_det_Estado] FOREIGN KEY ([IdEstado]) REFERENCES [dbo].[Estado] ([IdEstado]),
    CONSTRAINT [FK_Tarea_det_Tarea] FOREIGN KEY ([IdTarea]) REFERENCES [dbo].[Tarea] ([IdTarea]),
    CONSTRAINT [FK_Tarea_det_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuario] ([IdUsuario])
);



