using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityProvMileage.Models
{
  public class CityModel
  {
    public Int32 ProvinceCode { get; set; }  //CTPROV
    public Int32 CityCode { get; set; }      //CTCITY
    public String Province { get; set; }     //CTSTPR
    public String LongCityName { get; set; } //CTLGCT
    public String ShortCityName { get; set; }//CTSTCT
    public Int32 SuburbCode { get; set; }    //CTSUBR
  }
}
