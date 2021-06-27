using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VGC
{
    class DataBase
    {
        string conString = " datasource = localhost; port = 3306; username = root; ";

        public void insertar(string consulta)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(conString);
                MySqlCommand command = new MySqlCommand(consulta, con);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error\n{ex}");
            }
        }

        public DataTable consultar(string consulta)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(conString);
                MySqlCommand command = new MySqlCommand(consulta, con);

                con.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();

                return dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error\n{ex}");
                return null;
            }
        }
    }
}
