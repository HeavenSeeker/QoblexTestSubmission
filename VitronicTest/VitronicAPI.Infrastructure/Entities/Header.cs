using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitronicAPI.Infrastructure.Entities
{
  public class Header
  {
    [Key]
    public string SessionID { get; set; }
    public string? SystemName { get; set; }
    public string? Vendor { get; set; }
    public string? Subsystem { get; set; }
    public string? Location0 { get; set; }
    public string? Location1 { get; set; }
    public string? Location2 { get; set; }
    public int LaneCount { get; set; }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }
    public int CaseCount { get; set; }
    public ICollection<Event> Events { get; set; }
  }
}
