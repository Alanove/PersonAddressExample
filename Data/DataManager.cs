using System;
using System.Collections.Generic;
using System.Text;

namespace ASAP.Data
{
	public class DataManager : IDataManager
	{
		#region Constructor
		public DataManager(DataContext dataContext)
		{
			_Person = new PersonRepository(dataContext);
			_Address = new AddressRepository(dataContext);
			_AddressView = new AddressViewRepository(dataContext);
			_Country = new CountryRepository(dataContext);
		}
		#endregion

		#region properties
		IPersonRepository _Person;
		ICountryRepository _Country;
		IAddressRepository _Address;
		IAddressViewRepository _AddressView;

		public IPersonRepository Person
		{
			get
			{
				return _Person;
			}
		}
		public IAddressRepository Address
		{
			get
			{
				return _Address;
			}
		}
		public IAddressViewRepository AddressView
		{
			get
			{
				return _AddressView;
			}
		}
		public ICountryRepository Country
		{
			get
			{
				return _Country;
			}
		}
		#endregion
	}
}
