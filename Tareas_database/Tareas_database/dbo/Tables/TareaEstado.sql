CREATE TABLE [dbo].[TareaEstado] (
    [IdTarea]           NUMERIC (18)  NOT NULL,
    [Secuancial]        INT           NOT NULL,
    [IdEstado]          INT           NOT NULL,
    [IdUsuario]         VARCHAR (50)  NOT NULL,
    [FechaModificacion] DATETIME      NOT NULL,
    [Observacion]       VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_TareaEstado] PRIMARY KEY CLUSTERED ([IdTarea] ASC, [Secuancial] ASC),
    CONSTRAINT [FK_TareaEstado_Tarea] FOREIGN KEY ([IdTarea]) REFERENCES [dbo].[Tarea] ([IdTarea])
);

