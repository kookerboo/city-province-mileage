using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityProvMileage.Extensions;

namespace CityProvMileage
{
  class Program
  {
    private static List<MappingItem> _ProvinceMappings = new List<MappingItem>()
    {
      new MappingItem() { CanadaVersion = "ALT", USVersion = "AB" },
      new MappingItem() { CanadaVersion = "ALTA", USVersion = "AB" },
      new MappingItem() { CanadaVersion = "BC", USVersion = "BC" },
      new MappingItem() { CanadaVersion = "MAN", USVersion = "MB" },
      new MappingItem() { CanadaVersion = "NB", USVersion = "NB" },
      new MappingItem() { CanadaVersion = "NFD", USVersion = "NF" },
      new MappingItem() { CanadaVersion = "NWT", USVersion = "NT" },
      new MappingItem() { CanadaVersion = "NS", USVersion = "NS" },
      new MappingItem() { CanadaVersion = "NU", USVersion = "NU" },
      new MappingItem() { CanadaVersion = "ONT", USVersion = "ON" },
      new MappingItem() { CanadaVersion = "PEI", USVersion = "PE" },
      new MappingItem() { CanadaVersion = "QUE", USVersion = "PQ" },
      new MappingItem() { CanadaVersion = "SAS", USVersion = "SK" },
      new MappingItem() { CanadaVersion = "SASK", USVersion= "SK" },
      new MappingItem() { CanadaVersion = "YK", USVersion = "YT" },
      new MappingItem() { CanadaVersion = "YUK", USVersion = "YT" }
    };

    static void Main(string[] args)
    {
      //get list of all Canadian cities from IVAN OSCITY table
      List<Models.CityModel> cities = Persistence.CityRepository.Instance.GetAll();
      //get list of all cities and their seq# from IVAN MGCITA#, MGCITB# tables
      List<Models.MileageCityModel> mileageCities = Persistence.MileageCityRepository.Instance.GetAll();
      //get list of all to/from mileages by seq# from IVAN MGDIST table
      List<Models.MileageModel> mileages = Persistence.MileageRepository.Instance.GetAll();
      //final results will be in this list
      List<ViewModels.CityProvMileageViewModel> cityProvMileages = new List<ViewModels.CityProvMileageViewModel>();

      //province names in cities and mileageCities don't match up in all cases so convert to US versions first     
      foreach (Models.MileageCityModel mileageCity in mileageCities)
      {
        MappingItem mappingItem = _ProvinceMappings.First(provMapping => provMapping.CanadaVersion == mileageCity.Province);
        mileageCity.Province = mappingItem.USVersion;
      }
      foreach (Models.CityModel city in cities)
      {
        //map provinces to US versions 
        MappingItem mappingItem = _ProvinceMappings.First(provMapping => provMapping.CanadaVersion == city.Province);
        city.Province = mappingItem.USVersion;
      }



      Parallel.ForEach(cities.Combinate(2), (cityPair) => {
        Models.CityModel cityA = cityPair.ElementAt(0);
        Models.CityModel cityB = cityPair.ElementAt(1);


        //check if city is in mileageCity, or get parent if needed
        //used to get sequence number so mileage can be determined
        Models.MileageCityModel mileageCityA = mileageCities.FirstOrDefault(model => model.City == cityA.ShortCityName && model.Province == cityA.Province);
        if (mileageCityA == null)
        {
          Models.CityModel parentCityA = cities.FirstOrDefault(mainCityA => (mainCityA.ProvinceCode == cityA.ProvinceCode) && (mainCityA.CityCode == cityA.CityCode) && (mainCityA.SuburbCode == 1));
          if (parentCityA != null)
          {
            mileageCityA = mileageCities.FirstOrDefault(model => model.City == parentCityA.ShortCityName && model.Province == parentCityA.Province);
          }
        }

        Models.MileageCityModel mileageCityB = mileageCities.FirstOrDefault(model => model.City == cityB.ShortCityName && model.Province == cityB.Province);
        if (mileageCityB == null)
        {
          Models.CityModel parentCityB = cities.FirstOrDefault(mainCityB => (mainCityB.ProvinceCode == cityB.ProvinceCode) && (mainCityB.CityCode == cityB.CityCode) && (mainCityB.SuburbCode == 1));
          if (parentCityB != null)
          {
            mileageCityB = mileageCities.FirstOrDefault(model => model.City == parentCityB.ShortCityName && model.Province == parentCityB.Province);
          }
        }




        //if we have a sequence match for both cities, find mileage
        if (mileageCityA != null && mileageCityB != null)
        {
          //go out with both sequence numbers and get the mileage
          Models.MileageModel mileage = mileages.FirstOrDefault(model =>
          (model.SequenceFrom == mileageCityA.Sequence && model.SequenceTo == mileageCityB.Sequence) ||
          (model.SequenceFrom == mileageCityB.Sequence && model.SequenceTo == mileageCityA.Sequence));

          if (mileage != null)
          {
            cityProvMileages.Add(new ViewModels.CityProvMileageViewModel()
            {
              FromCity = cityA.ShortCityName,
              FromProvince = cityA.Province,
              ToCity = cityB.ShortCityName,
              ToProvince = cityB.Province,
              Transportation = "Land",
              Version = "Ivan Mileage",
              Mileage = mileage.Mile
            });
            //to see if there is actually something happening
            //Console.WriteLine(cityA.ShortCityName + " " + cityB.ShortCityName + " " + mileage.Mile);
            if ((cityProvMileages.Count % 10000) == 0)
            {
              Console.WriteLine(cityProvMileages.Count);
            }
          }
        }
        //get rid of duplicates.. combinate does this already?       
        //List<ViewModels.CityProvMileageViewModel> uniqueCityProvinceMileages = cityProvMileages
        //    .Distinct(new ViewModels.CityProvMileageViewModel.CityProvinceComparer())
        //    .ToList();
      }
      );

      Console.WriteLine(cityProvMileages.Count);

    }

  }
}

