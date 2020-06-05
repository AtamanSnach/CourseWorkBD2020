using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace BDCourseWork
{
    public class Query
    {
        public static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=JobAgency;";
        public MySqlConnection DatabaseConnection = new MySqlConnection(connectionString);
        public MySqlDataReader DataReader;
        public MySqlDataAdapter DataAdapter;
        public DataTable BufTable = new DataTable();
        public Query()
        {
            DatabaseConnection.Open();
        }
        ~Query()
        {
            if (DatabaseConnection.State == ConnectionState.Open)
                DatabaseConnection.Close();
        }
        public DataTable SomeSelect(string query)
        {
            try
            {
                BufTable = new DataTable();
                DataAdapter = new MySqlDataAdapter(query, DatabaseConnection);
                DataAdapter.Fill(BufTable);
            }
            catch (MySqlException E)
            {
                MessageBox.Show(E.Message);
            }
            return BufTable;
        }
        public int AnotherQuery(string query)
        {
            int rowsaffected = 0;
            try
            {
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection);
                rowsaffected = command.ExecuteNonQuery();
            }
            catch (MySqlException E)
            {
                MessageBox.Show(E.Message);
            }
            return rowsaffected;
        }
        public int TransactQuery(string query)
        {
            int rowsaffected = 0;
            try
            {
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection);
                rowsaffected = command.ExecuteNonQuery();
            }
            catch (MySqlException E)
            {
                MessageBox.Show(E.Message);
            }
            return rowsaffected;
        }
    }
}
