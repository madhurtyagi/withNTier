using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL;
using System.Data;
using BEL;

namespace BAL
{
    public class BusinessAccess
    {
		DataAccess dac = new DataAccess();

		public int InsertIntoAddressBook(AddressBook addressbook)
		{
			return dac.InsertIntoAddressBook(addressbook);
		}
		public int UpdateAddressBookEmail(AddressBook addressbook)
		{
			return dac.UpdateAddressBookEmail(addressbook);
		}
		public int DeleteFromAddressBook(AddressBook addressbook)
		{
			return dac.DeleteFromAddressBook(addressbook);
		}
		public DataTable SearchAddressBook(AddressBook addressbook)
		{
			return dac.SearchAddressBook(addressbook);
		}





	}
}
