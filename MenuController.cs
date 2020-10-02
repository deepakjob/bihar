using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DashboardPage.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DashboardPage.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuRepository _MenuRepository;
        public MenuController(IMenuRepository menuRepository)
        {
            _MenuRepository = menuRepository;
        }
        public ViewResult List()
        {
            return View(_MenuRepository.AllMenu);
        }
        public string SampleGet()
        {
            string strurltest = String.Format("https://adidaasdataservices.azurewebsites.net/Misc/GetReports");
            WebRequest requestObject = WebRequest.Create(strurltest);

            requestObject.Method = "GET";
            HttpWebResponse responseObject = null;
            requestObject.Headers.Add("Authorization", "Basic YWRpZGFhczpEaXN5c0AzMjE=");
            responseObject = (HttpWebResponse)requestObject.GetResponse();
            string strresulttest = null;
            using (Stream stream = responseObject.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strresulttest = sr.ReadToEnd();
                sr.Close();
            }
            return strresulttest;
        }
    }
}
