using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace oop_lab3
{
    public partial class SearchForm : Form
    {
        List<Product> products = new List<Product>();
        Form1 f = new Form1();
        public SearchForm(List<Product> products, SearchType searchType, Form1 f)
        {
            InitializeComponent();
            panel1.Enabled = false;
            panel2.Enabled = false;
            panel3.Enabled = false;
            this.products = products;
            if (searchType == SearchType.searchName)
                panel1.Enabled = true;
            if (searchType == SearchType.searchTypeP)
                panel2.Enabled = true;
            if (searchType == SearchType.searchPrice)
                panel3.Enabled = true;
            if (searchType == SearchType.searchTypePrice)
                panel4.Enabled = true;
            this.f = f;
        }

        public void printInfoToOriginal(Product item)
        {
            f.countModifiedProducts++;
            StringBuilder outputLine = new StringBuilder();
            outputLine.AppendLine($"Товар {f.countModifiedProducts}");
            //
            outputLine.AppendLine("Название: " + item.Name + ";");
            outputLine.AppendLine("Номер: " + item.Id + ";");
            outputLine.AppendLine($"Размер: {item.Size};");
            outputLine.AppendLine($"Вес: {item.Weight};");
            outputLine.AppendLine($"Тип: {item.Type};");
            outputLine.AppendLine($"Цена: {item.Price};");
            outputLine.AppendLine($"Дата: {item.Date};");
            outputLine.AppendLine("Количество: " + ' ' + item.Quantity + ";");
            outputLine.AppendLine($"Производитель: {item.Mname}");
            outputLine.AppendLine($"Адрес: {item.Address}");
            outputLine.AppendLine($"Страна: {item.Country}");
            outputLine.AppendLine($"Телефон: {item.Phone}");
            outputLine.AppendLine("- - - - - - - - - -");
            f.textBoxSearched.Text += outputLine.ToString();
            MessageBox.Show($"Результат поиска добавлен на \nглавную форму под номером {f.countModifiedProducts}");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            if (textBox1.Text.Length > 3)
            {
                string productName = textBox1.Text;
                f.searchedName = from Item in products
                                 where Item.Name == productName || Regex.IsMatch(Item.Name, String.Format(@"({0})(\w*)", productName)) //Regex.IsMatch(Item.Name, @"(\w*)(*productName*)(\w*)")
                                 select Item;
                if (f.searchedName.Count() > 0)
                    foreach (var item in f.searchedName)
                    {
                        treeView1.Nodes.Add(item.TakeElementTree());
                        printInfoToOriginal(item);
                        f.toolStripStatusLabelAction.Text = "Поиск по названию";
                    }
                else
                    treeView1.Nodes.Add("Ничего не найдено!");
            }
        }

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

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            string type = comboBox1.Text;
            f.searchedType = from Item in products
                                      where Item.Type == type
                                      select Item;
            if (f.searchedType.Count() > 0)
                foreach (var item in f.searchedType)
                {
                    treeView1.Nodes.Add(item.TakeElementTree());
                    printInfoToOriginal(item);
                    f.toolStripStatusLabelAction.Text = "Поиск по типу";
                }
            else
                treeView1.Nodes.Add("Ничего не найдено!");
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            string price = comboBox2.Text;
            if (price == "до 35р")
            {
                f.searchedType = from Item in products
                                 where Item.Price < 35
                                 select Item;
                if (f.searchedType.Count() > 0)
                    foreach (var item in f.searchedType)
                    {
                        treeView1.Nodes.Add(item.TakeElementTree());
                        printInfoToOriginal(item);
                        f.toolStripStatusLabelAction.Text = "Поиск по цене";
                    }
                else
                    treeView1.Nodes.Add("Ничего не найдено!");
            }


            else if (price == "от 35р до 50р")
            {
                f.searchedType = from Item in products
                                 where (Item.Price >= 35 && Item.Price < 50)
                                 select Item;
                if (f.searchedType.Count() > 0)
                    foreach (var item in f.searchedType)
                    {
                        treeView1.Nodes.Add(item.TakeElementTree());
                        printInfoToOriginal(item);
                        f.toolStripStatusLabelAction.Text = "Поиск по цене";
                    }
                else
                    treeView1.Nodes.Add("Ничего не найдено!");
            }

            else if (price == "от 50р до 100р")
            {
                f.searchedType = from Item in products
                                 where (Item.Price >= 50 && Item.Price < 100)
                                 select Item;
                if (f.searchedType.Count() > 0)
                    foreach (var item in f.searchedType)
                    {
                        treeView1.Nodes.Add(item.TakeElementTree());
                        printInfoToOriginal(item);
                        f.toolStripStatusLabelAction.Text = "Поиск по цене";
                    }
                else
                    treeView1.Nodes.Add("Ничего не найдено!");
            }


            else if (price == "от 100р до 150р")
            {
                f.searchedType = from Item in products
                                 where Item.Price >= 100 && Item.Price <= 150
                                 select Item;
                if (f.searchedType.Count() > 0)
                    foreach (var item in f.searchedType)
                    {
                        treeView1.Nodes.Add(item.TakeElementTree());
                        printInfoToOriginal(item);
                        f.toolStripStatusLabelAction.Text = "Поиск по цене";
                    }
                else
                    treeView1.Nodes.Add("Ничего не найдено!");
            }


            else if (price == ">150р")
            {
                f.searchedType = from Item in products
                                 where Item.Price > 150
                                 select Item;
                if (f.searchedType.Count() > 0)
                    foreach (var item in f.searchedType)
                    {
                        treeView1.Nodes.Add(item.TakeElementTree());
                        printInfoToOriginal(item);
                        f.toolStripStatusLabelAction.Text = "Поиск по цене";
                    }
                else
                    treeView1.Nodes.Add("Ничего не найдено!");
            }

            else treeView1.Nodes.Add("Ничего не найдено!");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            string type = comboBox3.Text;
            string price = comboBox4.Text;
            if (price == "до 35р")
            {
                f.searchedType = from Item in products
                                 where Item.Price < 35 && Item.Type == type
                                 select Item;
                if (f.searchedType.Count() > 0)
                    foreach (var item in f.searchedType)
                    {
                        treeView1.Nodes.Add(item.TakeElementTree());
                        printInfoToOriginal(item);
                        f.toolStripStatusLabelAction.Text = "Поиск по цене";
                    }
                else
                    treeView1.Nodes.Add("Ничего не найдено!");
            }


            else if (price == "от 35р до 50р")
            {
                f.searchedType = from Item in products
                                 where (Item.Price >= 35 && Item.Price < 50 && Item.Type == type)
                                 select Item;
                if (f.searchedType.Count() > 0)
                    foreach (var item in f.searchedType)
                    {
                        treeView1.Nodes.Add(item.TakeElementTree());
                        printInfoToOriginal(item);
                        f.toolStripStatusLabelAction.Text = "Поиск по цене";
                    }
                else
                    treeView1.Nodes.Add("Ничего не найдено!");
            }

            else if (price == "от 50р до 100р")
            {
                f.searchedType = from Item in products
                                 where (Item.Price >= 50 && Item.Price < 100 && Item.Type == type)
                                 select Item;
                if (f.searchedType.Count() > 0)
                    foreach (var item in f.searchedType)
                    {
                        treeView1.Nodes.Add(item.TakeElementTree());
                        printInfoToOriginal(item);
                        f.toolStripStatusLabelAction.Text = "Поиск по цене";
                    }
                else
                    treeView1.Nodes.Add("Ничего не найдено!");
            }


            else if (price == "от 100р до 150р")
            {
                f.searchedType = from Item in products
                                 where Item.Price >= 100 && Item.Price <= 150 && Item.Type == type
                                 select Item;
                if (f.searchedType.Count() > 0)
                    foreach (var item in f.searchedType)
                    {
                        treeView1.Nodes.Add(item.TakeElementTree());
                        printInfoToOriginal(item);
                        f.toolStripStatusLabelAction.Text = "Поиск по цене";
                    }
                else
                    treeView1.Nodes.Add("Ничего не найдено!");
            }


            else if (price == ">150р")
            {
                f.searchedType = from Item in products
                                 where Item.Price > 150 && Item.Type == type
                                 select Item;
                if (f.searchedType.Count() > 0)
                    foreach (var item in f.searchedType)
                    {
                        treeView1.Nodes.Add(item.TakeElementTree());
                        printInfoToOriginal(item);
                        f.toolStripStatusLabelAction.Text = "Поиск по цене";
                    }
                else
                    treeView1.Nodes.Add("Ничего не найдено!");
            }

            else treeView1.Nodes.Add("Ничего не найдено!");
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            string type = comboBox3.Text;
            string price = comboBox4.Text;
            if (price == "до 35р")
            {
                f.searchedType = from Item in products
                                 where Item.Price < 35 && Item.Type == type
                                 select Item;
                if (f.searchedType.Count() > 0)
                    foreach (var item in f.searchedType)
                    {
                        treeView1.Nodes.Add(item.TakeElementTree());
                        printInfoToOriginal(item);
                        f.toolStripStatusLabelAction.Text = "Поиск по цене";
                    }
                else
                    treeView1.Nodes.Add("Ничего не найдено!");
            }


            else if (price == "от 35р до 50р")
            {
                f.searchedType = from Item in products
                                 where (Item.Price >= 35 && Item.Price < 50 && Item.Type == type)
                                 select Item;
                if (f.searchedType.Count() > 0)
                    foreach (var item in f.searchedType)
                    {
                        treeView1.Nodes.Add(item.TakeElementTree());
                        printInfoToOriginal(item);
                        f.toolStripStatusLabelAction.Text = "Поиск по цене";
                    }
                else
                    treeView1.Nodes.Add("Ничего не найдено!");
            }

            else if (price == "от 50р до 100р")
            {
                f.searchedType = from Item in products
                                 where (Item.Price >= 50 && Item.Price < 100 && Item.Type == type)
                                 select Item;
                if (f.searchedType.Count() > 0)
                    foreach (var item in f.searchedType)
                    {
                        treeView1.Nodes.Add(item.TakeElementTree());
                        printInfoToOriginal(item);
                        f.toolStripStatusLabelAction.Text = "Поиск по цене";
                    }
                else
                    treeView1.Nodes.Add("Ничего не найдено!");
            }


            else if (price == "от 100р до 150р")
            {
                f.searchedType = from Item in products
                                 where Item.Price >= 100 && Item.Price <= 150 && Item.Type == type
                                 select Item;
                if (f.searchedType.Count() > 0)
                    foreach (var item in f.searchedType)
                    {
                        treeView1.Nodes.Add(item.TakeElementTree());
                        printInfoToOriginal(item);
                        f.toolStripStatusLabelAction.Text = "Поиск по цене";
                    }
                else
                    treeView1.Nodes.Add("Ничего не найдено!");
            }


            else if (price == ">150р")
            {
                f.searchedType = from Item in products
                                 where Item.Price > 150 && Item.Type == type
                                 select Item;
                if (f.searchedType.Count() > 0)
                    foreach (var item in f.searchedType)
                    {
                        treeView1.Nodes.Add(item.TakeElementTree());
                        printInfoToOriginal(item);
                        f.toolStripStatusLabelAction.Text = "Поиск по цене";
                    }
                else
                    treeView1.Nodes.Add("Ничего не найдено!");
            }

            else treeView1.Nodes.Add("Ничего не найдено!");
        }
    }
}
