using MyDelivery_API.DALProj;
using MyDelivery_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDelivery_API.BALProj
{
    public class CityBAL
    {
        private readonly CityData _data = new CityData();
        public List<City> GetAllCitiesFromDb()
        {
            return _data.GetCities();
        }

        public List<City> GetSingleCityFromDb(int City_Code)
        {
            return _data.GetCities(City_Code);
        }

        public void AddNewCityToDb(City city)
        {
            _data.AddCity(city);
        }

        public void UpdateCityFromDb(int City_Code, City city)
        {
            _data.UpdateCity(City_Code, city);
        }

        public void DeleteCityFromDb(int City_Code)
        {
            _data.DeleteCity(City_Code);
        }
    }

}