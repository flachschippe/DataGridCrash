using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Automation.Peers;

namespace DataGridCrash
{
  public partial class MainWindow : Window
  {
    public class TestData
    {
      public bool Check { get; set; } = true;
    }

    public MainWindow()
    {
      InitializeComponent();

      Items = Enumerable.Range(0, 30).Select(i => new TestData ());
      DataContext = this;
    }

    public bool IsDataGridEnabled { get; set; }

    public IEnumerable<TestData> Items { get; set; }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      dataGrid.IsEnabled = true;
      button.IsEnabled = false;
      button.Content = "Scroll DataGrid with mouse wheel";
    }

    protected override AutomationPeer OnCreateAutomationPeer()
    {
      /*
       * Creation of AutomationPeers can be triggered by opening a popup,
       * see https://github.com/dotnet/wpf/issues/5807
       */

      button.IsEnabled = true;
      button.Content = "Click to enable DataGrid";
      return base.OnCreateAutomationPeer();
    }
  }
}
