using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Specialized;
using System;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ASAP.Data;
using ASAP.Data.Entities;
namespace ASAPTestAPI.Controllers
{
    [Route("api/[controller]")]

    public class CountryController : Controller
    {
        IDataManager _dataManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        public CountryController(IDataManager dataManager,
            IHttpContextAccessor httpContextAccessor,
            IWebHostEnvironment webHostEnvironment, 
            IConfiguration configuration)
        {
            _dataManager = dataManager;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        /// <summary>
        /// Return all addresses
        /// </summary>
        /// <returns></returns>
        [HttpGet("countries")]
        public IActionResult GetCountries()
        {
            return Ok(_dataManager.Country.GetAll());
        }
    }
}