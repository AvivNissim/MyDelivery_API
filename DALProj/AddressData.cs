using MyDelivery_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyDelivery_API.DALProj
{
    public class AddressData
    {
        private DbServices _db = DbServices.GetDbServices();

        public List<Address> GetAddresses(int Address_Code = 0)
        {
            string sql = "Select * From Addresses ";
            if (Address_Code != 0)
                sql += $"Where Address_Code = {Address_Code}";
            SqlCommand cmd = _db.CreateCommand(sql);
            DataTable dt = _db.Select(cmd);
            return _db.ConvertDataTable<Address>(dt);
        } 

        public void AddAddress(Address address)
        {
            string sql = $@"Insert Into Addresses(Address_Code, Address_Name, City_Code)
                            Values({address.Address_Code}, N'{address.Address_Name}', {address.City_Code})";
            SqlCommand cmd = _db.CreateCommand(sql);
            _db.ExecuteAndClose(cmd);
        }

        public void UpdateAddress(int Address_Code, Address address)
        {
            string sql = $@"Update Addresses Set [Address_Code] = {address.Address_Code}, [Address_Name] = N'{address.Address_Name}'
                            Where [Address_Code] = {Address_Code}";
        }

        public void DeleteAddress(int Address_Code)
        {
            string sql = $@"Delete From Addresses Where [Address_Code] = {Address_Code}";
            SqlCommand cmd = _db.CreateCommand(sql);
            _db.ExecuteAndClose(cmd);
        }
    }
}