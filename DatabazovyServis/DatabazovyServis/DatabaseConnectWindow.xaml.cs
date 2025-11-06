using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DatabazovyServis
{
	/// <summary>
	/// Interakční logika pro DatabaseConnectWindow.xaml
	/// </summary>
	public partial class DatabaseConnectWindow : Window
	{
		private DatabaseManager dbManager;

		public DatabaseConnectWindow(DatabaseManager databaseManager)
		{
			InitializeComponent();
			this.dbManager = databaseManager;
		}

		private void Button_Database_Connect(object sender, RoutedEventArgs e)
		{
			if(!string.IsNullOrWhiteSpace(this.Username.Text) && !string.IsNullOrWhiteSpace(this.Password.Text))
			{
				dbManager.SetCredentials(this.Username.Text, this.Password.Text);
				this.DialogResult = true;
				this.Close();
			}
		}

		private void Button_Storno(object sender, RoutedEventArgs e)
		{
			Environment.Exit(1);
		}

		private void IsClosed(object sender, EventArgs e)
		{
			Environment.Exit(1);
		}
	}
}
