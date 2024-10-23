using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace oop_lab3
{
    public partial class Form1 : Form
    {
        public int countModifiedProducts = 0;
        public int countSortedProducts = 0;
        public IEnumerable<Product> sortedDate;
        public IEnumerable<Product> sortedCountry;
        public IEnumerable<Product> sortedName;
        public IEnumerable<Product> searchedPrice;
        public IEnumerable<Product> searchedType;
        public IEnumerable<Product> searchedName;
        int sortType;
        int searchType;
        int amountObjects = 0;
        public List<Product> products = new List<Product>();
        public List<Manufactur> manufacturs = new List<Manufactur>();
        public Form1()
        {
            InitializeComponent();

            dateTimePicker1.MaxDate = DateTime.Today;
            buttonSave.Enabled = false;

            toolStripStatusLabelTime.Text = DateTime.Now.ToLongTimeString();
            Timer timer;
            timer = new Timer() { Interval = 1000 };
            timer.Tick += timerTick;
            timer.Start();
            toolStripStatusLabelProducts.Text = amountObjects.ToString();
        }
        void timerTick(object sender, EventArgs e)
        {
            toolStripStatusLabelTime.Text = DateTime.Now.ToLongTimeString();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label10.Text = String.Format("Текущее значение: {0}", trackBar1.Value);
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            XmlDocument xdoc = new XmlDocument();

            xdoc.Load("manufactur.xml");

            XmlElement xRoot = xdoc.DocumentElement;

            XmlNode manufactur = xRoot.LastChild;

            StringBuilder outputLine1 = new StringBuilder();
            StringBuilder outputLine2 = new StringBuilder();
            StringBuilder outputLine3 = new StringBuilder();
            StringBuilder outputLine4 = new StringBuilder();

            string name;
            string id;
            decimal size;
            string weight;
            string type;
            int price;
            string date;
            int quantity;
            try
            {
                if (textBox1.Text.Length < 4)
                    throw new Exception("Название должно иметь больше 3 символов");
                else
                    name = textBox1.Text;
                id = textBox2.Text;
                if (numericUpDown1.Value == 0)
                    throw new Exception("Размер должен быть > 0");
                else
                    size = numericUpDown1.Value;
                if (radioButton1.Checked)
                    weight = radioButton1.Text;
                else   weight = radioButton2.Text;
                type = listBox1.Text;
                price = int.Parse(textBox5.Text);
                date = dateTimePicker1.Text;
                if (trackBar1.Value == 0)
                    throw new Exception("Количество должен быть > 0");
                else
                    quantity = trackBar1.Value;

                foreach (XmlElement element in manufactur)
                {
                    if (element.Name == "name")
                    { outputLine1.AppendLine($"{element.InnerText}"); }

                    if (element.Name == "address")
                    { outputLine2.AppendLine($"{element.InnerText}"); }

                    if (element.Name == "country")
                    { outputLine3.AppendLine($"{element.InnerText}"); }

                    if (element.Name == "phone")
                    { outputLine4.AppendLine($"{element.InnerText}"); }
                }

                string mname = outputLine1.ToString();
                string address = outputLine2.ToString();
                string country = outputLine3.ToString();
                string phone = outputLine4.ToString();


                    Product product = new Product(name, id, size, weight, type, price, date, quantity, mname, address, country, phone);

                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace((numericUpDown1.Value).ToString()) ||
                    string.IsNullOrWhiteSpace((radioButton1.Checked).ToString()) || string.IsNullOrWhiteSpace((radioButton2.Checked).ToString())
                    || string.IsNullOrWhiteSpace(listBox1.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(dateTimePicker1.Text) ||
                    string.IsNullOrWhiteSpace((trackBar1.Value).ToString()) || trackBar1.Value == 0 || numericUpDown1.Value == 0 || textBox1.Text.Length < 4)
                { 
                    MessageBox.Show($"Данные не записаны в файл \"product.xml\""); 
                }
                else
                {
                    MessageBox.Show($"Данные записаны в файл \"product.xml\"");
                    products.Add(product);
                    XmlSerializeWrapper.Serialize(products, "product.xml");
                    amountObjects++;
                    toolStripStatusLabelProducts.Text = amountObjects.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void buttonOutputInfo_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xdoc = new XmlDocument();

                xdoc.Load("product.xml");

                XmlElement xRoot = xdoc.DocumentElement;

                XmlNode manufactur = xRoot.LastChild;

                StringBuilder outputLine = new StringBuilder();
                if (string.IsNullOrWhiteSpace(textBox1.Text) != true && string.IsNullOrWhiteSpace(textBox2.Text) != true && string.IsNullOrWhiteSpace((numericUpDown1.Value).ToString()) != true
                    && string.IsNullOrWhiteSpace((radioButton1.Checked).ToString()) != true && string.IsNullOrWhiteSpace((radioButton2.Checked).ToString()) != true
                    && string.IsNullOrWhiteSpace(listBox1.Text) != true && string.IsNullOrWhiteSpace(textBox5.Text) != true && string.IsNullOrWhiteSpace(dateTimePicker1.Text) != true
                    && string.IsNullOrWhiteSpace((trackBar1.Value).ToString()) != true && trackBar1.Value != 0 && numericUpDown1.Value != 0 && File.Exists("product.xml") == true)
                {
                    outputLine.AppendLine(label1.Text + ": " + textBox1.Text);
                    outputLine.AppendLine(label2.Text + ": " + textBox2.Text);
                    outputLine.AppendLine(label3.Text + ": " + numericUpDown1.Value);
                    bool isChecked = radioButton1.Checked;
                    if (isChecked == true)
                        outputLine.AppendLine(label4.Text + ": " + radioButton1.Text);
                    else
                        outputLine.AppendLine(label4.Text + ": " + radioButton2.Text);
                    outputLine.AppendLine(label5.Text + ": " + listBox1.Text);
                    outputLine.AppendLine(label8.Text + ": " + textBox5.Text);
                    outputLine.AppendLine(label6.Text + ": " + dateTimePicker1.Text);
                    outputLine.AppendLine(label7.Text + ": " + trackBar1.Value);

                    foreach (XmlElement element in manufactur)
                    {
                        if (element.Name == "mname")
                        { outputLine.AppendLine($"Производитель: {element.InnerText}"); }

                        if (element.Name == "address")
                        { outputLine.AppendLine($"Адрес: {element.InnerText}"); }

                        if (element.Name == "country")
                        { outputLine.AppendLine($"Страна: {element.InnerText}"); }

                        if (element.Name == "phone")
                        { outputLine.AppendLine($"Телефон: {element.InnerText}"); }
                    }

                    textBox4.Text = outputLine.ToString();
                    toolStripStatusLabelAction.Text = "Вывод из файла";
                }
                else MessageBox.Show("Пусто!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

/*        private void button2_Click(object sender, EventArgs e)
        {
            Form2 manufactur = new Form2();
            manufactur.Show();
        }*/

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //значение символа, который будет нажат
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && e.KeyChar != 8 && e.KeyChar != 32)
            {
                //событие обработано
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && e.KeyChar != 8 && e.KeyChar != 32 && !Regex.Match(Symbol, @"[0-9]").Success)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[0-9]").Success && e.KeyChar != 8 && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder manufacturInfo = new StringBuilder();

                XmlDocument xdoc = new XmlDocument();

                xdoc.Load("manufactur.xml");

                XmlElement xRoot = xdoc.DocumentElement;

                XmlNode manufactur = xRoot.LastChild;

                foreach (XmlElement element in manufactur)
                {
                    if (element.Name == "name")
                    { manufacturInfo.AppendLine($"Организация: {element.InnerText}"); }

                    if (element.Name == "address")
                    { manufacturInfo.AppendLine($"Адрес: {element.InnerText}"); }

                    if (element.Name == "country")
                    { manufacturInfo.AppendLine($"Страна: {element.InnerText}"); }

                    if (element.Name == "phone")
                    { manufacturInfo.AppendLine($"Телефон: {element.InnerText}"); }
                }

                textBox6.Text = manufacturInfo.ToString();
                buttonSave.Enabled = true;
                toolStripStatusLabelAction.Text = "Вывод из файла";
            }
            catch
            {
                MessageBox.Show($"Пусто!");
            }
        }


        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Версия : 1.1\nРазработала: Процко Е.В.");
            toolStripStatusLabelAction.Text = "О программе";
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm(products, SearchType.searchName, this);
            sf.Show();
            searchType = 0;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm(products, SearchType.searchTypeP, this);
            sf.Show();
            searchType = 1;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm(products, SearchType.searchPrice, this);
            sf.Show();
            searchType = 2;
        }

        private void ToolStripMenuItem_Click11(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm(products, SearchType.searchTypePrice, this);
            sf.Show();
            searchType = 3;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            sortType = 0;
            if (products.Count < 1)
                MessageBox.Show($"Вы не сохранили ни один товар.");
            else
            {
                sortedDate = from item in products
                             orderby item.Date
                             select item;
                textBox7.Text = string.Empty;
                countSortedProducts = 0;
                foreach (var item in sortedDate)
                {
                    printSortedInfo(item);
                }
                    
                toolStripStatusLabelAction.Text = "Сортировка по дате";

            }
        }


        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            sortType = 1;
            if (products.Count < 1)
                MessageBox.Show($"Вы не сохранили ни один товар.");
            else
            {
                sortedDate = from item in products
                             orderby item.Country
                             select item;
                textBox7.Text = string.Empty;
                countSortedProducts = 0;
                foreach (var item in sortedDate)
                    printSortedInfo(item);
                toolStripStatusLabelAction.Text = "Сортировка по стране";

            }
        }


        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            sortType = 2;
            if (products.Count < 1)
                MessageBox.Show($"Вы не сохранили ни один товар.");
            else
            {
                sortedDate = from item in products
                             orderby item.Name
                             select item;
                textBox7.Text = string.Empty;
                countSortedProducts = 0;
                foreach (var item in sortedDate)
                    printSortedInfo(item);
                toolStripStatusLabelAction.Text = "Сортировка по названию";

            }
        }


        private void printSortedInfo(Product item)
        {
            countSortedProducts++;
            //var deserializeM = XmlSerializeWrapper.Deserialize<Manufactur>("manufactur.xml");
            StringBuilder outputLine = new StringBuilder();
            outputLine.AppendLine($"Товар: {countSortedProducts}");
            outputLine.AppendLine("Название: " + item.Name);
            outputLine.AppendLine("Номер: " + item.Id);
            outputLine.AppendLine("Размер: " + item.Size);
            outputLine.AppendLine("Вес: " + item.Weight);
            outputLine.AppendLine("Тип: " + item.Type);
            outputLine.AppendLine("Цена: " + item.Price);
            outputLine.AppendLine("Дата: " + item.Date);
            outputLine.AppendLine("Количество: " + item.Quantity);
            outputLine.AppendLine($"Производитель: {item.Mname}");
            outputLine.AppendLine($"Адрес: {item.Address}");
            outputLine.AppendLine($"Страна: {item.Country}");
            outputLine.AppendLine($"Телефон: {item.Phone}");
            outputLine.AppendLine("- - - - - - - - - -");
            textBox7.Text += outputLine.ToString();
        }

        private void buttonSaveManufactur_Click(object sender, EventArgs e)
        {
            string name;
            string address;
            string country;
            string phone;
            try
            {
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

        private void ToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (toolStrip1.Visible)
            {
                toolStrip1.Hide();
                ToolStripMenuItem10.Text = "Показать панель инструментов";
            }
            else
            {
                toolStrip1.Show();
                ToolStripMenuItem10.Text = "Скрыть панель инструментов";
            }
        }

        private void ToolStripMenuItemSearchName_Click(object sender, EventArgs e)
        {
            toolStripMenuItem4_Click(this, e);
        }

        private void ToolStripMenuItemSearchType_Click(object sender, EventArgs e)
        {
            toolStripMenuItem5_Click(this, e);
        }

        private void ToolStripMenuItemSearchPrice_Click(object sender, EventArgs e)
        {
            toolStripMenuItem6_Click(this, e);
        }

        private void ToolStripMenuItemSortDate_Click(object sender, EventArgs e)
        {
            toolStripMenuItem7_Click(this, e);
        }

        private void ToolStripMenuItemSortCountry_Click(object sender, EventArgs e)
        {
            toolStripMenuItem8_Click(this, e);
        }

        private void ToolStripMenuItemSortName_Click(object sender, EventArgs e)
        {
            toolStripMenuItem4_Click(this, e);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            textBoxSearched.Text = string.Empty;
            textBox7.Text = string.Empty;
            toolStripStatusLabelAction.Text = "Результаты удалены";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            numericUpDown1.Value = numericUpDown1.Minimum;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            //listBox1.Text = string.Empty;
            listBox1.ClearSelected();
            textBox5.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Today;
            trackBar1.Value = trackBar1.Minimum;
            //listBox3.Text = string.Empty;
            listBox3.ClearSelected();
            comboBox1.Text = string.Empty;
            maskedTextBox1.Text = string.Empty;
            treeView1.CollapseAll();

            toolStripStatusLabelAction.Text = "Введенные данные очищены";
        }
    }
}