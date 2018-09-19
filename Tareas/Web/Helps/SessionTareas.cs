using System.Web;

namespace Web.Helps
{
    public interface ISessionValueProvider
    {
        string IdUsuario { get; set; }
       

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

       
    }

    public class WebSessionValueProvider : ISessionValueProvider
    {
        private const string _IdVendedor = "IdUsuario";
       
        public string IdUsuario
        {
            get { return (string)HttpContext.Current.Session[_IdVendedor]; }
            set { HttpContext.Current.Session[_IdVendedor] = value; }
        }
    }
}