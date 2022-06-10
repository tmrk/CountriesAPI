using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Text.Json;


namespace CountriesAPI
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : Controller
    {
        List<Country> Countries;

        public CountriesController()
        {

            Countries = Program.countries;

        }

        public class Param
        {
            public string Key { get; set; }

            public List<string> Values = new List<string>();

            public Param (string key, string value)
            {
                Key = key;
                string[] values = value.Split(",");
                foreach (string v in values) Values.Add(v.Trim());
            }
        } 

        [HttpGet]
        public List<Country> GetCountries(
            string? keys, string? name, string? nameFrench, string? nameSpanish, string? nameRussian,
            string? nameChinese, string? nameArabic, string? alpha2, string? alpha3, string? m49code, string? region,
            string? subRegion, string? intermediateRegion, bool? ldc, bool? lldc
        )
        {
            List<Param> queryParams = new List<Param>();
            if (!String.IsNullOrEmpty(name)) queryParams.Add(new Param("name", name));
            if (!String.IsNullOrEmpty(nameFrench)) queryParams.Add(new Param("nameFrench", nameFrench));
            if (!String.IsNullOrEmpty(nameSpanish)) queryParams.Add(new Param("nameSpanish", nameSpanish));
            if (!String.IsNullOrEmpty(nameRussian)) queryParams.Add(new Param("nameRussian", nameRussian));
            if (!String.IsNullOrEmpty(nameChinese)) queryParams.Add(new Param("nameChinese", nameChinese));
            if (!String.IsNullOrEmpty(nameArabic)) queryParams.Add(new Param("nameArabic", nameArabic));
            if (!String.IsNullOrEmpty(alpha2)) queryParams.Add(new Param("alpha2", alpha2));
            if (!String.IsNullOrEmpty(alpha3)) queryParams.Add(new Param("alpha3", alpha3));
            if (!String.IsNullOrEmpty(m49code)) queryParams.Add(new Param("m49code", m49code));
            if (!String.IsNullOrEmpty(region)) queryParams.Add(new Param("region", region));
            if (!String.IsNullOrEmpty(subRegion)) queryParams.Add(new Param("subRegion", subRegion));
            if (!String.IsNullOrEmpty(intermediateRegion)) queryParams.Add(new Param("intermediateRegion", intermediateRegion));

            List<Country> filtered = new List<Country>();
            if (queryParams.Count == 0) filtered = Countries;
            else foreach (Country country in Countries)
            {
                bool match = false;
                foreach (Param param in queryParams)
                {
                    foreach (string paramValue in param.Values)
                    {
                        if (country.GetType().GetProperty(param.Key).GetValue(country, null) != null &&
                            country.GetType().GetProperty(param.Key).GetValue(country, null).ToString() == paramValue)
                        {
                            match = true;
                        }
                    }
                }
                if (match == true) filtered.Add(country);
            }

            List<Country> result = new List<Country>();
            if (String.IsNullOrEmpty(keys)) result = filtered;
            else 
            {
                string[] keysArray = keys.Split(",");

                foreach (Country country in filtered)
                {
                    Country modifiedCountry = new Country();
                    foreach (string key in keysArray)
                    {
                        if (country.GetType().GetProperty(key) != null)
                        {
                            modifiedCountry.GetType().GetProperty(key)
                                .SetValue(modifiedCountry, country.GetType().GetProperty(key).GetValue(country), null);
                        }
                    }

                    result.Add(modifiedCountry);
                }
            }

            return result;
        }
    }
}
