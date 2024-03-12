using RestSharp.Authenticators;
using RestSharp;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VitronicAPI.Infrastructure.DTO;

namespace WpfClient
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
      var options = new RestClientOptions("http://localhost:5039");
      using var client = new RestClient(options);
      var request = new RestRequest("Traffic/");
      request.AddParameter("category", categoryBox.Text);
      // The cancellation token comes from the caller. You can still make a call without it.
      var response = await client.GetAsync<TrafficDataDTO[]>(request);
      dataPanel.Children.Clear();
      foreach (var item in response)
      {
        dataPanel.Children.Add(new TextBlock() { Text = $"Id: {item.Id}, {item.T:u} of category:{item.Category}" });
      }
    }
  }
}