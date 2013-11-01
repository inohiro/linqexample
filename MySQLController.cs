using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace linqexample
{
	public class MySQLController
	{
		private const string DefaultHost = "localhost";
		private const string DefaultUser = "root";
		private const string DefaultPassword = "";

		string host, user, password, dbName;

		public MySQLController (string dbName) {
			this.setDefaultValues ();
			this.dbName = dbName;
		}

		public MySQLController ( string host, string dbName, string user, string password ) {
			this.setDefaultValues ();
			this.host = host;
			this.dbName = dbName;
			this.user = user;
			this.password = password;
		}

		private IDbConnection connection;
		public IDbConnection CreateConnection() {
			string connectionString = this.createConnectonString ();
			connection = new MySqlConnection ( connectionString );
			connection.Open ();
			return connection;
		}

		private void setDefaultValues () {
			this.host = DefaultHost;
			this.user = DefaultUser;
			this.password = DefaultPassword;
		}

		public void Dispose () {
			this.connection.Close ();
		}

		private string createConnectonString() {
			string connectionString =
				String.Format (
					"Server={0};Database={1};User ID={2};Password={3};Pooling={4};",
					this.host, this.dbName, this.user, this.password, "false");
			return connectionString;
		}
	}
}
