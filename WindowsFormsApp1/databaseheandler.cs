using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class databaseheandler
    {
        MySqlConnection connection;
        public databaseheandler() {
            string username = "root";
            string passwors = "";
            string host = "localhost";
            string dbname = "trabant";
            string connectionstring = $"user={username};password = {passwors};host ={host};database={dbname}";
            connection = new MySqlConnection(connectionstring);     


        }
        public void readall() {
            try
            {
                connection.Open();
                string query = "select * from cars";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read()) {
                    int id = read.GetInt32(read.GetOrdinal("id"));
                    string model = read.GetString(read.GetOrdinal("model"));
                    string make = read.GetString(read.GetOrdinal("make"));
                    string color = read.GetString(read.GetOrdinal("color"));
                    int year = read.GetInt32(read.GetOrdinal("year"));
                    int power = read.GetInt32(read.GetOrdinal("power"));
                    car onecar = new car();
                    onecar.id = id;
                    onecar.power = power;
                    onecar.make = make;
                    onecar.model = model;
                    onecar.color = color;
                    onecar.year = year;
                    car.cars.Add(onecar);
                    
                }
                read.Close();
                command.Dispose();
                connection.Close();
                MessageBox.Show("siker");
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message,"asd");
            }
        }
    }
}
