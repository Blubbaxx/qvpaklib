using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace qvpak_lib
{
    public class sqliteConnection
    {
        public string run(string database, string label, string table, string id)
        {
            SQLiteConnection connection;

            string read = "";
            int idi;

            try
            {
                idi = Convert.ToInt32(id);
            }

            catch
            {

                read = "Fehlerhafte ID";
                return read; // string

            }

            try
            {
                connection = new SQLiteConnection();
                connection.ConnectionString = "Data Source=" + database;
                connection.Open();



                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT " + label + " FROM " + table + " WHERE ID = " + idi;

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            read = Convert.ToString(reader[0]);

                        }
                        reader.Close();
                    }
                }

                connection.Close();
                connection.Dispose();
            }

            catch (Exception ex)
            {
                read = "Fehler bei der Abfrage";
            }
            
            return read; // string


        }
    }
}
