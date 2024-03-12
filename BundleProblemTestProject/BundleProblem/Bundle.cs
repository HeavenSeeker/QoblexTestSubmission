using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleProblem
{
  public class Bundle
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int UnitsNeeded { get; set; }
    public List<Bundle> Parts { get; set; } = new();
    public Bundle Parent { get; set; }
    public int? ParentId { get; set; }
  }
}
