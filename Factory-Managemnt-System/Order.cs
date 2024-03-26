using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Factory_Managemnt_System
{
     class Order:Chemicals
    {
        public void Orders(int Id, string type, string size, int quantity)
        {
            SqlConnection con = new DBConnection().OpenConnection();
            try
            {
                string query = "INSERT INTO Orders (Id,Type,Size,Quantity,Status) VALUES (@Id, @type, @size,@quantity,'Pending')";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@size", size);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {

                    MessageBox.Show("Ordering Product Successfully Completed .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Order failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable OrderHistory()
        {
            SqlConnection con = new DBConnection().OpenConnection();
            DataTable dataTable = new DataTable();

            try
            {
                string stmt = "SELECT O.OrderID, U.FirstName, U.LastName, O.OrderDate, O.Type, O.Size, O.Quantity,O.Status " +
              "FROM Orders O " +
              "JOIN Users U ON O.Id = U.Id";
                SqlCommand cmd = new SqlCommand(stmt, con);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);  // Add this line for debugging
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                con.Close();
            }
            return dataTable;
        }
        public DataTable CustomerOrder()
        {
            SqlConnection con = new DBConnection().OpenConnection();
            DataTable dataTable = new DataTable();

            try
            {
                string stmt = "SELECT O.OrderID, U.FirstName, U.LastName, O.OrderDate, O.Type, O.Size, O.Quantity,O.Status " +
              "FROM Orders O " +
              "JOIN Users U ON O.Id = U.Id WHERE U.UserName = @Uname";
                SqlCommand cmd = new SqlCommand(stmt, con);
                cmd.Parameters.AddWithValue("@Uname", Session.CurrentUser);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);  // Add this line for debugging
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                con.Close();
            }
            return dataTable;
        }
        public void Deliverd(int Id,string status)
        {
            using (SqlConnection con = new DBConnection().OpenConnection())
            {
                try
                {
                    string query = "UPDATE Orders SET  [Status] = @status WHERE OrderID = @Id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        MessageBox.Show(" Product Deliverd .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("Record insertion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }
    }
}
