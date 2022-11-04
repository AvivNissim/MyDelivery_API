using MyDelivery_API.DALProj;
using MyDelivery_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDelivery_API.BALProj
{
    public class AddressBAL
    {
        private readonly AddressData _data = new AddressData();

        public List<Address> GetAllAddressesFromDb()
        {
            return _data.GetAddresses();
        }

        public List<Address> GetSingleAddressFromDb(int Address_Code)
        {
            return _data.GetAddresses(Address_Code);
        }

        public void AddNewAddressToDb(Address address)
        {
            _data.AddAddress(address);
        }

        public void UpdateAddressFromDb(int Address_Code, Address address)
        {
            _data.UpdateAddress(Address_Code, address);
        }

        public void DeleteAddressFromDb(int Address_Code)
        {
            _data.DeleteAddress(Address_Code);
        }
    }
}