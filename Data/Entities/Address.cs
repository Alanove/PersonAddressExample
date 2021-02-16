using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ASAP.Data.Entities
{
	public class Address
	{
		[Key]
		public int AddressId { get; set; }

		[ForeignKey("PersonId")]
		public int PersonId { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public string State{ get; set; }
		public string PostalCode{ get; set; }
		[ForeignKey("CountryCode")]
		public string CountryCode { get; set; }

	}
}
