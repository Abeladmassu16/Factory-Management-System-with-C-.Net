using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Factory_Managemnt_System
{
    public partial class Home : Form
    {
        private const bool V = true;
        private const bool V1 = true;

        public Home(System.Windows.Forms.TextBox fNameTxtBx)
        {
            InitializeComponent();
            Chemicals chemicals;

            LoadCustomer();
            Load();
            //this.FNameTxtBx = fNameTxtBx;
        }


        public void LoadCustomer()
        {

            SqlConnection con = new DBConnection().OpenConnection();
            try
            {

                string stmt = "SELECT FirstName, LastName FROM Users WHERE Role = 'Customer'";
                SqlCommand cmd = new SqlCommand(stmt, con);

                SqlDataReader reader = cmd.ExecuteReader();
                //  OrderCustNameCobBx.Items.Clear();
                while (reader.Read())
                {

                    string username = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                    OrderCustNameCobBx.Items.Add(username);


                }


            }

            catch (Exception ex)
            {
                MessageBox.Show("Error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }

        public void LoadUser()
        {
            SqlConnection con = new DBConnection().OpenConnection();
            try
            {

                string stmt = "SELECT FirstName, LastName FROM Users";
                SqlCommand cmd = new SqlCommand(stmt, con);

                SqlDataReader reader = cmd.ExecuteReader();
                //  OrderCustNameCobBx.Items.Clear();
                while (reader.Read())
                {

                    string username = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                    OrderCustNameCobBx.Items.Add(username);


                }


            }

            catch (Exception ex)
            {
                MessageBox.Show("Error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }

        private void Load()
        {
            Chemicals chemicals = new Chemicals();
            ViewGrid.AutoGenerateColumns = true;

            DataTable dataTable = chemicals.ChemicalsInStore();

            if (dataTable != null)
            {
                ViewGrid.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void User()
        {
            Users users = new Users();
            ViewAccGridView.AutoGenerateColumns = true;

            DataTable dataTable = users.ViewAccounts();

            if (dataTable != null)
            {

                // Assuming Session.CurrentUser.Role returns the role of the logged-in user
                if (Session.CurrentUser != null && Session.CurrentUserRole == "Admin")
                {
                    // Filter out admin information from the DataTable
                    var filteredRows = dataTable.AsEnumerable().Where(row => row.Field<string>("Role") != "Admin").CopyToDataTable();
                    ViewAccGridView.DataSource = filteredRows;
                }
                else
                {
                    ViewAccGridView.DataSource = dataTable;
                }
                for (int i = 0; i < ViewAccGridView.Rows.Count; i++)
                {
                    ViewAccGridView.Rows[i].Cells[7].Value = "Delete";
                }

            }
            else
            {
                MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void HomeBtn_Click(object sender, EventArgs e)
        {
            CustViewProfilePan.Visible = false;
            //AdminEditAccPan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            ChemicalPan.Visible = false;
            HomePan.Visible = V1;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            AboutPan.Visible = false;
            ViewChemicalPan.Visible = false;
            OrderListPan.Visible = false;
            OrdersPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddChemicalPanel.Visible = false;
            AddChemical2.Visible = false;
            OrderHistPan.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OrderListPan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void innerLoginPan_Paint(Object sender, PaintEventArgs e)
        {

        }
        private void ChemicalsBtn_Click(object sender, EventArgs e)
        {
            ChemicalPan.Visible = V;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            AboutPan.Visible = false;
            // ViewAccountPan.Visible = false;
            // EditPan.Visible = false;
            //AdminEditAccPan.Visible = false;
            OrderHisPan.Visible = false;

            OrderListPan.Visible = false;
            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            OrderHistPan.Visible = false;
            AddNewPan.Visible = false;
            ViewAccBtn.Visible = false;
            OrdersPan.Visible = false;
            LeftMenuPan.Visible = true;
            AdminLftPan.Visible = false;
            AddChemicalPanel.Visible = false;
            ViewChemicalPan.Visible = false;
            CustViewProfilePan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            ChangePasspan.Visible = false;

            ViewFormula2Pan.Visible = false;
            AddChemical2.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;

        }

        private void RemaningChPan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void remainingChLbl_Click(object sender, EventArgs e)
        {

        }

        private void AddChemicalPan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductBrn_Click(object sender, EventArgs e)
        {

            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = true;
            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            AboutPan.Visible = false;
            //AdminEditAccPan.Visible = false;

            // ViewAccountPan.Visible = false;
            //  EditPan.Visible = false;
            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            AddNewPan.Visible = false;
            CustViewProfilePan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            ViewAccBtn.Visible = false;
            LeftMenuPan.Visible = true;
            OrdersPan.Visible = false;
            OrderHistPan.Visible = false;
            AdminLftPan.Visible = false;
            AddChemical2.Visible = false;
            OrderListPan.Visible = false;
            AddChemicalPanel.Visible = false;
            ViewChemicalPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;


        }

        private void FinanceBtn_Click(object sender, EventArgs e)
        {
            CustViewProfilePan.Visible = false;

            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = true;
            OrdersPan.Visible = false;
            AboutPan.Visible = false;
            //AdminEditAccPan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            // ViewAccountPan.Visible = false;
            //EditPan.Visible = false;
            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            OrderHistPan.Visible = false;
            AddNewPan.Visible = false;
            ViewAccBtn.Visible = false;
            LeftMenuPan.Visible = true;
            AdminLftPan.Visible = false;
            OrdersPan.Visible = false;
            AddChemical2.Visible = false;
            AddChemicalPanel.Visible = false;
            OrderListPan.Visible = false;
            ViewChemicalPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void OrderBtn_Click(object sender, EventArgs e)
        {
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            AboutPan.Visible = false;
            // ViewAccountPan.Visible = false;
            // EditPan.Visible = false;
            //AdminEditAccPan.Visible = false;
            ViewAccPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            CustOrderNowPan.Visible = false;
            AddNewPan.Visible = false;
            ViewAccBtn.Visible = false;
            LeftMenuPan.Visible = true;
            AdminLftPan.Visible = false;
            ViewChemicalPan.Visible = false;
            OrderListPan.Visible = false;
            AddChemicalPanel.Visible = false;
            OrdersPan.Visible = true;
            CustViewProfilePan.Visible = false;
            CustOrderPan.Visible = false;

            OrderHistPan.Visible = false;
            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            AddChemical2.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            OrderHistPan.Visible = false;
            AboutPan.Visible = true;
            OrderHistPan.Visible = false;
            //AdminEditAccPan.Visible = false;
            //ViewAccountPan.Visible = false;
            //EditPan.Visible = false;
            AddNewPan.Visible = false;
            ViewAccBtn.Visible = false;
            LeftMenuPan.Visible = true;
            OrdersPan.Visible = false;
            CustViewProfilePan.Visible = false;
            ViewAccPan.Visible = false;
            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            AdminLftPan.Visible = false;
            OrderListPan.Visible = false;
            ViewChemicalPan.Visible = false;
            AddChemical2.Visible = false;
            AddChemicalPanel.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;


        }

        private void AdminLftPan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EditAccount_Click(object sender, EventArgs e)
        {
            ViewAccPan.Visible = true;
            //AdminEditAccPan.Visible = false;
            AddNewPan.Visible = false;
            //ViewAccBtn.Visible = true;
            // ViewAccountPan.Visible = false;
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            OrderHistPan.Visible = false;
            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            MaterialsPan.Visible = false;
            CustViewProfilePan.Visible = false;
            // ViewAccPan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            OrderHistViewPan.Visible = false;
            AboutPan.Visible = false;
            OrderHistPan.Visible = false;
            LeftMenuPan.Visible = false;
            ViewChemicalPan.Visible = false;
            OrdersPan.Visible = false;
            AddChemical2.Visible = false;
            AddChemicalPanel.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;


            User();

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            // AdminEditAccPan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            //AdminEditAccPan.Visible = true;
            AddNewPan.Visible = false;
            ViewAccBtn.Visible = true;
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            OrderHistPan.Visible = false;
            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            OrderHistPan.Visible = false;
            AboutPan.Visible = false;
            CustViewProfilePan.Visible = false;
            LeftMenuPan.Visible = false;
            ViewChemicalPan.Visible = false;
            AddChemicalPanel.Visible = false;
            OrderListPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            OrdersPan.Visible = false;
            AddChemical2.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ViewAccountPan.Visible = true;
            //EditPan.Visible = false;
            //AdminEditAccPan.Visible = false;
            ViewAccPan.Visible = false;

            OrderHistPan.Visible = false;
            AddNewPan.Visible = true;
            ViewAccBtn.Visible = true;
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            CustViewProfilePan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            AboutPan.Visible = false;
            LeftMenuPan.Visible = false;
            ViewChemicalPan.Visible = false;
            AddChemical2.Visible = false;
            AddChemicalPanel.Visible = false;
            OrdersPan.Visible = false;
            OrderListPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            CustViewProfilePan.Visible = false;
            ViewAccPan.Visible = false;

            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            AboutPan.Visible = true;
            // ViewAccountPan.Visible = false;
            // EditPan.Visible = false;
            AddNewPan.Visible = false;
            //AdminEditAccPan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            LeftMenuPan.Visible = false;
            OrderHistPan.Visible = false;
            AdminLftPan.Visible = true;
            ViewChemicalPan.Visible = false;
            AddChemical2.Visible = false;
            OrderListPan.Visible = false;
            AddChemicalPanel.Visible = false;
            OrdersPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;


        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            AboutPan.Visible = false;
            // ViewAccountPan.Visible = false;
            //EditPan.Visible = false;
            OrderHistPan.Visible = false;
            AddNewPan.Visible = false;
            ViewAccBtn.Visible = false;
            LeftMenuPan.Visible = true;
            AdminLftPan.Visible = false;
            ViewChemicalPan.Visible = true;
            ViewGrid.Visible = true;
            CustViewProfilePan.Visible = false;
            //AdminEditAccPan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            //EditPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddChemical2.Visible = false;
            OrderListPan.Visible = false;
            AddChemicalPanel.Visible = false;
            OrdersPan.Visible = false;
            MaterialsPan.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;

            Load();
        }

        private void ViewChemicalPan_Paint(object sender, PaintEventArgs e)
        {
            Load();
        }

        private void ViewGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Chemicals chemicals = new Chemicals();
            // chemicals.ChemicalsInStore();
        }

        private void ViewFormula2Pan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HandWashRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection con = new DBConnection().OpenConnection();

            try
            {
                string stmt = "SELECT h.id AS ID, h.ChemicalName AS ChemicalName, h.Amount AS Amount, h.unit AS Unit, c.price AS Price, (h.Amount * c.price) AS CalculatedPrice FROM HandWash AS h JOIN Chemical AS c ON h.id = c.id;";

                using (SqlConnection connection = new DBConnection().OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(stmt, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            double totalCalculatedPrice = 0;

                            while (reader.Read())
                            {
                                totalCalculatedPrice += Convert.ToDouble(reader["CalculatedPrice"]);
                            }
                            ViewForTotPriceTxtBx.Text = totalCalculatedPrice.ToString();
                        }
                    }
                }
                Chemicals chemicals = new Chemicals();
                ViewGrid.AutoGenerateColumns = true;

                DataTable dataTable = chemicals.DishWash();

                if (dataTable != null)
                {
                    ViewFormulaGrid.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //  cmd.Parameters.AddWithValue("@chemicalId", chemicalId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }




        }
        private void DishWashRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            string stmt = "SELECT d.id AS ID, c.ChemicalName AS ChemicalName, d.Amount AS Amount, d.unit AS Unit, c.price AS Price, (d.Amount * c.price) AS CalculatedPrice FROM DishWash AS d JOIN Chemical AS c ON d.id = c.id;";

            using (SqlConnection connection = new DBConnection().OpenConnection())
            {
                using (SqlCommand command = new SqlCommand(stmt, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        double totalCalculatedPrice = 0;

                        while (reader.Read())
                        {
                            totalCalculatedPrice += Convert.ToDouble(reader["CalculatedPrice"]);
                        }
                        ViewForTotPriceTxtBx.Text = totalCalculatedPrice.ToString();
                    }
                }
            }
            Chemicals chemicals = new Chemicals();
            ViewGrid.AutoGenerateColumns = true;

            DataTable dataTable = chemicals.DishWash();

            if (dataTable != null)
            {
                ViewFormulaGrid.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LaunderyRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            string stmt = "SELECT l.id AS ID, c.ChemicalName AS ChemicalName, l.Amount AS Amount, l.unit AS Unit, c.price AS Price, (l.Amount * c.price) AS CalculatedPrice FROM LaunderySoap AS l JOIN Chemical AS c ON l.id = c.id;";

            using (SqlConnection connection = new DBConnection().OpenConnection())
            {
                using (SqlCommand command = new SqlCommand(stmt, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        double totalCalculatedPrice = 0;

                        while (reader.Read())
                        {
                            totalCalculatedPrice += Convert.ToDouble(reader["CalculatedPrice"]);
                        }
                        ViewForTotPriceTxtBx.Text = totalCalculatedPrice.ToString();
                    }
                }
            }
            Chemicals chemicals = new Chemicals();
            ViewGrid.AutoGenerateColumns = true;

            DataTable dataTable = chemicals.LaunderySoap();

            if (dataTable != null)
            {
                ViewFormulaGrid.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            AboutPan.Visible = false;
            // ViewAccountPan.Visible = false;
            // EditPan.Visible = false;
            AddNewPan.Visible = false;
            ViewAccBtn.Visible = false;
            LeftMenuPan.Visible = true;
            CustViewProfilePan.Visible = false;
            //AdminEditAccPan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            AdminLftPan.Visible = false;
            OrderHistPan.Visible = false;
            ViewChemicalPan.Visible = false;
            ViewGrid.Visible = false;
            //EditPan.Visible = false;
            ViewFormula2Pan.Visible = true;
            OrderListPan.Visible = false;
            AddChemical2.Visible = false;
            AddChemicalPanel.Visible = false;
            OrdersPan.Visible = false;
            MaterialsPan.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            AboutPan.Visible = false;
            // ViewAccountPan.Visible = false;
            // EditPan.Visible = false;
            AddNewPan.Visible = false;
            ViewAccBtn.Visible = false;
            LeftMenuPan.Visible = true;
            AdminLftPan.Visible = false;
            OrderHistPan.Visible = false;
            ViewChemicalPan.Visible = false;
            CustViewProfilePan.Visible = false;
            //AdminEditAccPan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            ViewGrid.Visible = false;
            //EditPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddChemical2.Visible = false;
            OrdersPan.Visible = false;
            OrderListPan.Visible = false;
            AddChemicalPanel.Visible = true;
            AddProucts.Visible = false;
            MaterialsPan.Visible = false;
            ViewProductsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;


        }

        private void AddChemicalBtn_Click(object sender, EventArgs e)
        {
            string ChemicalName = ChemcialNameTxtBx1.Text;
            string Amount = AmountTxtBx1.Text;
            string unit = UnitComBx.Text;
            Chemicals chemicals = new Chemicals();
            chemicals.AddChemicalToDatabase(ChemicalName, Amount, unit);
            ChemcialNameTxtBx1.Text = "";
            AmountTxtBx1.Text = "";
            UnitComBx.Text = "";

        }

        private void TypeLbl_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int id = int.Parse(HIddenIdTxtBx.Text);
            string type = TypeChbx.Text;
            string size = SizeCombBx.Text;
            int quantity = int.Parse(QuantitiyCombBx.Text);
            Order order = new Order();
            order.Orders(id, type, size, quantity);
        }
        private void label4_Click(object sender, EventArgs e)
        {
            if (OrderTypeComcBx.Text == "Laundery") { }
        }

        private void TypeChbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeChbx.Text == "Laundery Soap")
            {
                SizeCombBx.Items.Clear();
                SizeCombBx.Items.Add("1 LT");
                SizeCombBx.Items.Add("2 LT");
                SizeCombBx.Items.Add("5 LT");
            }
            else if (TypeChbx.Text == "Dish Wash")
            {
                SizeCombBx.Items.Clear();
                SizeCombBx.Items.Add("800 ML");
                SizeCombBx.Items.Add("5 LT");
            }
            else if (TypeChbx.Text == "Hand Wash")
            {
                SizeCombBx.Items.Clear();
                SizeCombBx.Items.Add("500 ML");
                SizeCombBx.Items.Add("5 LT");

            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            AboutPan.Visible = false;
            //ViewAccountPan.Visible = false;
            // EditPan.Visible = false;
            AddNewPan.Visible = false;
            ViewAccBtn.Visible = false;
            LeftMenuPan.Visible = true;
            AdminLftPan.Visible = false;
            OrderHistPan.Visible = true;
            ViewChemicalPan.Visible = false;
            CustViewProfilePan.Visible = false;
            //AdminEditAccPan.Visible = false;
            CustOrderPan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            ViewGrid.Visible = false;
            // EditPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddChemical2.Visible = false;
            OrdersPan.Visible = false;
            OrderListPan.Visible = false;
            MaterialsPan.Visible = false;
            AddChemicalPanel.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;

            Users user = new Users();
            HiddenTxtBX.Text = user.selectId().ToString(); ;


        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            TypeChbx.Text = string.Empty;
            SizeCombBx.Text = string.Empty;
            QuantitiyCombBx.Text = string.Empty;
            //TotalPriceTxtBx.Text = string.Empty;
        }

        private void ViewProdBtn_Click(object sender, EventArgs e)
        {
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            AboutPan.Visible = false;
            // ViewAccountPan.Visible = false;
            // EditPan.Visible = false;
            AddNewPan.Visible = false;
            ViewAccBtn.Visible = false;
            LeftMenuPan.Visible = true;
            AdminLftPan.Visible = false;
            OrderHistPan.Visible = false;
            ViewChemicalPan.Visible = false;
            ViewGrid.Visible = false;
            CustViewProfilePan.Visible = false;
            //AdminEditAccPan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            // EditPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddChemical2.Visible = false;
            OrdersPan.Visible = false;
            OrderListPan.Visible = false;
            AddChemicalPanel.Visible = false;
            MaterialsPan.Visible = true;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;


            Products prodcuts = new Products();
            ViewGrid.AutoGenerateColumns = true;

            DataTable dataTable = prodcuts.MaterialInStore();

            if (dataTable != null)
            {
                MaterialGrV.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProdTypeCombBx.Text == "Laundery")
            {
                ProdFillCombBx.Items.Clear();
                ProdFillCombBx.Items.Add("1LT");
                ProdFillCombBx.Items.Add("2LT");
                ProdFillCombBx.Items.Add("5LT");
            }
            else if (ProdTypeCombBx.Text == "Dish Wash")
            {
                ProdFillCombBx.Items.Clear();
                ProdFillCombBx.Items.Add("800ML");
                ProdFillCombBx.Items.Add("5LT");
            }
            else if (ProdTypeCombBx.Text == "Hand Wash")
            {
                ProdFillCombBx.Items.Clear();
                ProdFillCombBx.Items.Add("500ML");
                ProdFillCombBx.Items.Add("5LT");

            }
        }

        public Double Filled()
        {
            Double amount = int.Parse(ProdAmountTxtBx1.Text);
            if (ProdFillCombBx.Text == "1LT")
            {
                amount = amount / 1;
                ProdQuanTxtBx1.Text = amount.ToString();

                // return amount;
            }
            else if (ProdFillCombBx.Text == "2LT")
            {
                amount = amount / 2;
                ProdQuanTxtBx1.Text = amount.ToString();
                //return amount;
            }
            else if (ProdFillCombBx.Text == "5LT")
            {
                amount = amount / 5;
                ProdQuanTxtBx1.Text = amount.ToString();
            }
            else if (ProdFillCombBx.Text == "800ML")
            {
                amount = amount / 0.800;
                ProdQuanTxtBx1.Text = amount.ToString();

            }
            else if (ProdFillCombBx.Text == "500ML")
            {
                amount = amount / 0.500;
                ProdQuanTxtBx1.Text = amount.ToString();
            }
            return amount;
        }
        private void ProdFillCombBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    
            //    Dish Wash
            //    Hand Wash
            Filled();
            if (ProdTypeCombBx.Text == "Laundery")
            {
                LaunderyRadBtn.Select();
                double FormulaPrice = double.Parse(ViewForTotPriceTxtBx.Text);
                SqlConnection con = new DBConnection().OpenConnection();
                string selectQuery = "SELECT Price FROM Materials WHERE BottleName = 'laundery' and Amount = @amount ";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, con))
                {
                    selectCommand.Parameters.AddWithValue("@amount", ProdFillCombBx.Text);
                    double currentQuantity = Convert.ToDouble(selectCommand.ExecuteScalar());
                    double Total = (FormulaPrice + currentQuantity) * Filled();
                    AddProdTotprTxtBx.Text = Total.ToString();
                }
            }
        }

        private void ProdQuanTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProdManBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new DBConnection().OpenConnection())
            {
                // Insert new product
                int id = int.Parse(ProdIdtxtBx.Text);
                string name = ProdTypeCombBx.Text;
                string amount = ProdAmountTxtBx.Text;
                string filled = ProdFillCombBx.Text;
                int quan = int.Parse(ProdQuanTxtBx.Text);

                Products products = new Products();
                products.NewProduct(id, name, amount, filled, quan);
                ProdIdtxtBx.Text = "";
                ProdQuanTxtBx.Text = "";
                ProdTypeCombBx.Text = "";
                ProdFillCombBx.Text = "";
                AddProdTotprTxtBx.Text = "";
                ProdAmountTxtBx.Text = "";
                con.Close();


                // Fetch the current quantity from the Materials table
                string selectQuery = "SELECT Quantity FROM Materials WHERE BottleName = @Name AND Amount = @Amount";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, con))
                {
                    selectCommand.Parameters.AddWithValue("@Amount", filled);
                    selectCommand.Parameters.AddWithValue("@Name", name);

                    con.Open();
                    int currentQuantity = Convert.ToInt32(selectCommand.ExecuteScalar());

                    // Calculate the new quantity after subtracting the quantity from Product
                    int updatedQuantity = currentQuantity - quan;
                    // Update the Materials table with the new quantity
                    string updateQuery = "UPDATE Materials SET Quantity = @UpdatedQuantity WHERE BottleName = @Name AND Amount =@Amount";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, con))
                    {
                        updateCommand.Parameters.AddWithValue("@Amount", filled);
                        updateCommand.Parameters.AddWithValue("@Name", name);
                        updateCommand.Parameters.AddWithValue("@UpdatedQuantity", updatedQuantity);

                        updateCommand.ExecuteNonQuery();
                    }

                }
            } // The 'using' statement will automatically close the connection when it's done.

        }

        private void AddProucts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProduceBtn_Click(object sender, EventArgs e)
        {
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            AboutPan.Visible = false;
            // ViewAccountPan.Visible = false;
            //  EditPan.Visible = false;
            AddNewPan.Visible = false;
            ViewAccBtn.Visible = false;
            LeftMenuPan.Visible = true;
            AdminLftPan.Visible = false;
            OrderHistPan.Visible = false;
            CustViewProfilePan.Visible = false;
            //AdminEditAccPan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            ViewChemicalPan.Visible = false;
            ViewGrid.Visible = false;
            // EditPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddChemical2.Visible = false;
            OrdersPan.Visible = false;
            OrderListPan.Visible = false;
            AddChemicalPanel.Visible = false;
            MaterialsPan.Visible = false;
            AddProucts.Visible = true;
            ViewProductsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;

        }

        private void button7_Click_1(object sender, EventArgs e)
        {

            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            AboutPan.Visible = false;
            ChangePasspan.Visible = false;

            // ViewAccountPan.Visible = false;
            //  EditPan.Visible = false;
            AddNewPan.Visible = false;
            ViewAccBtn.Visible = false;
            LeftMenuPan.Visible = true;
            AdminLftPan.Visible = false;
            OrderHistPan.Visible = false;
            ViewChemicalPan.Visible = false;
            ViewGrid.Visible = false;
            // EditPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddChemical2.Visible = false;
            OrdersPan.Visible = false;
            CustViewProfilePan.Visible = false;
            //AdminEditAccPan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;

            OrderListPan.Visible = false;
            AddChemicalPanel.Visible = false;
            MaterialsPan.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = true;
            OrderHistViewPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;


            Products prodcuts = new Products();
            ViewGrid.AutoGenerateColumns = true;

            DataTable dataTable = prodcuts.ViewProducts();

            if (dataTable != null)
            {
                ViewProdGrid.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewFormulaGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProdAmountTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        private void SizeCombBx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCustomer();

            if (OrderCustNameCobBx.SelectedItem != null)
            {
                SqlConnection con = new DBConnection().OpenConnection();
                string name = OrderCustNameCobBx.Text;

                try
                {
                    string stmt = "SELECT Id FROM Users WHERE FirstName + ' ' + LastName = @name";
                    SqlCommand cmd = new SqlCommand(stmt, con);
                    cmd.Parameters.AddWithValue("@name", name);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int customerId = Convert.ToInt32(reader["Id"]);

                        HIddenIdTxtBx.Text = customerId.ToString();
                    }
                    else
                    {
                        // No matching record found
                        MessageBox.Show("Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }


            // HIddenIdTxtBx.Text = LoadCustomer()id.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            AboutPan.Visible = false;
            // ViewAccountPan.Visible = false;
            //  EditPan.Visible = false;
            OrderListPan.Visible = false;
            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = true;
            OrderHistPan.Visible = false;
            AddNewPan.Visible = false;
            OrdersPan.Visible = false;
            LeftMenuPan.Visible = true;
            AdminLftPan.Visible = false;
            AddChemicalPanel.Visible = false;
            ViewChemicalPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            CustViewProfilePan.Visible = false;
            //AdminEditAccPan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            AddChemical2.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;


            Order order = new Order();
            ViewGrid.AutoGenerateColumns = true;

            DataTable dataTable = order.OrderHistory();

            if (dataTable != null)
            {
                ViewOrderHistGrid.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PasswordTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Login(UserNameTxtBx.Text, PasswordTxtBx.Text);
            if (users.Status == "A" && users.Role == UserRole.Manager)
            {
                Session.StartSession(UserNameTxtBx.Text, "Manager");
                if (Session.CurrentUser != null && Session.CurrentUserRole == "Manager")
                {
                    this.Text = "Manager Pan";

                    CustomerLftPan.Visible = false;
                    ChemicalPan.Visible = false;
                    HomePan.Visible = true;
                    ProductPan.Visible = false;
                    FinancePan.Visible = false;
                    OrdersPan.Visible = false;
                    AboutPan.Visible = false;
                    // ViewAccountPan.Visible = false;
                    // EditPan.Visible = false;
                    //AdminEditAccPan.Visible = false;
                    ViewAccPan.Visible = false;
                    CustOrderPan.Visible = false;
                    CustOrderNowPan.Visible = false;
                    OrderHisPan.Visible = false;
                    ChangePasspan.Visible = false;

                    OrderListPan.Visible = false;
                    MaterialsPan.Visible = false;
                    CustViewProfilePan.Visible = false;
                    OrderHistViewPan.Visible = false;
                    OrderHistPan.Visible = false;
                    AddNewPan.Visible = false;
                    OrdersPan.Visible = false;
                    LeftMenuPan.Visible = true;
                    AdminLftPan.Visible = false;
                    AddChemicalPanel.Visible = false;
                    ViewChemicalPan.Visible = false;
                    ViewFormula2Pan.Visible = false;
                    AddChemical2.Visible = false;
                    AddProucts.Visible = false;
                    ViewProductsPan.Visible = false;
                    LoginPan.Visible = false;
                    AddMaterialsPan.Visible = false;
                }
            }
            else if (users.Status == "A" && users.Role == UserRole.Admin)
            {
                Session.StartSession(UserNameTxtBx.Text, "Admin");
                if (Session.CurrentUser != null && Session.CurrentUserRole == "Admin")
                {
                    this.Text = "Admin Page";
                    CustOrderPan.Visible = false;
                    CustOrderNowPan.Visible = false;
                    OrderHisPan.Visible = false;
                    ChangePasspan.Visible = false;

                    ChemicalPan.Visible = false;
                    CustomerLftPan.Visible = false;
                    HomePan.Visible = false;
                    ProductPan.Visible = false;
                    FinancePan.Visible = false;
                    OrdersPan.Visible = false;
                    AboutPan.Visible = false;
                    // ViewAccountPan.Visible = false;
                    // EditPan.Visible = false;
                    OrderListPan.Visible = false;
                    CustViewProfilePan.Visible = false;
                    MaterialsPan.Visible = false;
                    OrderHistViewPan.Visible = false;
                    OrderHistPan.Visible = false;
                    AddNewPan.Visible = false;
                    OrdersPan.Visible = false;
                    LeftMenuPan.Visible = false;
                    AdminLftPan.Visible = true;
                    AddChemicalPanel.Visible = false;
                    ViewChemicalPan.Visible = false;
                    ViewFormula2Pan.Visible = false;
                    AddChemical2.Visible = false;
                    AddProucts.Visible = false;
                    ViewProductsPan.Visible = false;
                    LoginPan.Visible = false;
                    AddMaterialsPan.Visible = false;
                    ViewAccPan.Visible = false;

                    User();

                }
            }
            else if (users.Status == "A" && users.Role == UserRole.Customer)
            {
                Session.StartSession(UserNameTxtBx.Text, "Customer");
                if (Session.CurrentUser != null && Session.CurrentUserRole == "Customer")
                {
                    this.Text = "Customer Page";
                    // ProfileBtn.Click += ProfileBtn_Click;
                    CustomerLftPan.Visible = true;
                    ChemicalPan.Visible = false;
                    HomePan.Visible = false;
                    ProductPan.Visible = false;
                    FinancePan.Visible = false;
                    OrdersPan.Visible = false;
                    AboutPan.Visible = false;
                    //ViewAccountPan.Visible = false;
                    //EditPan.Visible = false;
                    //AdminEditAccPan.Visible = false;
                    ViewAccPan.Visible = false;
                    CustOrderPan.Visible = false;
                    CustOrderNowPan.Visible = false;
                    OrderHisPan.Visible = false;
                    ChangePasspan.Visible = false;
                    OrderListPan.Visible = false;
                    MaterialsPan.Visible = false;
                    OrderHistViewPan.Visible = false;
                    OrderHistPan.Visible = false;
                    AddNewPan.Visible = false;
                    OrdersPan.Visible = false;
                    CustViewProfilePan.Visible = true;
                    LeftMenuPan.Visible = false;
                    AdminLftPan.Visible = false;
                    AddChemicalPanel.Visible = false;
                    ViewChemicalPan.Visible = false;
                    ViewFormula2Pan.Visible = false;
                    AddChemical2.Visible = false;
                    AddProucts.Visible = false;
                    ViewProductsPan.Visible = false;
                    LoginPan.Visible = false;
                    AddMaterialsPan.Visible = false;
                }
            }
            else if (users.Status == "D")
            {
                LoginWrongLbl.Text = "Account Deactivated";
            }
            else
            {
                LoginWrongLbl.Text = "Wrong Username or Password";
            }
        }

        private void UserNameTxtBx_TextChanged(object sender, EventArgs e)
        {
            LoginWrongLbl.Text = "";
        }

        private void TotalPriceTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        private void QuantitiyCombBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            Users users = new Users();

            SqlDataReader resualt = null;
            SqlConnection con = new DBConnection().OpenConnection();
            //double price;
            string Amount = SizeCombBx.Text;
            HandWashRadBtn.Select();

            double formulaPrice = double.Parse(ViewForTotPriceTxtBx.Text) + users.PriceAmonut(SizeCombBx.Text);
            double quanitity = double.Parse(QuantitiyCombBx.Text);
            double totalPrice = formulaPrice * quanitity;
            double percent = totalPrice + totalPrice / 100 * 100;
            TotalPriceTxtBx1.Text = percent.ToString();



        }

        private void AddMaterialBtn_Click(object sender, EventArgs e)
        {
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            AboutPan.Visible = false;
            //ViewAccountPan.Visible = false;
            // EditPan.Visible = false;
            //AdminEditAccPan.Visible = false;
            //CreateAccPan.Visible = false;   
            OrderListPan.Visible = false;
            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            OrderHistPan.Visible = false;
            AddNewPan.Visible = false;
            OrdersPan.Visible = false;
            CustViewProfilePan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            LeftMenuPan.Visible = true;
            AdminLftPan.Visible = false;
            AddChemicalPanel.Visible = false;
            ViewChemicalPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddChemical2.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = true;
        }

        private void AddMatSizeLbl_Click(object sender, EventArgs e)
        {

        }

        private void AddMatTypeLbl_Click(object sender, EventArgs e)
        {

        }

        private void AddMatBuyBtn_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            double quantity = double.Parse(MatQuanTxtBx.Text);
            double price = double.Parse(MatUnitPriceTxtBx.Text);
            products.AddMaterials(AddMatTypeTxtBx.Text, AddMatSizeTxtBx.Text, quantity, price);
            AddMatTypeTxtBx.Text = string.Empty;
            AddMatSizeTxtBx.Text = string.Empty;
            MatUnitPriceTxtBx.Text = string.Empty;
            MatQuanTxtBx.Text = string.Empty;
            MatTotalPriceTxt.Text = string.Empty;
        }

        private void AddMatUnitPriceTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(AddMatQuanTxtBx.Text, out double quantity)
                && double.TryParse(AddMatUnitPriceTxtBx.Text, out double price))
            {
                double totalPrice = quantity * price;
                AddMatTotalPriceTxtBx.Text = totalPrice.ToString();
            }
            else
            {

            }

        }

        private void AddMatTypeTxtBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AddMatTypeTxtBx.Text == "Laundery")
            {
                AddMatSizeTxtBx.Items.Clear();
                AddMatSizeTxtBx.Items.Add("1LT");
                AddMatSizeTxtBx.Items.Add("2LT");
                AddMatSizeTxtBx.Items.Add("5LT");
            }
            else if (AddMatTypeTxtBx.Text == "Dish Wash")
            {
                AddMatSizeTxtBx.Items.Clear();
                AddMatSizeTxtBx.Items.Add("800ML");
                AddMatSizeTxtBx.Items.Add("5LT");
            }
            else if (AddMatTypeTxtBx.Text == "Hand Wash")
            {
                AddMatSizeTxtBx.Items.Clear();
                AddMatSizeTxtBx.Items.Add("500ML");
                AddMatSizeTxtBx.Items.Add("5LT");

            }
        }

        private void AddMatTotalPriceTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        public void LogOut()
        {
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            AboutPan.Visible = false;
            //ViewAccountPan.Visible = false;
            // EditPan.Visible = false;
            //AdminEditAccPan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            OrderListPan.Visible = false;
            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            OrderHistPan.Visible = false;
            AddNewPan.Visible = false;
            OrdersPan.Visible = false;
            LeftMenuPan.Visible = false;
            AdminLftPan.Visible = false;
            AddChemicalPanel.Visible = false;
            ViewChemicalPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddChemical2.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = true;
            CustViewProfilePan.Visible = false;
            AddMaterialsPan.Visible = false;
            UserNameTxtBx.Text = "";
            PasswordTxtBx.Text = "";
        }
        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            LogOut();
            Session.EndSession();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LogOut();
            Session.EndSession();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LogOut();
            Session.EndSession();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            CustomerLftPan.Visible = true;
            CustViewProfilePan.Visible = true;
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            AboutPan.Visible = false;
            //ViewAccountPan.Visible = false;
            //EditPan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderPan.Visible = false;
            OrderListPan.Visible = false;
            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            OrderHistPan.Visible = false;
            AddNewPan.Visible = false;
            OrdersPan.Visible = false;
            LeftMenuPan.Visible = false;
            AdminLftPan.Visible = false;
            AddChemicalPanel.Visible = false;
            ViewChemicalPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddChemical2.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;
            Session.StartSession(UserNameTxtBx.Text, "Customer  ");
            CustUsernameLbl.Text = Session.CurrentUser;
            SqlDataReader resualt = null;
            string Username = Session.CurrentUser;
            using (SqlConnection con = new DBConnection().OpenConnection())
            {
                try
                {
                    string Status;
                    string query = "Select * From Users Where UserName =@UserName";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserName", Username);
                    resualt = cmd.ExecuteReader();
                    if (resualt.HasRows)
                    {
                        while (resualt.Read())
                        {
                            //  Firstname = resualt["FirstName"].ToString();
                            //  Lastname = resualt["LastName"].ToString();
                            CustProfileFullNTxtBX.Text = resualt["FirstName"].ToString() + " " + resualt["LastName"].ToString();
                            CustProfileRoleTxtBX.Text = resualt["Role"].ToString();
                            Status = resualt["Status"].ToString().Trim();
                            if (Status == "A") { CustProfileStatusTxtBX.Text = "Active"; }
                            else if (Status == "D") { CustProfileStatusTxtBX.Text = "Deactive"; }

                        }
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }

        private void ViewAccGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                EditIdTxtBx.Enabled = false;
                EditUNameTxtBx.Enabled = false;
                if (ViewAccGridView.CurrentCell.Value != null && ViewAccGridView.CurrentCell.Value.ToString() != "Delete")
                {
                    EditIdTxtBx.Text = ViewAccGridView.CurrentRow.Cells[0].Value.ToString();
                    EditFNameTxtBx.Text = ViewAccGridView.CurrentRow.Cells[1].Value.ToString();
                    EditLnameTxtBx.Text = ViewAccGridView.CurrentRow.Cells[2].Value.ToString();
                    EditUNameTxtBx.Text = ViewAccGridView.CurrentRow.Cells[3].Value.ToString();
                    EditPassTxtBx.Text = ViewAccGridView.CurrentRow.Cells[4].Value.ToString();
                    EditStatusCombBx.Text = ViewAccGridView.CurrentRow.Cells[5].Value.ToString();
                    EditRoleCombBx.Text = ViewAccGridView.CurrentRow.Cells[6].Value.ToString();

                }
                else if ((ViewAccGridView.CurrentCell.Value) == "Delete")
                {
                    Users users = new Users();
                    if (users.DeleteUser(Convert.ToInt32(ViewAccGridView.CurrentRow.Cells[0].Value)) > 0)
                    {
                        if (MessageBox.Show("Are You Sure You want to delete this user?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Load();
                            MessageBox.Show("User Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void EditFNameTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        private void ExitUpdateBtn_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Edituser(EditIdTxtBx.Text, EditFNameTxtBx.Text,
                EditLnameTxtBx.Text, EditUNameTxtBx.Text, EditPassTxtBx.Text,
                EditStatusCombBx.Text, EditRoleCombBx.Text);
            User();
            EditIdTxtBx.Text = ""; EditFNameTxtBx.Text = "";
            EditLnameTxtBx.Text = ""; EditUNameTxtBx.Text = ""; EditPassTxtBx.Text = "";
            EditStatusCombBx.Text = ""; EditRoleCombBx.Text = "";
        }

        private void ExitClearBtn_Click(object sender, EventArgs e)
        {
            EditIdTxtBx.Text = ""; EditFNameTxtBx.Text = "";
            EditLnameTxtBx.Text = ""; EditUNameTxtBx.Text = ""; EditPassTxtBx.Text = "";
            EditStatusCombBx.Text = ""; EditRoleCombBx.Text = "";
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.AddUser(AddFnameTxtBx.Text, AddLnameTxtBx.Text, AddUnameTxtBx.Text,
                AddpassTxtBx.Text, AddStatusCombBx.Text, AddRoleCombBx.Text
                );
            AddFnameTxtBx.Text = ""; AddLnameTxtBx.Text = ""; AddUnameTxtBx.Text = "";
            AddpassTxtBx.Text = ""; AddStatusCombBx.Text = ""; AddRoleCombBx.Text = "";
        }

        private void AddLnameTxtBx_TextChanged(object sender, EventArgs e)
        {
            AddUnameTxtBx.Enabled = false;
            string UserName = AddFnameTxtBx.Text.ToLower();
            AddUnameTxtBx.Text = UserName;

        }

        private void AddClearBtn_Click(object sender, EventArgs e)
        {
            AddFnameTxtBx.Text = ""; AddLnameTxtBx.Text = ""; AddUnameTxtBx.Text = "";
            AddpassTxtBx.Text = ""; AddStatusCombBx.Text = ""; AddRoleCombBx.Text = "";
        }

        private void AddUnameTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        private void OrdersBtn_Click(object sender, EventArgs e)
        {
            CustOrderPan.Visible = true;
            CustomerLftPan.Visible = true;
            CustViewProfilePan.Visible = false;
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            AboutPan.Visible = false;
            //ViewAccountPan.Visible = false;
            //EditPan.Visible = false;
            ChangePasspan.Visible = false;

            ViewAccPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            OrderListPan.Visible = false;
            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            OrderHistPan.Visible = false;
            AddNewPan.Visible = false;
            OrdersPan.Visible = false;
            LeftMenuPan.Visible = false;
            AdminLftPan.Visible = false;
            AddChemicalPanel.Visible = false;
            ViewChemicalPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddChemical2.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;
        }

        private void CustOrderBtn_Click(object sender, EventArgs e)
        {
            OrderHisPan.Visible = false;
            ChangePasspan.Visible = false;

            CustOrderPan.Visible = false;
            CustomerLftPan.Visible = true;
            CustViewProfilePan.Visible = false;
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            AboutPan.Visible = false;
            //ViewAccountPan.Visible = false;
            //EditPan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderNowPan.Visible = true;
            OrderListPan.Visible = false;
            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            OrderHistPan.Visible = false;
            AddNewPan.Visible = false;
            OrdersPan.Visible = false;
            LeftMenuPan.Visible = false;
            AdminLftPan.Visible = false;
            AddChemicalPanel.Visible = false;
            ViewChemicalPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddChemical2.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;
            Users users = new Users();
            string name = Session.CurrentUser;
            OrderNameTxtBx.Text = name;

            int id = users.selectId();
            HiddenTxtBX.Text = id.ToString();
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OrderTypeComcBx.Text == "Laundery")
            {
                OrderSizeTxtBx.Items.Clear();
                OrderSizeTxtBx.Items.Add("1LT");
                OrderSizeTxtBx.Items.Add("2LT");
                OrderSizeTxtBx.Items.Add("5LT");
            }
            else if (OrderTypeComcBx.Text == "Dish Wash")
            {
                OrderSizeTxtBx.Items.Clear();
                OrderSizeTxtBx.Items.Add("800ML");
                OrderSizeTxtBx.Items.Add("5LT");
            }
            else if (OrderTypeComcBx.Text == "Hand Wash")
            {
                OrderSizeTxtBx.Items.Clear();
                OrderSizeTxtBx.Items.Add("500ML");
                OrderSizeTxtBx.Items.Add("5LT");

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            try
            {
                int id = Convert.ToInt32(HiddenTxtBX.Text);
                int quan = Convert.ToInt32(OrderQuanCombBx.Text);
                order.Orders(id, OrderTypeComcBx.Text, OrderSizeTxtBx.Text, quan);
                OrderTypeComcBx.Text = "";
                OrderSizeTxtBx.Text = "";
                OrderQuanCombBx.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input format. Please enter a valid integer.");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Input value is too large to be converted to an integer.");
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        private void OrderNameTxtBx_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new DBConnection().OpenConnection();
            DataTable dataTable = new DataTable();
            try
            {
                SqlDataReader resualt = null;
                string stmt = "SELECT Id FROM Users where UserName = @Uname";
                SqlCommand cmd = new SqlCommand(stmt, con);
                cmd.Parameters.AddWithValue("@Uname", Session.CurrentUser);
                resualt = cmd.ExecuteReader();
                if (resualt.HasRows)
                {
                    while (resualt.Read())
                    {
                        HiddenTxtBX.Text = resualt["Id"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CustHistBtn_Click(object sender, EventArgs e)
        {
            CustOrderPan.Visible = false;
            CustomerLftPan.Visible = true;
            CustViewProfilePan.Visible = false;
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            AboutPan.Visible = false;
            //ViewAccountPan.Visible = false;
            //EditPan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = true;
            OrderListPan.Visible = false;
            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            OrderHistPan.Visible = false;
            AddNewPan.Visible = false;
            OrdersPan.Visible = false;
            LeftMenuPan.Visible = false;
            AdminLftPan.Visible = false;
            AddChemicalPanel.Visible = false;
            ViewChemicalPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddChemical2.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;
            ChangePasspan.Visible = false;
            OrderHis();
        }
        public void OrderHis()
        {
            Order order = new Order();


            OrderHisDataGridView.AutoGenerateColumns = true;

            DataTable dataTable = order.CustomerOrder(); ;

            if (dataTable != null)
            {
                OrderHisDataGridView.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrderHisDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OrderHisDataGridView.CurrentCell.Value != null)
            {
                //int OrderId = int.Parse()
                OrderIdtxtBx.Text = OrderHisDataGridView.CurrentRow.Cells[0].Value.ToString();
                OrderHisFnameTxtBx.Text = OrderHisDataGridView.CurrentRow.Cells[1].Value.ToString();
                OrderHisLnameTxtBx.Text = OrderHisDataGridView.CurrentRow.Cells[2].Value.ToString();
                OrderHisDateTxtBx.Text = OrderHisDataGridView.CurrentRow.Cells[3].Value.ToString();
                OrderHisQuanTxtBx.Text = OrderHisDataGridView.CurrentRow.Cells[4].Value.ToString();
                OrderHisQuan.Text = OrderHisDataGridView.CurrentRow.Cells[5].Value.ToString();

                if (OrderHisDataGridView.CurrentRow.Cells[7].Value.ToString() == "Deliverd")
                {
                    OrderHisDeliverdBtn.Enabled = false;
                    OrderHisCanOrdBtn.Enabled = false;
                }
                else
                {
                    OrderHisDeliverdBtn.Enabled = true;
                    OrderHisCanOrdBtn.Enabled = true;
                }
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void OrderHisDeliverdBtn_Click(object sender, EventArgs e)
        {
            int OrderId = int.Parse(OrderIdtxtBx.Text);
            Order order = new Order();
            order.Deliverd(OrderId, "Deliverd");
            OrderHis();
        }

        private void CustProdBtn_Click(object sender, EventArgs e)
        {

        }

        private void ProfileChangePassBtn_Click(object sender, EventArgs e)
        {
            CustOrderPan.Visible = false;
            CustomerLftPan.Visible = true;
            CustViewProfilePan.Visible = false;
            ChemicalPan.Visible = false;
            HomePan.Visible = false;
            ProductPan.Visible = false;
            FinancePan.Visible = false;
            OrdersPan.Visible = false;
            AboutPan.Visible = false;
            //ViewAccountPan.Visible = false;
            //EditPan.Visible = false;
            ViewAccPan.Visible = false;
            CustOrderNowPan.Visible = false;
            OrderHisPan.Visible = false;
            OrderListPan.Visible = false;
            MaterialsPan.Visible = false;
            OrderHistViewPan.Visible = false;
            OrderHistPan.Visible = false;
            AddNewPan.Visible = false;
            OrdersPan.Visible = false;
            LeftMenuPan.Visible = false;
            AdminLftPan.Visible = false;
            AddChemicalPanel.Visible = false;
            ViewChemicalPan.Visible = false;
            ViewFormula2Pan.Visible = false;
            AddChemical2.Visible = false;
            AddProucts.Visible = false;
            ViewProductsPan.Visible = false;
            LoginPan.Visible = false;
            AddMaterialsPan.Visible = false;
            ChangePasspan.Visible = true;


        }


        private const byte PasswordChangeSuccess = 1;
        private void PassSaveBtn_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            if (PassNewTxtBx.Text == PassReEnterTxtBx.Text)
            {
                byte result = users.changePassword(PassOldTxtbx.Text, PassNewTxtBx.Text);
                if (result == PasswordChangeSuccess)
                {
                    if (MessageBox.Show("Password Changed Successfully", "Password Change", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        CustOrderPan.Visible = false;
                        CustomerLftPan.Visible = true;
                        CustViewProfilePan.Visible = true;
                        ChemicalPan.Visible = false;
                        HomePan.Visible = false;
                        ProductPan.Visible = false;
                        FinancePan.Visible = false;
                        OrdersPan.Visible = false;
                        AboutPan.Visible = false;
                        //ViewAccountPan.Visible = false;
                        //EditPan.Visible = false;
                        ViewAccPan.Visible = false;
                        CustOrderNowPan.Visible = false;
                        OrderHisPan.Visible = false;
                        OrderListPan.Visible = false;
                        MaterialsPan.Visible = false;
                        OrderHistViewPan.Visible = false;
                        OrderHistPan.Visible = false;
                        AddNewPan.Visible = false;
                        OrdersPan.Visible = false;
                        LeftMenuPan.Visible = false;
                        AdminLftPan.Visible = false;
                        AddChemicalPanel.Visible = false;
                        ViewChemicalPan.Visible = false;
                        ViewFormula2Pan.Visible = false;
                        AddChemical2.Visible = false;
                        AddProucts.Visible = false;
                        ViewProductsPan.Visible = false;
                        LoginPan.Visible = false;
                        AddMaterialsPan.Visible = false;
                        ChangePasspan.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Unable To Change Password", "Password Change", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Password doen't Match", "Password Change", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void HandWashRadBtn_CheckedChanged_1(object sender, EventArgs e)
        {
            SqlConnection con = new DBConnection().OpenConnection();

            try
            {
                string stmt = "SELECT h.id AS ID, h.ChemicalName AS ChemicalName, h.Amount AS Amount, h.unit AS Unit, c.price AS Price, (h.Amount * c.price) AS CalculatedPrice FROM HandWash AS h JOIN Chemical AS c ON h.id = c.id;";

                using (SqlConnection connection = new DBConnection().OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(stmt, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            double totalCalculatedPrice = 0;

                            while (reader.Read())
                            {
                                totalCalculatedPrice += Convert.ToDouble(reader["CalculatedPrice"]);
                            }
                            ViewForTotPriceTxtBx.Text = totalCalculatedPrice.ToString();
                        }
                    }
                }
                Chemicals chemicals = new Chemicals();
                ViewGrid.AutoGenerateColumns = true;

                DataTable dataTable = chemicals.DishWash();

                if (dataTable != null)
                {
                    ViewFormulaGrid.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //  cmd.Parameters.AddWithValue("@chemicalId", chemicalId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }



        }

        private void DishWashRadBtn_CheckedChanged_1(object sender, EventArgs e)
        {
            string stmt = "SELECT d.id AS ID, c.ChemicalName AS ChemicalName, d.Amount AS Amount, d.unit AS Unit, c.price AS Price, (d.Amount * c.price) AS CalculatedPrice FROM DishWash AS d JOIN Chemical AS c ON d.id = c.id;";

            using (SqlConnection connection = new DBConnection().OpenConnection())
            {
                using (SqlCommand command = new SqlCommand(stmt, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        double totalCalculatedPrice = 0;

                        while (reader.Read())
                        {
                            totalCalculatedPrice += Convert.ToDouble(reader["CalculatedPrice"]);
                        }
                        ViewForTotPriceTxtBx.Text = totalCalculatedPrice.ToString();
                    }
                }
            }
            Chemicals chemicals = new Chemicals();
            ViewGrid.AutoGenerateColumns = true;

            DataTable dataTable = chemicals.DishWash();

            if (dataTable != null)
            {
                ViewFormulaGrid.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LaunderyRadBtn_CheckedChanged_1(object sender, EventArgs e)
        {
            string stmt = "SELECT l.id AS ID, c.ChemicalName AS ChemicalName, l.Amount AS Amount, l.unit AS Unit, c.price AS Price, (l.Amount * c.price) AS CalculatedPrice FROM LaunderySoap AS l JOIN Chemical AS c ON l.id = c.id;";

            using (SqlConnection connection = new DBConnection().OpenConnection())
            {
                using (SqlCommand command = new SqlCommand(stmt, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        double totalCalculatedPrice = 0;

                        while (reader.Read())
                        {
                            totalCalculatedPrice += Convert.ToDouble(reader["CalculatedPrice"]);
                        }
                        ViewForTotPriceTxtBx.Text = totalCalculatedPrice.ToString();
                    }
                }
            }
            Chemicals chemicals = new Chemicals();
            ViewGrid.AutoGenerateColumns = true;

            DataTable dataTable = chemicals.LaunderySoap();

            if (dataTable != null)
            {
                ViewFormulaGrid.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProdManBtn_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new DBConnection().OpenConnection())
            {
                // Insert new product
                int id = int.Parse(ProdIdtxtBx1.Text);
                string name = ProdTypeCombBx.Text;
                string amount = ProdAmountTxtBx1.Text;
                string filled = ProdFillCombBx.Text;
                int quan = int.Parse(ProdQuanTxtBx1.Text);

                Products products = new Products();
                products.NewProduct(id, name, amount, filled, quan);
                con.Close();


                // Fetch the current quantity from the Materials table
                string selectQuery = "SELECT Quantity FROM Materials WHERE BottleName = @Name AND Amount = @Amount";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, con))
                {
                    selectCommand.Parameters.AddWithValue("@Amount", filled);
                    selectCommand.Parameters.AddWithValue("@Name", name);

                    con.Open();
                    int currentQuantity = Convert.ToInt32(selectCommand.ExecuteScalar());

                    // Calculate the new quantity after subtracting the quantity from Product

                    int updatedQuantity = currentQuantity - quan;
                    // Update the Materials table with the new quantity
                    string updateQuery = "UPDATE Materials SET Quantity = @UpdatedQuantity WHERE BottleName = @Name AND Amount =@Amount";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, con))
                    {
                        updateCommand.Parameters.AddWithValue("@Amount", filled);
                        updateCommand.Parameters.AddWithValue("@Name", name);
                        updateCommand.Parameters.AddWithValue("@UpdatedQuantity", updatedQuantity);

                        updateCommand.ExecuteNonQuery();
                    }
                    ProdIdtxtBx1.Text = "";
                    ProdTypeCombBx.Text = "";
                    ProdAmountTxtBx1.Text = "";
                    ProdFillCombBx.Text = "";
                    ProdQuanTxtBx1.Text = "";
                    AddProdTotprTxtBx1.Text = "";
                }
            }
        }

        private void ProdFillCombBx_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Filled();
            if (ProdTypeCombBx.Text == "Laundery")
            {
                LaunderyRadBtn.Select();
                double FormulaPrice = double.Parse(ViewForTotPriceTxtBx.Text);
                double Total = FormulaPrice * Filled();
                AddProdTotprTxtBx1.Text = Total.ToString();
            }
        }

        private void ProdTypeCombBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProdTypeCombBx.Text == "Laundery")
            {
                ProdFillCombBx.Items.Clear();
                ProdFillCombBx.Items.Add("1LT");
                ProdFillCombBx.Items.Add("2LT");
                ProdFillCombBx.Items.Add("5LT");
            }
            else if (ProdTypeCombBx.Text == "Dish Wash")
            {
                ProdFillCombBx.Items.Clear();
                ProdFillCombBx.Items.Add("800ML");
                ProdFillCombBx.Items.Add("5LT");
            }
            else if (ProdTypeCombBx.Text == "Hand Wash")
            {
                ProdFillCombBx.Items.Clear();
                ProdFillCombBx.Items.Add("500ML");
                ProdFillCombBx.Items.Add("5LT");

            }
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            ProdIdtxtBx1.Text = "";
            ProdTypeCombBx.Text = "";
            ProdAmountTxtBx1.Text = "";
            ProdFillCombBx.Text = "";
            ProdQuanTxtBx1.Text = "";
            AddProdTotprTxtBx1.Text = "";

        }

        private void MatUnitPriceTxtBx_TextChanged(object sender, EventArgs e)
        {
            double Quan = double.Parse(MatQuanTxtBx.Text);
            double price = double.Parse(MatUnitPriceTxtBx.Text);
            double totalPrice = Quan * price;
            MatTotalPriceTxt.Text = totalPrice.ToString();
        }

        private void OrderQuanCombBx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ViewFormulaGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (ViewFormulaGrid.CurrentCell.Value != null)
            {
                //int OrderId = int.Parse()
                FormulaIDTxtBx.Text = ViewFormulaGrid.CurrentRow.Cells[0].Value.ToString();
                FormulaAmountTxtBx.Text = ViewFormulaGrid.CurrentRow.Cells[2].Value.ToString();
                // FormulaPriceTxtBx.Text = ViewFormulaGrid.CurrentRow.Cells[4].Value.ToString();
                //  OrderHisQuan.Text = ViewFormulaGrid.CurrentRow.Cells[5].Value.ToString();

            }
        }
        private void LoadHandWash()
        {
            Chemicals chemicals = new Chemicals();
            ViewGrid.AutoGenerateColumns = true;

            DataTable dataTable = chemicals.HandWash();

            if (dataTable != null)
            {
                ViewFormulaGrid.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Unable to retrieve data from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormulaUpdateBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(FormulaIDTxtBx.Text);
            float Amount = float.Parse(FormulaAmountTxtBx.Text);
            // double Price = double.Parse(FormulaPriceTxtBx.Text);
            Chemicals chemicals = new Chemicals();
            chemicals.UpdateHandWash(id, Amount);
            LoadHandWash();
            FormulaIDTxtBx.Text = "";
            FormulaPriceTxtBx.Text = "";
            FormulaAmountTxtBx.Text = "";

        }

        private void FormulaCancelBtn_Click(object sender, EventArgs e)
        {
            FormulaIDTxtBx.Text = "";
            FormulaPriceTxtBx.Text = "";
            FormulaAmountTxtBx.Text = "";
        }

        private void HiddenTxtBX_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewForTotPriceTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        private void OrderNameTxtBx_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            OrderTypeComcBx.Text = "";
            OrderSizeTxtBx.Text = "";
            OrderQuanCombBx.Text = "";
        }

        private void UserNameTxtBx_TextChanged_1(object sender, EventArgs e)
        {
            LoginWrongLbl.Text = "";
        }
    }
}


