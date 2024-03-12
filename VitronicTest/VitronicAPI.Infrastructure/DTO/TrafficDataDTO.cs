using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitronicAPI.Infrastructure.Entities;

namespace VitronicAPI.Infrastructure.DTO
{
  public record TrafficDataDTO(int Id,
                                DateTime T,
                                string N,
                                string Category,
                                int LI,
                                string O,
                                int V,
                                int DI);

}
