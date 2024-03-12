using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitronicAPI.Infrastructure.DTO;

namespace VitronicAPI.Infrastructure.Data
{
  public interface ITrafficDataService
  {
    IEnumerable<TrafficDataDTO> GetTrafficData(string category);
  }
}
