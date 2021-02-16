﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ASAP.Data.Entities
{
	public class Person
	{
		[Key]
		public int PersonId { get; set; }
		public string FirstName { get; set; }
		public string MiddleName{ get; set; }
		public string LastName { get; set; }
		public string MobilePhone{ get; set; }
		public string Email { get; set; }
	}
}
