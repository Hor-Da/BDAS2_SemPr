using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabazovyServis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseManager dbManager = new DatabaseManager();
		public MainWindow()
        {
            InitializeComponent();
            DatabaseConnectWindow DatabaseConnect = new DatabaseConnectWindow(dbManager);
			this.Loaded += (sender, e) =>
			{
				CenterWindow(DatabaseConnect);
				DatabaseConnect.ShowDialog();
				DatabaseConnect.Activate();
			};
		}

		private void CenterWindow(Window targetWindow)
		{
			double mainWindowCenterX = this.Left + this.Width / 2;
			double mainWindowCenterY = this.Top + this.Height / 2;
			double newLeft = mainWindowCenterX - targetWindow.Width / 2;
			double newTop = mainWindowCenterY - targetWindow.Height / 2;
			targetWindow.Left = newLeft;
			targetWindow.Top = newTop;
		}
	}
}