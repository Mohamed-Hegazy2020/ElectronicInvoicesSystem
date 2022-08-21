using ElectronicInvoicesSystem.Data;
using ElectronicInvoicesSystem.Models;
using ElectronicInvoicesSystem.ModelsView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
       
        public IActionResult Dashboard()
        {
            DashboardViewModel d = new DashboardViewModel();
            var t = _context.InvoiceMaster;
            if (t.Any())
            {
                d.AllDocumentsCount = t.Count();              
                d.InvoicesCount = t.Where(x=>x.DocType=="I").Count();
                d.DebitsCount = t.Where(x => x.DocType == "D").Count();
                d.CridetsCount = t.Where(x => x.DocType == "C").Count();

            }
            return View(d);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
