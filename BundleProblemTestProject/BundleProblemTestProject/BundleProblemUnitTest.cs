using Xunit;

namespace BundleProblemTestProject
{
  public class Bundle
  {
    public string Name { get; set; }
    public int UnitsNeeded { get; set; }
    public List<Bundle> Parts { get; set; } = new();
  }

  public class BundleProblemUnitTest
  {
    /// <summary>
    /// This is the problem solution.
    /// </summary>
    static int Solution(Bundle bundle, Dictionary<string, int> stock)
    {
      //I'm using a recursive solution.
      //cross every item in the tree(bundle), and calculate.
      if (bundle.Parts.Count > 0)
      {
        return bundle.Parts.Select(p => Solution(p, stock)).Min() / bundle.UnitsNeeded;
      }
      else
      {
        return stock[bundle.Name] / bundle.UnitsNeeded;
      }
    }


    //Test data for 2 examples
    public static IEnumerable<object[]> TestData => new[]
    {
      //for 1st example the answer is 17, because there's 35 tubes which can make 17 pairs of wheels.
      new object[] { new Bundle()
      {
        Name = "Bike",
        UnitsNeeded = 1,//to avoid divide by zero
        Parts = new()
        {
          new (){Name="Seat", UnitsNeeded=1},
          new (){Name="Pedal", UnitsNeeded=2},
          new (){Name="Wheel", UnitsNeeded=2, Parts=new(){
                                            new (){Name="Frame", UnitsNeeded=1},
                                            new (){Name="Tube", UnitsNeeded=1},
                                          } },
        }
      }, new Dictionary<string, int> () { ["Seat"] = 50, ["Pedal"] = 60, ["Frame"] = 60, ["Tube"] = 35 }, 17
      },

      //for 2nd example the answer is 2, because we can make enough cylinders for only 2 engines.
      new object[] { new Bundle()
      {
        Name = "Car",
        UnitsNeeded = 1,//to avoid divide by zero
        Parts = new()
        {
          new (){Name="Seats", UnitsNeeded=4},
          new (){Name="Doors", UnitsNeeded=4},
          new (){Name="Tires", UnitsNeeded=4, Parts=new(){new (){Name="Screws", UnitsNeeded=4}}},
          new (){Name="Engine", UnitsNeeded=1, Parts=new(){new (){Name="Cylinder", UnitsNeeded=8}}},
        }
      }, new Dictionary<string, int> () { ["Seats"] = 100, ["Doors"] = 20, ["Screws"] = 40, ["Cylinder"] = 20 }, 2
      }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void SolutionTest(Bundle bundle, Dictionary<string, int> stock, int answer)
    {
      Assert.Equal(answer, Solution(bundle, stock));
    }
  }
}