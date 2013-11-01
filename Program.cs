using System;
using System.Xml;
using System.Linq;
using System.Xml.Linq;

using System.Data.Linq;

namespace linqexample
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string dbName = "linqtest";
			var mysqlController = new MySQLController (dbName);

			using ( var connection = mysqlController.CreateConnection() ) {
				using ( var commander = connection.CreateCommand() ) {
					string sql = "SELECT * FROM `Author`;";
					commander.CommandText = sql;

					using ( var reader = commander.ExecuteReader() ) {
						while (reader.Read ()) {
							Console.WriteLine (reader ["Name"].ToString ());
						}
					}
				}

				Console.WriteLine ();

				// LINQ to SQL - Do I have to make a DB model with GUI tool?

				// var db = new DataContext (connection);
				// var authors = db.GetTable<Author> ();
				// var names = from author in authors
				//	select author ["Name"];
				// foreach (var name in names) {
				//	Console.WriteLine (name);
				// }
			}

			string xmlDocLocation = @"/Users/inohiro/project/mono/example1/data/data.xml";
			var xdoc = XDocument.Load ( xmlDocLocation );
			// Console.WriteLine (xdoc);

			var titles = from books in xdoc.Elements ("Books") select books.Elements ("Title");

			foreach (var title in titles) {
				Console.WriteLine (title);
			}

			Console.ReadLine ();
		}
	}
}
