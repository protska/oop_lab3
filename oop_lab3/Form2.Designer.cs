namespace oop_lab3
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Беларусь");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Россия");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Польша");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Страна", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label13 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(12, 9);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(5, 5, 120, 200);
            this.label11.Size = new System.Drawing.Size(270, 227);
            this.label11.TabIndex = 23;
            this.label11.Text = "Производитель";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 16);
            this.label12.TabIndex = 24;
            this.label12.Text = "Организация";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 16;
            this.listBox3.Items.AddRange(new object[] {
            "Производитель_1",
            "Производитель_2",
            "Производитель_3",
            "Производитель_4"});
            this.listBox3.Location = new System.Drawing.Point(25, 58);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(120, 52);
            this.listBox3.TabIndex = 25;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Адрес_1",
            "Адрес_2",
            "Адрес_3",
            "Адрес_4"});
            this.comboBox1.Location = new System.Drawing.Point(24, 139);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 16);
            this.label14.TabIndex = 28;
            this.label14.Text = "Адрес";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(151, 39);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Узел1";
            treeNode1.Text = "Беларусь";
            treeNode2.Name = "Узел2";
            treeNode2.Text = "Россия";
            treeNode3.Name = "Узел3";
            treeNode3.Text = "Польша";
            treeNode4.Name = "Узел0";
            treeNode4.Text = "Страна";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(80, 97);
            this.treeView1.TabIndex = 29;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 166);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 16);
            this.label13.TabIndex = 30;
            this.label13.Text = "Телефон";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox1.Location = new System.Drawing.Point(25, 185);
            this.maskedTextBox1.Mask = "(99) 000-00-00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox1.TabIndex = 31;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 265);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(270, 34);
            this.buttonSave.TabIndex = 32;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(382, 353);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Name = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button buttonSave;
    }
}