CREATE TABLE [dbo].[TareaEstado] (
    [IdTarea]           NUMERIC (18)  NOT NULL,
    [Secuancial]        INT           NOT NULL,
    [Estado]            VARCHAR (50)  NOT NULL,
    [IdUsuario]         VARCHAR (50)  NOT NULL,
    [FechaModificacion] DATETIME      NOT NULL,
    [Observacion]       VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_TareaEstado] PRIMARY KEY CLUSTERED ([IdTarea] ASC, [Secuancial] ASC),
    CONSTRAINT [FK_TareaEstado_Tarea] FOREIGN KEY ([IdTarea]) REFERENCES [dbo].[Tarea] ([IdTarea])
);

