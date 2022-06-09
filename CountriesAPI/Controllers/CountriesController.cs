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

        [HttpGet]
        [Route("/test")]
        public string Test(string? include, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(args);

            return args.ToString();
        }

        [HttpGet]
        public List<Country> GetCountries(string? include, params object[] args)
        //string? include, string? name, string? nameFrench, string? nameSpanish, string? nameRussian, 
        //string? nameChinese, string? nameArabic, string? alpha2, string? alpha3, string? m49code, string? region, 
        //string? subRegion, bool? ldc, bool? lldc)
        {

            List<Country> Result = new List<Country>();
            string[] propsArray = include.Split(",");
            foreach (Country country in Countries)
            {
                Country modifiedCountry = new Country();
                foreach (var prop in propsArray)
                {
                    if (country.GetType().GetProperty(prop) != null)
                    {
                        modifiedCountry.GetType().GetProperty(prop)
                            .SetValue(modifiedCountry, country.GetType().GetProperty(prop).GetValue(country), null);
                    }
                }

                Result.Add(modifiedCountry);
            }

            return Result;
        }
    }
}
