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

    public class AddressController : Controller
    {
        IDataManager _dataManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        public AddressController(IDataManager dataManager,
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
        [HttpGet("addresses")]
        public IActionResult GetAddresses()
        {
            return Ok(_dataManager.AddressView.GetAll());
        }

        /// <summary>
        /// Return all addresses for a specific person
        /// </summary>
        /// <param name="PersonId"></param>
        /// <returns></returns>
        [HttpGet("{PersonId}")]
        public IActionResult GetAddressList(int PersonId)
        {
            return Ok(_dataManager.AddressView.GetAll().Where(a => a.PersonId == PersonId));
        }

        /// <summary>
        /// Update address details
        /// </summary>
        /// <param name="Address"></param>
        [HttpPut("Create")]
        public ActionResult CreateAddress([FromBody] Address address)
        {
            _dataManager.Address.Add(address);
            _dataManager.Address.SaveChanges();
            return Ok(address);
        }
        /// <summary>
        /// Update address details
        /// </summary>
        /// <param name="Address"></param>
        [HttpDelete("Delete")]
        [HttpDelete("Delete/{addressId}")]
        public ActionResult DeleteAddress(int addressId)
        {
            var address = _dataManager.Address.Get(addressId);
            _dataManager.Address.Remove(address);
            _dataManager.Address.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Update address details
        /// </summary>
        /// <param name="Address"></param>
        [HttpPut("Update")]
        public ActionResult UpdateAddress([FromBody] Address address)
        {
            _dataManager.Address.Update(address);
            _dataManager.Address.SaveChanges();
            return Ok(address);
        }

    }
}