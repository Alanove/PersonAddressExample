using System;
using System.Collections.Generic;
using System.Text;
using ASAP.Data.Entities;
using ASAP.Utils;

namespace ASAP.Data
{
	public class AddressRepository: Repository<Address>, IAddressRepository
	{
		public AddressRepository(DataContext context) : base(context)
		{
		}
	}
}
