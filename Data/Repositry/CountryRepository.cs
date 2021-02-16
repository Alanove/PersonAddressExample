using System;
using System.Collections.Generic;
using System.Text;
using ASAP.Data.Entities;
using ASAP.Utils;

namespace ASAP.Data
{
	public class CountryRepository: Repository<Country>,ICountryRepository
	{
		public CountryRepository(DataContext context) : base(context)
		{
		}
	}
}
