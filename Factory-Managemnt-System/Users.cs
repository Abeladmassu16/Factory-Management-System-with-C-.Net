using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;

namespace Factory_Managemnt_System
{
    public enum UserRole
    {
        Manager,
        Admin,
        Customer
    }

    class Users : DBConnection
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public UserRole Role { get; set; }
        public double price { get; set; }

        public double PriceAmonut(string Amount)
        {
            SqlDataReader resualt = null;
            SqlConnection con = new DBConnection().OpenConnection();
            
            try
            {
                string AccSql = "SELECT * FROM Materials WHERE BottleName = 'HandWash' And Amount = @amount";
                SqlCommand AccCmd = new SqlCommand(AccSql, con);
                AccCmd.Parameters.AddWithValue("@amount", Amount);

                resualt = AccCmd.ExecuteReader();
                if (resualt.HasRows)
                {

                    while (resualt.Read())
                    {
                        // Assign the value from the database to the price variable
                         price = double.Parse(resualt["Price"].ToString());
                        return price;
                    }
                   
                    resualt.Close();
                }
                con.Close();
                
            }
            catch (Exception dbEx)
            {
                MessageBox.Show(dbEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return price;
        }

        public int selectId()
        {
            SqlDataReader resualt = null;
            SqlConnection con = new DBConnection().OpenConnection();
           // int Id;
            try
            {

                string stmt = "SELECT Id FROM Users WHERE UserName = @user ";
                SqlCommand AccCmd = new SqlCommand(stmt, con);
                AccCmd.Parameters.AddWithValue("@user", Session.CurrentUser);

                resualt = AccCmd.ExecuteReader();
                if (resualt.HasRows)
                {

                    while (resualt.Read())
                    {

                        Id = int.Parse(resualt["Id"].ToString());
                        return Id;
                    }

                    resualt.Close();
                }
                con.Close();
            }
            catch (Exception dbEx)
            {
                MessageBox.Show(dbEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
              return Id;
        }
        public void Login(string username, string password)
        {
            SqlDataReader resualt = null;
            SqlConnection con = new DBConnection().OpenConnection();
            try
            {
                string AccSql = "SELECT * FROM Users WHERE UserName = @Username AND Password = @Password";
                SqlCommand AccCmd = new SqlCommand(AccSql, con);

                AccCmd.Parameters.AddWithValue("@Username", username);
                AccCmd.Parameters.AddWithValue("@Password", password);
                resualt = AccCmd.ExecuteReader();
                if (resualt.HasRows)
                {
                    while (resualt.Read())
                    {
                        UserName = resualt["UserName"].ToString();
                        Password = resualt["Password"].ToString();
                        Status = resualt["Status"].ToString().Trim();
                        Role = Enum.Parse<UserRole>(resualt["Role"].ToString().Trim());


                    }
                    con.Close();
                }
            }
            catch (Exception dbEx) { MessageBox.Show(dbEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        public DataTable ViewAccounts()
        {
            SqlConnection con = new DBConnection().OpenConnection();
            DataTable dataTable = new DataTable();
            try
            {
                string stmt = "SELECT * FROM Users";       
                    SqlCommand cmd = new SqlCommand(stmt, con);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                    dataTable.Columns.Add("Change", typeof(string));
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
        public int DeleteUser(int ID)
        {
            SqlConnection con = new DBConnection().OpenConnection();

            try
            {
                string stmt = "DELETE FROM Users WHERE Id = @userID";
                SqlCommand cmd = new SqlCommand(stmt, con);
                cmd.Parameters.AddWithValue("@userID", ID);

                int rowsAffected = cmd.ExecuteNonQuery();

                // Check if the deletion was successful
                if (rowsAffected > 0)
                {
                    return rowsAffected; // Return the number of rows affected
                }
                else
                {
                    return -1; 
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
        public void Edituser(string ID,string Fname,string Lname,string Uname,string Pass,string Status,string role)
        {
            string Username = Uname = Fname.ToLower();
            using (SqlConnection con = new DBConnection().OpenConnection())
            {
                try
                {
                    string query = "UPDATE Users SET  [FirstName] = @Fname, [LastName] = @Lname,[UserName] = @Uname,[Password] = @pass,[Status] = @status,[Role] = @role  WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@Fname", Fname);
                    cmd.Parameters.AddWithValue("@Lname", Lname);
                    cmd.Parameters.AddWithValue("@Uname", Username);
                    cmd.Parameters.AddWithValue("@pass", Pass);
                    cmd.Parameters.AddWithValue("@status", Status);
                    cmd.Parameters.AddWithValue("@role", role);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        MessageBox.Show("Updated Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("failed to Update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }
        public void AddUser(string Fname, string Lname, string Uname, string Pass, string Status, string role)
        {
            string Username = Uname = Fname.ToLower();
            using (SqlConnection con = new DBConnection().OpenConnection())
            {
                try
                {
                    string query = "Insert into Users ([FirstName] , [LastName] " +
                        ",[UserName] ,[Password],[Status] ,[Role])VALUES(@Fname,@Lname,@Uname,@Pass,@Status,@role)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Fname", Fname);
                    cmd.Parameters.AddWithValue("@Lname", Lname);
                    cmd.Parameters.AddWithValue("@Uname", Username);
                    cmd.Parameters.AddWithValue("@pass", Pass);
                    cmd.Parameters.AddWithValue("@status", Status);
                    cmd.Parameters.AddWithValue("@role", role);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        MessageBox.Show("Registration Successfully Completed .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("failed to Register.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }

            
        }


        public byte changePassword(string oldPass, string newPass)
        {
            if (oldPass == Password)
            {
                Password = newPass;
                try
                {
                    SqlConnection con = new DBConnection().OpenConnection();
                    string sql = string.Format($"UPDATE Users SET Password = '{Password}' WHERE UserName = '{Session.CurrentUser}'");
                    SqlCommand cmd = new SqlCommand(sql, con);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    return 1;
                }
                catch (Exception dbEx)
                {
                    MessageBox.Show(dbEx.Message, "Database Error in Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return 0;
        }






    }
}
