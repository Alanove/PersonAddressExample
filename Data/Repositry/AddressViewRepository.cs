
using System;
using System.Collections.Generic;
using System.Text;
using ASAP.Data.Entities;
using ASAP.Utils;

namespace ASAP.Data
{
	public class AddressViewRepository: Repository<AddressView>, IAddressViewRepository
	{
		public AddressViewRepository(DataContext context) : base(context)
		{
		}
	}
}
