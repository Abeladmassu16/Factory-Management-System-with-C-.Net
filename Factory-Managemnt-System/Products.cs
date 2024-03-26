using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Factory_Managemnt_System
{
     class Products : DBConnection
    {

        public DataTable MaterialInStore() 
        {
            SqlConnection con = new DBConnection().OpenConnection();
            DataTable dataTable = new DataTable();

            try
            {
                string stmt = "SELECT * FROM Materials";
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

        public void AddMaterials(string name, string amount, double quantity,double price)
        {
            using (SqlConnection con = new DBConnection().OpenConnection())
            {
                try
                {
                    string query = "UPDATE Materials SET  [Quantity] = @Quantity, [Price] = @Price WHERE [BottleName] = @name AND [Amount] = @amount";

                    SqlCommand cmd = new SqlCommand(query, con);
                     cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@Quantity",quantity);
                    cmd.Parameters.AddWithValue("@Price", price);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        MessageBox.Show("New Materials Added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void NewProduct(int id ,string name,string amount,string filled,int quan)
        {
            using (SqlConnection con = new DBConnection().OpenConnection())
            {
                try
                {
                    string query = "INSERT INTO Product ([batch_number],[product_name], [Amount], [FilledIn], [quantity]) VALUES (@id,@name, @amount, @filled, @quan)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@filled", filled);
                    cmd.Parameters.AddWithValue("@quan", quan);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        MessageBox.Show("New Product Added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                con.Close() ;
            }
        }
        public DataTable ViewProducts()
        {
            SqlConnection con = new DBConnection().OpenConnection();
            DataTable dataTable = new DataTable();

            try
            {
                string stmt = "SELECT * FROM Product";
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
        public void CalculateMaterial()
        {
            

        }
        
    }
}
