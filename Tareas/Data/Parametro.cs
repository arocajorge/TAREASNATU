//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parametro
    {
        public int IdParametro { get; set; }
        public string CorreoCuenta { get; set; }
        public string CorreoClave { get; set; }
        public int Puerto { get; set; }
        public string Host { get; set; }
        public bool PermitirSSL { get; set; }
        public string FtpUsuario { get; set; }
        public string FtpClave { get; set; }
        public string FtpURLArchivo { get; set; }
        public string FtpURLAdjunto { get; set; }
        public int IdEstadoCierreTarea { get; set; }
        public int IdEstadoAprobarTarea { get; set; }
        public int IdEstadoTareaDevuelta { get; set; }
    
        public virtual Estado Estado { get; set; }
        public virtual Estado Estado1 { get; set; }
        public virtual Estado Estado2 { get; set; }
    }
}
