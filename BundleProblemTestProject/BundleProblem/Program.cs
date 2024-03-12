
using BundleProblem;
using Microsoft.EntityFrameworkCore;

var db = new BundleDbContext();

//db.Database.EnsureDeleted();
//db.Database.EnsureCreated();
//db.Bundles.ExecuteDelete();

//db.Bundles.Add(new Bundle
//{
//  Name = "Car",
//  Parts = new() { new Bundle() { Name = "Tire" },
//                  new Bundle() { Name = "Engine" , Parts = new (){ new Bundle() { Name = "Cylindre" } } } }
//});

db.SaveChanges();
Console.WriteLine("Bundle saved");
