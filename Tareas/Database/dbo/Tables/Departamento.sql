﻿CREATE TABLE [dbo].[Departamento] (
    [IdDepartamento]    INT            NOT NULL,
    [Descripcion]       VARCHAR (1000) NOT NULL,
    [Estado]            BIT            NOT NULL,
    [IdUsuario]         VARCHAR (50)   NOT NULL,
    [IdUsuarioModifica] VARCHAR (50)   NULL,
    [IdUsuarioAnula]    VARCHAR (50)   NULL,
    [FechaTransaccion]  DATETIME       NULL,
    [FechaModificacion] DATETIME       NULL,
    [FechaAnulacion]    DATETIME       NULL,
    CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED ([IdDepartamento] ASC)
);

