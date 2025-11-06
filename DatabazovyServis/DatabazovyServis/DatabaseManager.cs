using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace DatabazovyServis
{
	internal class DatabaseManager
	{
		private string username;
		private string password;
		
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
	}
}
