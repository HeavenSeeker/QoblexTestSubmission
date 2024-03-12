using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using VitronicAPI.Infrastructure.Entities;

namespace VitronicAPI.Infrastructure
{
  public class VitronicDbContext : DbContext
  {
    public VitronicDbContext(DbContextOptions opt) : base(opt)
    {
      this.Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      //Load the XML file in XmlDocument.
      XmlDocument doc = new XmlDocument();
      doc.Load(@"C:\Users\BBOMAR\source\repos\HeavenSeeker\QoblexTestSubmission\VitronicTest\VitronicTest\bin\Debug\net7.0\resources\data.xml");
      var headern = doc.SelectSingleNode("/TrafficData/Header");
      var header = new Header
      {
        SessionID = headern["SessionID"].InnerText
      };
      var id = 1;
      var events = new List<Event>();
      //Loop through the selected Nodes.
      foreach (XmlNode node in doc.SelectNodes("/TrafficData/Events/m"))
      {
        //Fetch the Node values and assign it to Model.
        events.Add(new Event
        {
          Id = id++,
          HeaderSessionID = header.SessionID,
          T = DateTime.Parse(node.Attributes.GetNamedItem("t").InnerText),
          Category= node.Attributes.GetNamedItem("c").InnerText
        });
      }

      modelBuilder.Entity<Header>().HasData(header);
      modelBuilder.Entity<Event>().HasData(events);
    }

    public DbSet<Header> Headers { get; set; }
    public DbSet<Event> Events { get; set; }
  }
}
