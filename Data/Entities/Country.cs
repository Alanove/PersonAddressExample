using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ASAP.Data.Entities
{
	public class Country
	{
		[Key]
		public string Code { get; set; }

		public string Name { get; set; }

	}
}
