CREATE TABLE [dbo].[TareaArchivoAdjunto] (
    [IdTarea]       NUMERIC (18)   NOT NULL,
    [Secuencial]    INT            NOT NULL,
    [NombreArchivo] VARCHAR (1000) NULL,
    [Archivo]       IMAGE          NULL,
    CONSTRAINT [PK_TareaArchivoAdjunto] PRIMARY KEY CLUSTERED ([IdTarea] ASC, [Secuencial] ASC),
    CONSTRAINT [FK_TareaArchivoAdjunto_Tarea] FOREIGN KEY ([IdTarea]) REFERENCES [dbo].[Tarea] ([IdTarea])
);



