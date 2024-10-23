using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace oop_lab3
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

        static void Main()
        {
            //File.Delete("manufactur.xml");
            //File.Delete("product.xml");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public enum SearchType
    {
        searchName =0,
        searchTypeP,
        searchPrice,
        searchTypePrice
    }

    //атрибут позволяет классу или структуре быть сериализуемыми
    [Serializable]
    [XmlRoot(Namespace = "oop_lab2")]
    [XmlType("product")]
    public class Product
    {
        public Product(string name, string id, decimal size, string weight, string type,
            int price, string date, int quantity, string mname, string address, string country, string phone)//Manufactur manufactur)
        {
            Name = name;
            Id = id;
            Size = size;
            Weight = weight;
            Type = type;
            Price = price;
            Date = date;
            Quantity = quantity;
            //
            Mname = mname;
            Address = address;
            Country = country;
            Phone = phone;
            //this.Manufactur = manufactur;
        }

        public Product() { }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "id")]
        public string Id { get; set; }


        [XmlElement(ElementName = "size")]
        public decimal Size { get; set; }

        [XmlElement(ElementName = "weight")]
        public string Weight { get; set; }

        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "price")]
        public int Price { get; set; }

        [XmlElement(ElementName = "date")]
        public string Date { get; set; }

        [XmlElement(ElementName = "quantity")]
        public int Quantity { get; set; }
        //

        [XmlElement(ElementName = "mname")]
        public string Mname { get; set; }

        [XmlElement(ElementName = "address")]
        public string Address { get; set; }

        [XmlElement(ElementName = "country")]
        public string Country { get; set; }

        [XmlElement(ElementName = "phone")]
        public string Phone { get; set; }
        //public Manufactur Manufactur { get; set; }

        public TreeNode TakeElementTree()
        {
            TreeNode name = new TreeNode("Квартира");
            name.Nodes.Add("Название: " + Name);
            name.Nodes.Add("Номер: " + Id);
            name.Nodes.Add("Размер: " + Size);
            name.Nodes.Add("Вес: " + Weight);
            name.Nodes.Add("Тип: " + Type);
            name.Nodes.Add("Цена: " + Price);
            name.Nodes.Add("Дата:" + Date);
            name.Nodes.Add("Количество: " + Quantity);
            name.Nodes.Add("Производитель: " + Mname);
            name.Nodes.Add("Адрес: " + Address);
            name.Nodes.Add("Страна: " + Country);
            name.Nodes.Add("Телефон: " +Phone);
            return name;
        }
    }

    //
    //[Serializable]
    [XmlRoot(Namespace = "Manufactur")]
    public class Manufactur
    {
        public Manufactur() { }

        public Manufactur(string name, string address, string country, string phone)
        {
            Name = name;
            Address = address;
            Country = country;
            Phone = phone;
        }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "address")]
        public string Address { get; set; }
        [XmlElement(ElementName = "country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "phone")]
        public string Phone { get; set; }
    }
    //


    public static class XmlSerializeWrapper
    {
        public static void Serialize<T>(T obj, string filename)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }
        public static T Deserialize<T>(string filename)
        {
            T obj;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                obj = (T)formatter.Deserialize(fs);
            }
            return obj;
        }
    }
}
