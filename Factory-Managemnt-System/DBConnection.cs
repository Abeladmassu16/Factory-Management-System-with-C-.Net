using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Factory_Managemnt_System
{
     class DBConnection
    {
        private string connectionString;
        private SqlConnection connection;

       // public DBConnection() { }

        public SqlConnection OpenConnection()
        {
            try
            {
                connectionString = "Data Source=ABEL\\SQLEXPRESS;Initial Catalog=Factory-Managment-System;Integrated Security=True";
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error in Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Consider throwing an exception here to handle the error at a higher level
                throw;
            }

            return connection;
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
