using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitronicAPI.Infrastructure.Entities
{
  public class Event
  {
    //[Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime T { get; set; }
    public string? N { get; set; }
    public string? Category { get; set; }
    public int LI { get; set; }
    public string? O { get; set; }
    public int V { get; set; }
    public int DI { get; set; }
    
    public string HeaderSessionID { get; set; }
    public Header Header { get; set; }
  }
}