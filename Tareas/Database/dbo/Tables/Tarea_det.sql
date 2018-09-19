CREATE TABLE [dbo].[Tarea_det] (
    [IdTarea]         NUMERIC (18)  NOT NULL,
    [Secuancial]      INT           NOT NULL,
    [Descripcion]     VARCHAR (MAX) NULL,
    [OrdenEjecuacion] INT           NOT NULL,
    [FechaInicio]     DATE          NOT NULL,
    [FechaFin]        DATE          NOT NULL,
    CONSTRAINT [PK_Tarea_det] PRIMARY KEY CLUSTERED ([IdTarea] ASC, [Secuancial] ASC),
    CONSTRAINT [FK_Tarea_det_Tarea] FOREIGN KEY ([IdTarea]) REFERENCES [dbo].[Tarea] ([IdTarea])
);

