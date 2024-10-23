using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop_lab3
{
    public partial class Form2 : Form
    {

        public List<Manufactur> manufacturs = new List<Manufactur>();
        public Form2()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name;
            string address;
            string country;
            string phone;
            try
            {
                //Manufactur manufactur = new Manufactur();
                if (string.IsNullOrWhiteSpace(listBox3.Text) == true)
                    throw new Exception("Выберите производителя");
                else
                    name = listBox3.Text;

                address = comboBox1.Text;

                if (treeView1.SelectedNode == null)
                    throw new Exception("Выберите страну");
                else
                    country = treeView1.SelectedNode.Text;

                phone = maskedTextBox1.Text;

                if (string.IsNullOrWhiteSpace(listBox3.Text) != true && string.IsNullOrWhiteSpace(treeView1.SelectedNode.Text) != true
                    && string.IsNullOrWhiteSpace(comboBox1.Text) != true && maskedTextBox1.MaskFull == true)
                {
                    Manufactur manufactur = new Manufactur(name, address, country, phone);
                    manufacturs.Add(manufactur);
                    XmlSerializeWrapper.Serialize(manufacturs, "manufactur.xml");
                    MessageBox.Show($"Данные записаны в файл \"manufactur.xml\"");
                }
                else { MessageBox.Show($"Данные не записаны в файл \"manufactur.xml\""); }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null && e.Node.Nodes.Count > 0)
            {
                MessageBox.Show("only child nodes must be selected", "warning");
                treeView1.SelectedNode = e.Node.Nodes[0];
            }

        }
    }
}
