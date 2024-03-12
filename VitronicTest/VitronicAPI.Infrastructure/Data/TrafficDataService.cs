using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitronicAPI.Infrastructure.DTO;

namespace VitronicAPI.Infrastructure.Data
{
  public class TrafficDataService : ITrafficDataService
  {
    private readonly VitronicDbContext dbContext;

    public TrafficDataService(VitronicDbContext dbContext)
    {
      this.dbContext = dbContext;
    }

    public IEnumerable<TrafficDataDTO> GetTrafficData(string category)
    {
      if (category is null)
      {
        throw new ArgumentNullException(nameof(category));
      }
      return dbContext.Events.Where(x => x.Category == category)
        .Select(x => new TrafficDataDTO(x.Id, x.T, x.N, x.Category, x.LI, x.O, x.V, x.DI)).ToList();
    }
  }
}
