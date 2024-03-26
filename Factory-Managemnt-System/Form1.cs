using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Factory_Managemnt_System
{
    public partial class Form1 : Form
    {
        // private Chemicals chemicals;

        public Form1()
        {
            InitializeComponent();
            chemicals = new Chemicals();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayChemicalsInStore();
        }
        private void viewChemical_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ProduceBtn_Click(object sender, EventArgs e)
        {
            DisplayDishWashChemicals();
        }

        private void manufactureBtn_Click(object sender, EventArgs e)
        {
           // chemicals.DishWashProduction();
            successMessageLabel.Text = "Values updated successfully.";
        }

        private void HandWashBtn_Click(object sender, EventArgs e)
        {
            DisplayHandWashChemicals();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddChemicalPan.Visible = true;
            HomePan.Visible = false;
        }

        private void AddChemicalBtn_Click(object sender, EventArgs e)
        {
            AddChemicalToDatabase();
        }


        private void DisplayChemicalsInStore()
        {
            viewChemical.AutoGenerateColumns = true;

            DataTable dataTable = chemicals.ChemicalsInStore();

            if (dataTable != null)
            {
                viewChemical.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayDishWashChemicals()
        {
            viewChemical.AutoGenerateColumns = true;

            DataTable dataTable = chemicals.DishWash();

            if (dataTable != null)
            {
                viewChemical.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayHandWashChemicals()
        {
            viewChemical.AutoGenerateColumns = true;

            DataTable dataTable = chemicals.HandWash();

            if (dataTable != null)
            {
                viewChemical.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddChemicalToDatabase()
        {
            string name = NameTxtBx.Text;
            float amount = float.Parse(AmountTxtBX.Text);
            string unit = UnitBx.Text;

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
                        AddChemicalPan.Visible = false;
                        LoginPan.Visible = false;
                        HomePan.Visible = true;
                        DisplayChemicalsInStore();

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

        private void LaundeySoapLbl_Click(object sender, EventArgs e)
        {
            viewChemical.AutoGenerateColumns = true;

            DataTable dataTable = chemicals.LaunderySoap();

            if (dataTable != null)
            {
                viewChemical.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string user = UserNameTxtbx.Text;
            string password = PasswordTxtbx.Text;

            if (user == "natan" && password == "12345")
            {
                LoginPan.Visible = false;
                AddChemicalPan.Visible = false;
                HomePan.Visible = true;
            }
            else
            {
                LoginPan.Visible = true;
                AddChemicalPan.Visible = false;
                HomePan.Visible = false;
                MessageBox.Show("Wrong User Name and Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserNameTxtbx.Text = "";
                PasswordTxtbx.Text = "";


            }
        }

        private void DislayAmountTxtbx_TextChanged(object sender, EventArgs e)
        {
            chemicals = new Chemicals();
          //  DislayAmountTxtbx.Text = chemicals.DishWashProduction();
        }
    }
}
