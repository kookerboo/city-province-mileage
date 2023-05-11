using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityProvMileage.ViewModels
{
  public class CityProvMileageViewModel
  { 
    public String FromCity { get; set; }
    public String FromProvince { get; set; }

    public String FromCityProvince { get { return FromCity + ", " + FromProvince; } }
    public String ToCity { get; set; }
    public String ToProvince { get; set; }
    public String ToCityProvince { get { return ToCity + ", " + ToProvince; } }
    public String Transportation { get; set; }
    public String Version { get; set; }
    public Int32 Mileage { get; set; }

    public class CityProvinceComparer : IEqualityComparer<CityProvMileageViewModel>
    {
      public bool Equals(CityProvMileageViewModel x, CityProvMileageViewModel y)
      {
        if (x == null && y == null)
          return true;
        if (x == null || y == null)
          return false;

        return x.FromCity == y.FromCity
            && x.FromProvince == y.FromProvince
            && x.ToCity == y.ToCity
            && x.ToProvince == y.ToProvince;
      }

      public int GetHashCode(CityProvMileageViewModel obj)
      {
        String hcode = obj.FromCity + obj.FromProvince + obj.ToCity + obj.ToProvince;
        return hcode.GetHashCode();
      }
    }
  }
}
