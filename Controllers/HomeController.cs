using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ImportPattern.Models;
using Microsoft.AspNetCore.Http;
using MediatR;
using ImportPattern.Infrastructure.Import;
using System.IO;
using CsvHelper;
using System.Globalization;
using ImportPattern.Models.Product;
using ImportPattern.Models.Customer;
using ImportPattern.Models.Vendor;
using ImportPattern.Models.SalesOrder;

namespace ImportPattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        public delegate decimal UpdateProgress(decimal percentageCompleted);

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Product(IFormFile dataFile)
        {
             var reader = new StreamReader(dataFile.OpenReadStream());
             var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<ProductModel>().ToList();
            var response = await _mediator.Send(new ImportRequest(records, typeof(ProductCommand), NotifyUpdateStatus));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Customer(IFormFile dataFile)
        {
            var reader = new StreamReader(dataFile.OpenReadStream());
            {
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                {
                    var records = csv.GetRecords<CustomerModel>();
                    //var response = await _mediator.Send(new ImportRequest(records,typeof(CustomerCommand), NotifyUpdateStatus));
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SalesOrder(IFormFile dataFile)
        {
            var reader = new StreamReader(dataFile.OpenReadStream());
            {
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                {
                    var records = csv.GetRecords<SalesOrderModel>();
                    var response = await _mediator.Send(new ImportRequest(records,typeof(SalesOrderCommand), NotifyUpdateStatus));
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Vendor(IFormFile dataFile)
        {
            using (var reader = new StreamReader(dataFile.OpenReadStream()))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<VendorModel>();
                    //var response = await _mediator.Send(new ImportRequest(records, typeof(VendorCommand), NotifyUpdateStatus));
                }
            }
            return View();
        }

        public decimal NotifyUpdateStatus(decimal status)
        {
            return status;
        }

        //private string CallbackFunction(decimal percentCompleted)

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
