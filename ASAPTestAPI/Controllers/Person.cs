using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASAP.Data;
using ASAP.Data.Entities;
using Microsoft.Extensions.Configuration;

namespace ASAPTestAPI.Controllers
{
	[Route("api/[controller]")]
	public class PersonController : Controller
	{
		IDataManager _dataManager;
		IHttpContextAccessor _httpContextAccessor;
		IConfiguration _configuration;

		public PersonController(IDataManager dataManager,
			IHttpContextAccessor httpContextAccessor,
			IConfiguration configuration)
		{
			_dataManager = dataManager;
			_httpContextAccessor = httpContextAccessor;
			_configuration = configuration;
		}

		/// <summary>
		/// Return all Persons
		/// </summary>
		/// <returns></returns>
		[HttpGet("All")]
		public IActionResult GetAll()
		{
			return Ok(_dataManager.Person.GetAll());
		}

		[HttpPut("Create")]
		public ActionResult Create([FromBody] Person person)
		{
			_dataManager.Person.Add(person);
			_dataManager.Person.SaveChanges();
			return Ok(person);
		}

		[HttpPut("Update")]
		public ActionResult Update([FromBody] Person person)
		{
			_dataManager.Person.Update(person);
			_dataManager.Person.SaveChanges();
			return Ok(person);
		}

		[HttpDelete("Delete")]
		[HttpDelete("Delete/{personId}")]
		public ActionResult Delete(int personId)
		{
			var person = _dataManager.Person.Get(personId);
			_dataManager.Person.Remove(person);
			_dataManager.Person.SaveChanges();
			return Ok();
		}


		[HttpGet("GenerateSampleData")]
		public ActionResult GenerateSampleData()
		{
			string[] names = new string[] { "Joe", "Marc", "Najib", "Samir", "Ella", "Violette" };
			string[] addresses = new string[] { "Yaroun", "Bint Jbeil", "Sour", "Saida", "Beirut", "Antelias" };

			foreach (string name in names)
			{
				var person = new Person
				{
					FirstName = name,
					MiddleName = "Middle Name " + name,
					LastName = "Last Name " + name,
					MobilePhone = "+961" + (new Random().Next(9999999)).ToString(),
					Email = name + "@domain.com"
				};
				_dataManager.Person.Add(person);
				_dataManager.Person.SaveChanges();
				int addres1 = (new Random().Next(addresses.Length));
				int addres2 = (new Random().Next(addresses.Length));

				var address = new Address
				{
					PersonId = person.PersonId,
					AddressLine1 = addresses[addres1],
					AddressLine2 = "Line 2 for " + person.FirstName,
					City = addresses[addres1],
					PostalCode = (new Random().Next(9999999)).ToString(),
					CountryCode = "LB"
				};
				_dataManager.Address.Add(address);

				var address1 = new Address
				{
					PersonId = person.PersonId,
					AddressLine1 = addresses[addres2],
					AddressLine2 = "Line 2 for " + person.FirstName,
					City = addresses[addres1],
					PostalCode = (new Random().Next(9999999)).ToString(),
					CountryCode = "LB"
				};
				_dataManager.Address.Add(address1);

				_dataManager.Address.SaveChanges();

			}
			return Ok();
		}
	}
}
