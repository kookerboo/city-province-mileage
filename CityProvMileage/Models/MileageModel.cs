using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityProvMileage.Models
{
  public class MileageModel
  {
    public Int32 SequenceFrom { get; set; }  //MDFROM
    public Int32 SequenceTo { get; set; }    //MDTO
    public Int32 Mile { get; set; }          //MDMILE
    public Int32 Kilometer { get; set; }     //MDKMS

  }
}
