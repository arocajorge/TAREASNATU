using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
   public class Parametro_Info
    {
        public int IdParametro { get; set; }
        [Required(ErrorMessage = "El campo cuenta es obligatorio")]
        public string CorreoCuenta { get; set; }
        [Required(ErrorMessage = "El campo clave es obligatorio")]
        public string CorreoClave { get; set; }
        [Required(ErrorMessage = "El campo puerto es obligatorio")]
        public int Puerto { get; set; }
        [Required(ErrorMessage = "El campo host es obligatorio")]
        public string Host { get; set; }
        public bool PermitirSSL { get; set; }
        [Required(ErrorMessage = "El campo usuario FTP es obligatorio")]
        public string FtpUsuario { get; set; }
        [Required(ErrorMessage = "El campo clave FTP es obligatorio")]
        public string FtpClave { get; set; }
        [Required(ErrorMessage = "El campo url de la FTP es obligatorio, para formatos ISO")]
        public string FtpURLArchivo { get; set; }
        [Required(ErrorMessage = "El campo url de la FTP es obligatorio, para archivos adjuntos ISO")]
        public string FtpURLAdjunto { get; set; }
    }
}
