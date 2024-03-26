
namespace Factory_Managemnt_System
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            viewChemical = new DataGridView();
            button1 = new Button();
            DishWashR = new RadioButton();
            ProduceBtn = new Button();
            successMessageLabel = new Label();
            manufactureBtn = new Button();
            HandWashBtn = new Button();
            AddBtn = new Button();
            HomePan = new Panel();
            LaundeySoapLbl = new Button();
            DeleteBtn = new Button();
            LoginPan = new Panel();
            LoginBtn = new Button();
            PasswordLbl = new Label();
            UserNameLbl = new Label();
            PasswordTxtbx = new TextBox();
            UserNameTxtbx = new TextBox();
            AddChemicalPan = new Panel();
            UnitOfChemcialLbl = new Label();
            AmountOfChemicalLbl = new Label();
            NameOfChemcialLbl = new Label();
            UnitBx = new ComboBox();
            AmountTxtBX = new TextBox();
            NameTxtBx = new TextBox();
            AddChemicalBtn = new Button();
            DislayAmountTxtbx = new TextBox();
            ((System.ComponentModel.ISupportInitialize)viewChemical).BeginInit();
            HomePan.SuspendLayout();
            LoginPan.SuspendLayout();
            AddChemicalPan.SuspendLayout();
            SuspendLayout();
            // 
            // viewChemical
            // 
            viewChemical.AllowDrop = true;
            viewChemical.AllowUserToOrderColumns = true;
            viewChemical.BackgroundColor = SystemColors.AppWorkspace;
            viewChemical.BorderStyle = BorderStyle.Fixed3D;
            viewChemical.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewChemical.Location = new Point(13, 117);
            viewChemical.Name = "viewChemical";
            viewChemical.RowHeadersWidth = 51;
            viewChemical.RowTemplate.Height = 29;
            viewChemical.Size = new Size(583, 365);
            viewChemical.TabIndex = 0;
            viewChemical.CellContentClick += viewChemical_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(28, 19);
            button1.Name = "button1";
            button1.Size = new Size(181, 29);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DishWashR
            // 
            DishWashR.AutoSize = true;
            DishWashR.Location = new Point(274, 21);
            DishWashR.Name = "DishWashR";
            DishWashR.Size = new Size(98, 24);
            DishWashR.TabIndex = 2;
            DishWashR.TabStop = true;
            DishWashR.Text = "Dish Wash";
            DishWashR.UseVisualStyleBackColor = true;
            // 
            // ProduceBtn
            // 
            ProduceBtn.Location = new Point(458, 20);
            ProduceBtn.Name = "ProduceBtn";
            ProduceBtn.Size = new Size(94, 29);
            ProduceBtn.TabIndex = 3;
            ProduceBtn.Text = "produce";
            ProduceBtn.UseVisualStyleBackColor = true;
            ProduceBtn.Click += ProduceBtn_Click;
            // 
            // successMessageLabel
            // 
            successMessageLabel.AutoSize = true;
            successMessageLabel.Location = new Point(688, 34);
            successMessageLabel.Name = "successMessageLabel";
            successMessageLabel.Size = new Size(0, 20);
            successMessageLabel.TabIndex = 4;
            // 
            // manufactureBtn
            // 
            manufactureBtn.Location = new Point(28, 82);
            manufactureBtn.Name = "manufactureBtn";
            manufactureBtn.Size = new Size(116, 29);
            manufactureBtn.TabIndex = 5;
            manufactureBtn.Text = "manufacture";
            manufactureBtn.UseVisualStyleBackColor = true;
            manufactureBtn.Click += manufactureBtn_Click;
            // 
            // HandWashBtn
            // 
            HandWashBtn.Location = new Point(203, 82);
            HandWashBtn.Name = "HandWashBtn";
            HandWashBtn.Size = new Size(94, 29);
            HandWashBtn.TabIndex = 6;
            HandWashBtn.Text = "Hand Wash";
            HandWashBtn.UseVisualStyleBackColor = true;
            HandWashBtn.Click += HandWashBtn_Click;
            // 
            // AddBtn
            // 
            AddBtn.Location = new Point(383, 80);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(94, 29);
            AddBtn.TabIndex = 7;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = true;
            AddBtn.Click += AddBtn_Click;
            // 
            // HomePan
            // 
            HomePan.Controls.Add(DislayAmountTxtbx);
            HomePan.Controls.Add(LaundeySoapLbl);
            HomePan.Controls.Add(DeleteBtn);
            HomePan.Controls.Add(successMessageLabel);
            HomePan.Controls.Add(button1);
            HomePan.Controls.Add(AddBtn);
            HomePan.Controls.Add(viewChemical);
            HomePan.Controls.Add(manufactureBtn);
            HomePan.Controls.Add(HandWashBtn);
            HomePan.Controls.Add(DishWashR);
            HomePan.Controls.Add(ProduceBtn);
            HomePan.Location = new Point(0, -1);
            HomePan.Name = "HomePan";
            HomePan.Size = new Size(885, 498);
            HomePan.TabIndex = 8;
            // 
            // LaundeySoapLbl
            // 
            LaundeySoapLbl.Location = new Point(626, 79);
            LaundeySoapLbl.Name = "LaundeySoapLbl";
            LaundeySoapLbl.Size = new Size(122, 29);
            LaundeySoapLbl.TabIndex = 9;
            LaundeySoapLbl.Text = "Laundery Soap";
            LaundeySoapLbl.UseVisualStyleBackColor = true;
            LaundeySoapLbl.Click += LaundeySoapLbl_Click;
            // 
            // DeleteBtn
            // 
            DeleteBtn.Location = new Point(492, 80);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(94, 29);
            DeleteBtn.TabIndex = 8;
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // LoginPan
            // 
            LoginPan.Controls.Add(LoginBtn);
            LoginPan.Controls.Add(PasswordLbl);
            LoginPan.Controls.Add(UserNameLbl);
            LoginPan.Controls.Add(PasswordTxtbx);
            LoginPan.Controls.Add(UserNameTxtbx);
            LoginPan.Location = new Point(0, 0);
            LoginPan.Name = "LoginPan";
            LoginPan.Size = new Size(885, 499);
            LoginPan.TabIndex = 10;
            // 
            // LoginBtn
            // 
            LoginBtn.Location = new Point(448, 245);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(138, 29);
            LoginBtn.TabIndex = 3;
            LoginBtn.Text = "Login";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // PasswordLbl
            // 
            PasswordLbl.AutoSize = true;
            PasswordLbl.Location = new Point(291, 189);
            PasswordLbl.Name = "PasswordLbl";
            PasswordLbl.Size = new Size(70, 20);
            PasswordLbl.TabIndex = 2;
            PasswordLbl.Text = "Password";
            PasswordLbl.Click += label2_Click;
            // 
            // UserNameLbl
            // 
            UserNameLbl.AutoSize = true;
            UserNameLbl.Location = new Point(296, 151);
            UserNameLbl.Name = "UserNameLbl";
            UserNameLbl.Size = new Size(82, 20);
            UserNameLbl.TabIndex = 1;
            UserNameLbl.Text = "User Name";
            UserNameLbl.Click += label1_Click;
            // 
            // PasswordTxtbx
            // 
            PasswordTxtbx.Location = new Point(383, 182);
            PasswordTxtbx.Name = "PasswordTxtbx";
            PasswordTxtbx.PasswordChar = '*';
            PasswordTxtbx.Size = new Size(279, 27);
            PasswordTxtbx.TabIndex = 0;
            // 
            // UserNameTxtbx
            // 
            UserNameTxtbx.Location = new Point(384, 148);
            UserNameTxtbx.Name = "UserNameTxtbx";
            UserNameTxtbx.Size = new Size(278, 27);
            UserNameTxtbx.TabIndex = 0;
            // 
            // AddChemicalPan
            // 
            AddChemicalPan.Controls.Add(UnitOfChemcialLbl);
            AddChemicalPan.Controls.Add(AmountOfChemicalLbl);
            AddChemicalPan.Controls.Add(NameOfChemcialLbl);
            AddChemicalPan.Controls.Add(UnitBx);
            AddChemicalPan.Controls.Add(AmountTxtBX);
            AddChemicalPan.Controls.Add(NameTxtBx);
            AddChemicalPan.Controls.Add(AddChemicalBtn);
            AddChemicalPan.Location = new Point(0, 0);
            AddChemicalPan.Name = "AddChemicalPan";
            AddChemicalPan.Size = new Size(885, 498);
            AddChemicalPan.TabIndex = 8;
            // 
            // UnitOfChemcialLbl
            // 
            UnitOfChemcialLbl.AutoSize = true;
            UnitOfChemcialLbl.Location = new Point(626, 104);
            UnitOfChemcialLbl.Name = "UnitOfChemcialLbl";
            UnitOfChemcialLbl.Size = new Size(36, 20);
            UnitOfChemcialLbl.TabIndex = 5;
            UnitOfChemcialLbl.Text = "Unit";
            // 
            // AmountOfChemicalLbl
            // 
            AmountOfChemicalLbl.AutoSize = true;
            AmountOfChemicalLbl.Location = new Point(392, 104);
            AmountOfChemicalLbl.Name = "AmountOfChemicalLbl";
            AmountOfChemicalLbl.Size = new Size(62, 20);
            AmountOfChemicalLbl.TabIndex = 4;
            AmountOfChemicalLbl.Text = "Amount";
            // 
            // NameOfChemcialLbl
            // 
            NameOfChemcialLbl.AutoSize = true;
            NameOfChemcialLbl.Location = new Point(129, 104);
            NameOfChemcialLbl.Name = "NameOfChemcialLbl";
            NameOfChemcialLbl.Size = new Size(53, 20);
            NameOfChemcialLbl.TabIndex = 3;
            NameOfChemcialLbl.Text = "Name ";
            // 
            // UnitBx
            // 
            UnitBx.FormattingEnabled = true;
            UnitBx.Items.AddRange(new object[] { "KG", "Gram", "Litter", "ML" });
            UnitBx.Location = new Point(588, 142);
            UnitBx.Name = "UnitBx";
            UnitBx.Size = new Size(151, 28);
            UnitBx.TabIndex = 2;
            // 
            // AmountTxtBX
            // 
            AmountTxtBX.Location = new Point(338, 136);
            AmountTxtBX.Multiline = true;
            AmountTxtBX.Name = "AmountTxtBX";
            AmountTxtBX.Size = new Size(214, 34);
            AmountTxtBX.TabIndex = 1;
            // 
            // NameTxtBx
            // 
            NameTxtBx.Location = new Point(83, 136);
            NameTxtBx.Multiline = true;
            NameTxtBx.Name = "NameTxtBx";
            NameTxtBx.Size = new Size(214, 34);
            NameTxtBx.TabIndex = 1;
            // 
            // AddChemicalBtn
            // 
            AddChemicalBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            AddChemicalBtn.Location = new Point(296, 259);
            AddChemicalBtn.Name = "AddChemicalBtn";
            AddChemicalBtn.Size = new Size(223, 46);
            AddChemicalBtn.TabIndex = 0;
            AddChemicalBtn.Text = "Add";
            AddChemicalBtn.UseVisualStyleBackColor = true;
            AddChemicalBtn.Click += AddChemicalBtn_Click;
            // 
            // DislayAmountTxtbx
            // 
            DislayAmountTxtbx.Location = new Point(654, 221);
            DislayAmountTxtbx.Name = "DislayAmountTxtbx";
            DislayAmountTxtbx.Size = new Size(163, 27);
            DislayAmountTxtbx.TabIndex = 10;
            DislayAmountTxtbx.TextChanged += DislayAmountTxtbx_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 497);
            Controls.Add(HomePan);
            Controls.Add(AddChemicalPan);
            Controls.Add(LoginPan);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)viewChemical).EndInit();
            HomePan.ResumeLayout(false);
            HomePan.PerformLayout();
            LoginPan.ResumeLayout(false);
            LoginPan.PerformLayout();
            AddChemicalPan.ResumeLayout(false);
            AddChemicalPan.PerformLayout();
            ResumeLayout(false);
        }



        #endregion
        Chemicals chemicals;
        private DataGridView viewChemical;
        private Button button1;
        private RadioButton DishWashR;
        private Button ProduceBtn;
        private Label successMessageLabel;
        private Button manufactureBtn;
        private Button HandWashBtn;
        private Button AddBtn;
        private Panel HomePan;
        private Panel AddChemicalPan;
        private ComboBox UnitBx;
        private TextBox AmountTxtBX;
        private TextBox NameTxtBx;
        private Button AddChemicalBtn;
        private Label UnitOfChemcialLbl;
        private Label AmountOfChemicalLbl;
        private Label NameOfChemcialLbl;
        private Button DeleteBtn;
        private Button LaundeySoapLbl;
        private Panel LoginPan;
        private Label PasswordLbl;
        private Label UserNameLbl;
        private TextBox PasswordTxtbx;
        private TextBox UserNameTxtbx;
        private Button LoginBtn;
        private TextBox DislayAmountTxtbx;
    }
}
