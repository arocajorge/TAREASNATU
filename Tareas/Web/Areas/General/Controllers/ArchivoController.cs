﻿using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus;
using Web.Helps;

namespace Web.Areas.General.Controllers
{
    [SessionTimeout]
    public class ArchivoController : Controller
    {
        // GET: General/Archivo
        Archivo_Bus bus_archivo = new Archivo_Bus();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult FileManagerPartial()
        {
            return PartialView("_FileManagerPartial", ArchivoControllerFileManagerSettings.Model);
        }

        public FileStreamResult FileManagerPartialDownload()
        {
            return FileManagerExtension.DownloadFiles(ArchivoControllerFileManagerSettings.DownloadSettings, ArchivoControllerFileManagerSettings.Model);
        }
    }
    public class ArchivoControllerFileManagerSettings
    {
        public const string RootFolder = @"~/FormatoISO";

        public static string Model { get { return RootFolder; } }
        public static DevExpress.Web.Mvc.FileManagerSettings DownloadSettings
        {
            get
            {
                var settings = new DevExpress.Web.Mvc.FileManagerSettings { Name = "FileManager" };
                settings.SettingsEditing.AllowDownload = true;
                
                return settings;
            }
        }
    }

}