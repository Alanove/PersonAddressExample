using System;
using System.Collections.Generic;
using System.Text;

namespace ASAP.Data
{
	public interface IDataManager
	{
		public IPersonRepository Person { get; }
		public IAddressRepository Address { get; }
		public IAddressViewRepository AddressView { get; }
		public ICountryRepository Country { get; }
	}
}
