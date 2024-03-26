using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Factory_Managemnt_System
{
    class Chemicals
    {
        public int ID { get; set; }
        public float SAlAS { get; set; }
        public float LABSA { get; set; }
        public float STTP { get; set; }
        public float COSTIC { get; set; }
        public float SODASH { get; set; }
        public float SALT { get; set; }
        public float SILCATE { get; set; }
        public float PERFUME { get; set; }

        public void AddChemicalToDatabase(string name,string amount ,string unit )
        {

            using (SqlConnection con = new DBConnection().OpenConnection())
            {
                try
                {
                    string query = "INSERT INTO chemical (ChemicalName, Amount, Unit) VALUES (@name, @amount, @unit)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@unit", unit);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        MessageBox.Show("Record inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            }
        }
        public DataTable ChemicalsInStore()
        {
            SqlConnection con = new DBConnection().OpenConnection();
            DataTable dataTable = new DataTable();

            try
            {
                //string stmt = "SELECT d.id AS ID, c.ChemicalName AS ChemicalName, d.Amount AS Amount, d.unit AS Unit, c.price AS Price\r\nFROM DishWash AS d\r\nJOIN Chemical AS c ON d.id = c.id;\r\n";
                
                string stmt = "SELECT * from chemical";
                Console.WriteLine("SQL Query: " + stmt);  // Add this line for debugging
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

        public DataTable DishWash()
        {
            SqlConnection con = new DBConnection().OpenConnection();
            DataTable dataTable = new DataTable();
            try
            {
                string stmt = "SELECT d.id AS ID, c.ChemicalName AS ChemicalName,  d.Amount AS Amount,\r\nd.unit AS Unit,\r\n (d.Amount * c.price) AS CalculatedPrice\r\nFROM\r\n  DishWash AS d\r\nJOIN\r\n Chemical AS c ON d.id = c.id;\r\n";
                SqlCommand cmd = new SqlCommand(stmt, con);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            return dataTable;
        }
        

        public DataTable HandWash()
        {
            SqlConnection con = new DBConnection().OpenConnection();
            DataTable dataTable = new DataTable();
            try
            {
                string stmt = "SELECT\r\n h.id AS ID,\r\n c.ChemicalName AS ChemicalName,\r\n    h.Amount AS Amount,\r\nh.unit AS Unit,\r\n (h.Amount * c.price) AS CalculatedPrice\r\nFROM\r\n  HandWash AS h\r\nJOIN\r\n Chemical AS c ON h.id = c.id;\r\n";
                SqlCommand cmd = new SqlCommand(stmt, con);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            return dataTable;

        }
        public DataTable LaunderySoap()
        {

            SqlConnection con = new DBConnection().OpenConnection();
            DataTable dataTable = new DataTable();
            try
            {
               // SELECT SUM(c.price) AS TotalPrice;
                string stmt = "SELECT\r\n l.id AS ID,\r\n c.ChemicalName AS ChemicalName,\r\n    l.Amount AS Amount,\r\nl.unit AS Unit,\r\n (l.Amount * c.price) AS CalculatedPrice\r\nFROM\r\n  LaunderySoap AS l\r\nJOIN\r\n Chemical AS c ON l.id = c.id;\r\n";
                SqlCommand cmd = new SqlCommand(stmt, con);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            return dataTable;
        }
        public void CalculatCost()
        {
            //double sum=0;
            
            //return sumAmountAndPrice;
        }
        public int DeleteChemical(int chemicalId)
        {
            SqlConnection con = new DBConnection().OpenConnection();

            try
            {
                string stmt = "DELETE FROM chemical WHERE id = @chemicalId";
                SqlCommand cmd = new SqlCommand(stmt, con);
                cmd.Parameters.AddWithValue("@chemicalId", chemicalId);

                int rowsAffected = cmd.ExecuteNonQuery();

                // Check if the deletion was successful
                if (rowsAffected > 0)
                {
                    return rowsAffected; // Return the number of rows affected
                }
                else
                {
                    // If no rows were affected, the record might not exist
                    return -1; // You can choose a specific value to indicate record not found
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Return a value indicating failure
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateHandWash(int Id,float Amount)
        {
            using (SqlConnection con = new DBConnection().OpenConnection())
            {
                try
                {
                    string query = "UPDATE HandWash SET  [Amount] = @Amount, [Price] = @price WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Amount", Amount);
                   // cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        MessageBox.Show(" Update Successfully completed .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("Update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
