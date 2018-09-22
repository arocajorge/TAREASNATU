using System.Web;

namespace Web.Helps
{
    public interface ISessionValueProvider
    {
        string IdUsuario { get; set; }
        string IdTransaccionSession { get; set; }
        string IdTransaccionSessionActual { get; set; }

    }

    public static class SessionTareas
    {
        private static ISessionValueProvider _sessionValueProvider;
        public static void SetSessionValueProvider(ISessionValueProvider provider)
        {
            _sessionValueProvider = provider;
        }

        public static string IdUsuario
        {
            get { return _sessionValueProvider.IdUsuario; }
            set { _sessionValueProvider.IdUsuario = value; }
        }
        public static string IdTransaccionSession
        {
            get { return _sessionValueProvider.IdTransaccionSession; }
            set { _sessionValueProvider.IdTransaccionSession = value; }
        }
        public static string IdTransaccionSessionActual
        {
            get { return _sessionValueProvider.IdTransaccionSessionActual; }
            set { _sessionValueProvider.IdTransaccionSessionActual = value; }
        }

    }

    public class WebSessionValueProvider : ISessionValueProvider
    {
        private const string _IdVendedor = "IdUsuario";

        private const string _IdTransaccionSession = "IdTransaccionSesssion";
        private const string _IdTransaccionSessionActual = "IdTransaccionSessionActual";
        public string IdUsuario
        {
            get { return (string)HttpContext.Current.Session[_IdVendedor]; }
            set { HttpContext.Current.Session[_IdVendedor] = value; }
        }

        public string IdTransaccionSession
        {
            get { return (string)HttpContext.Current.Session[_IdTransaccionSession]; }
            set { HttpContext.Current.Session[_IdTransaccionSession] = value; }
        }
        public string IdTransaccionSessionActual
        {
            get { return (string)HttpContext.Current.Session[_IdTransaccionSessionActual]; }
            set { HttpContext.Current.Session[_IdTransaccionSessionActual] = value; }
        }
    }
}