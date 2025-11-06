using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DatabazovyServis
{
	public class DatabaseManager
	{
		private string username = "";
		private string password = "";
		private OracleConnection connection;

		public void SetCredentials(string user, string pwd)
		{
			username = user;
			password = pwd;
		}

		public OracleConnection GetConnection()
		{
			string connectionString = $"User Id={username};Password={password};" +
			"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql3.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=BDAS)))";
			return new OracleConnection(connectionString);
		}

		public bool TryToConnect()
		{
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					return true;
				}
			}
			catch (OracleException ex)
			{
				MessageBox.Show($"Oracle connection error: {ex.Message}", "Connection Failed", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Oracle connection error: {ex.Message}", "Connection Failed", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
		}

		public void Connect()
		{
			if (connection != null)
			{
				connection.Open();
			}
			else
			{
				MessageBox.Show("Connection is not initialized.", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void CloseConnection()
		{
			if (connection != null && connection.State == System.Data.ConnectionState.Open)
			{
				connection.Close();
			}
		}
	}
}

	
