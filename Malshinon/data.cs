using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Malshinon
{
    internal class Date
    {
        private string connStr = "server=127.0.0.1;user=root;password=;database=malshinondb";
        private MySqlConnection _conn;
        private static Date Instans = null; 
        public MySqlConnection openConnection()
        {
            if (_conn == null)
            {
                _conn = new MySqlConnection(connStr);
            }

            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();
                ConsolePrint.Maseg(1);
            }

            return _conn;
        }
        public void closeConnection()
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                _conn.Close();
                _conn = null;
            }
        }
        private Date()
        {
            try
            {
                openConnection();
            }
            catch (MySqlException ex)
            {
                ConsolePrint.Errors(2, ex.ToString());
            }
        }
        public static Date GetInstans()
        {
            if (Instans == null)
                Instans = new Date();
            return Instans;
        }
        public List<string> getFirstName (string query = "SELECT first_name FROM people") 
        {
            List<string> nameList= new List<string>();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                openConnection();
                cmd = new MySqlCommand(query, _conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nameList.Add(reader.GetString("first_name"));
                }
            }
            catch (Exception ex)
            {
                ConsolePrint.Errors(1,ex.ToString());
                Console.WriteLine("getFirstName");
            }
            finally 
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                closeConnection();
            }
            return nameList;
            
        }
        public List<string> getLestName(string query = "SELECT last_name FROM people")
        {
            List<string> nameList = new List<string>();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                openConnection();
                cmd = new MySqlCommand(query, _conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nameList.Add(reader.GetString("last_name"));
                }
            }
            catch (Exception ex)
            {
                ConsolePrint.Errors(1, ex.ToString());
                Console.WriteLine("getlastName");
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                closeConnection();
            }
            return nameList;

        }
        public List<string> getFullName(string query = "SELECT first_name,last_name FROM people")
        {
            List<string> nameList = new List<string>();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                openConnection();
                cmd = new MySqlCommand(query, _conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nameList.Add(reader.GetString("first_name")+" "+reader.GetString("last_name"));
                }
            }
            catch (Exception ex)
            {
                ConsolePrint.Errors(1, ex.ToString());
                Console.WriteLine("getFullName");
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                closeConnection();
            }
            return nameList;

        }
        public string getCodeName(string query = "SELECT secret_code FROM people ", string first_name ="", string lest_name = "")
        {
            string code = "";
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                openConnection();
                cmd = new MySqlCommand(query + $"WHERE first_name = '{first_name}' AND last_name = '{lest_name}'", _conn);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                    code = reader.GetString("secret_code");
                else
                {
                    Console.WriteLine("a problem to loud the passord");
                    code = null;
                }
            }
            catch (Exception ex)
            {
                ConsolePrint.Errors(1, ex.ToString());
                ConsolePrint.Maseg("getCodeName");
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                closeConnection();
            }
            return code;
        }
        public List<string> getOllPasword(string query = "SELECT secret_code FROM people")
        {
            List<string> nameList = new List<string>();
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                openConnection();
                cmd = new MySqlCommand(query, _conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nameList.Add(reader.GetString("first_name"));
                }
            }
            catch (Exception ex)
            {
                ConsolePrint.Errors(1, ex.ToString());
                Console.WriteLine("getFirstName");
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                closeConnection();
            }
            return nameList;

        }
        public void AddPeopleToDB(People people)
        {
            string name = people.FullName;
            string[] arrayname = name.Split(' ');
            string first_name = arrayname[0];
            string last_name = arrayname[1];
            string secret_code = Convert.ToString(people.secretCode);
            Console.WriteLine(secret_code);
            
            string status = people.TypePeople;

            try 
            {
                openConnection();
                string query = "INSERT INTO people (first_name, last_name, secret_code, type) " +
                    "VALUES(@first_name, @last_name, @secret_code, @status)";
                using (MySqlCommand cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@first_name", first_name);
                    cmd.Parameters.AddWithValue("@last_name", last_name);
                    cmd.Parameters.AddWithValue("@secret_code", secret_code);
                    cmd.Parameters.AddWithValue("@status", status);
                    int effected = cmd.ExecuteNonQuery();
                    if (effected > 0)
                    {
                        ConsolePrint.Maseg($"{first_name} {last_name} was added");
                        return ;
                    }
                    else
                    {
                        ConsolePrint.Errors(1);
                    }
                }
            }
            catch (MySqlException ex)
            {
                ConsolePrint.Errors(0,$"Sql Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                ConsolePrint.Errors(0,$"Exception: {ex.Message}");
            }
            finally
            {
                closeConnection();
            }
        }
    }
}
