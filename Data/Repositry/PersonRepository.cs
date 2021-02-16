using System;
using System.Collections.Generic;
using System.Text;
using ASAP.Data.Entities;
using ASAP.Utils;

namespace ASAP.Data
{
	public class PersonRepository: Repository<Person>,IPersonRepository 
	{
		public PersonRepository(DataContext context) : base(context)
		{
		}
	}
}
