using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
   public class Parametro_Info
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
    }
}
