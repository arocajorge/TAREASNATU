using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info;
using System.Net;
using System.IO;
using Data.General;
namespace Data
{
  public  class Archivo_Data
    {

        public bool Guardar_Adjuntos(List<TareaArchivoAdjunto_Info> lista_file)
        {
            try
            {
                Parametro_Info info_ftp = new Parametro_Info();
                Parametro_Data data_ftp = new Parametro_Data();

                info_ftp = data_ftp.get_info();
                if (info_ftp == null)
                    info_ftp = new Parametro_Info();


                foreach (var item in lista_file)
                {
                    string ftpurl = String.Format("{0}/{1}/{2}", info_ftp.FtpURLAdjunto, item.NombreArchivo, item.NombreArchivo);

                    try
                    {
                        WebRequest request = WebRequest.Create(String.Format("{0}/{1}/", info_ftp.FtpURLAdjunto, item.NombreArchivo));
                        request.Method = WebRequestMethods.Ftp.MakeDirectory;
                        request.Credentials = new NetworkCredential(info_ftp.FtpUsuario, info_ftp.FtpClave);
                        WebResponse response = request.GetResponse();
                    }
                    catch (Exception)
                    {
                        //Si existe se cae
                    }
                    

                    Stream streamObj = System.IO.Stream.Null;
                    streamObj.Read(item.Archivo, 0, item.Archivo.Length);
                    streamObj.Close();
                    streamObj = null;
                    var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                    requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                    requestObj.Credentials = new NetworkCredential(info_ftp.FtpUsuario, info_ftp.FtpClave);
                    Stream requestStream = requestObj.GetRequestStream();
                    requestStream.Write(item.Archivo, 0, item.Archivo.Length);
                    requestStream.Flush();
                    requestStream.Close();
                    requestObj = null;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Guardar_formatos_ISO(string NombreArchivo, byte[] tamanio_file)
        {
            try
            {
                Parametro_Info info_ftp = new Parametro_Info();
                Parametro_Data data_ftp = new Parametro_Data();

                info_ftp = data_ftp.get_info();
                if (info_ftp == null)
                    info_ftp = new Parametro_Info();


             
                    string ftpurl = String.Format("{0}/{1}/{2}", info_ftp.FtpURLAdjunto, NombreArchivo, NombreArchivo);

                    try
                    {
                        WebRequest request = WebRequest.Create(String.Format("{0}/{1}/", info_ftp.FtpURLAdjunto, NombreArchivo));
                        request.Method = WebRequestMethods.Ftp.MakeDirectory;
                        request.Credentials = new NetworkCredential(info_ftp.FtpUsuario, info_ftp.FtpClave);
                        WebResponse response = request.GetResponse();
                    }
                    catch (Exception)
                    {
                        //Si existe se cae
                    }


                    Stream streamObj = System.IO.Stream.Null;
                    streamObj.Read(tamanio_file, 0, tamanio_file.Length);
                    streamObj.Close();
                    streamObj = null;
                    var requestObj = FtpWebRequest.Create(ftpurl) as FtpWebRequest;
                    requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                    requestObj.Credentials = new NetworkCredential(info_ftp.FtpUsuario, info_ftp.FtpClave);
                    Stream requestStream = requestObj.GetRequestStream();
                    requestStream.Write(tamanio_file, 0, tamanio_file.Length);
                    requestStream.Flush();
                    requestStream.Close();
                    requestObj = null;
                

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
