using MyDelivery_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyDelivery_API.DALProj
{
    public class CityData
    {
        private DbServices _db = DbServices.GetDbServices();

        public List<City> GetCities(int City_Code = 0)
        {
            string sql = "Select * From Cities ";
            if (City_Code != 0)
                sql += $"Where City_Code = {City_Code}";
            SqlCommand cmd = _db.CreateCommand(sql);
            DataTable dt = _db.Select(cmd);
            return _db.ConvertDataTable<City>(dt);
        }

        public void AddCity(City city)
        {
            string sql = $@"Insert Into Cities(City_Code, City_Name)
                            Valuse({city.City_Code}, N'{city.City_Name}'";
            SqlCommand cmd = _db.CreateCommand(sql);
            _db.ExecuteAndClose(cmd);
        }

        public void UpdateCity(int City_Code, City city)
        {
            string sql = $@"Update Cities Set [City_Code] = {city.City_Code}, [City_Name] = N'{city.City_Name}'
                            Where [City_Code] = {City_Code}";
            SqlCommand cmd = _db.CreateCommand(sql);
            _db.ExecuteAndClose(cmd);
        }

        public void DeleteCity(int City_Code)
        {
            string sql = $@"Delete From Cities Where [City_Code] = {City_Code}";
            SqlCommand cmd = _db.CreateCommand(sql);
            _db.ExecuteAndClose(cmd);
        }
    }
}