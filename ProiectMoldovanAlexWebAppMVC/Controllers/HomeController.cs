using Azure;
using Azure.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using ProiectMoldovanAlexWebAppMVC.Models;
using System.Diagnostics;
namespace ProiectMoldovanAlexWebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
