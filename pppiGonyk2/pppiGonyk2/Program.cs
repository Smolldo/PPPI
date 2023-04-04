using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using Xamarin.Forms;
using System.IO;

namespace pppiGonyk2
{
    internal class Program
    {
        //код з використанням Xamarin.Forms
        public class MainPage : ContentPage
        {
            public MainPage()
            {
                Content = new Label
                {
                    Text = "Hello, Xamarin.Forms!",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
            }
        }
        static void Main(string[] args)
        {
            //Сортування з використанням System.Linq
            List<int> numbers = new List<int> { 5, 2, 8, 4, 1, 9, 3 };

            var sortedNumbers = numbers.OrderBy(n => n);

            Console.WriteLine("Сортований масив: ");
            foreach (var number in sortedNumbers)
            {
                Console.WriteLine(number);
            }


            //System.XML
            // create
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            doc.AppendChild(root);

            // add
            XmlElement person = doc.CreateElement("person");
            root.AppendChild(person);
            XmlElement name = doc.CreateElement("name");
            name.InnerText = "Misha";
            person.AppendChild(name);
            XmlElement age = doc.CreateElement("age");
            age.InnerText = "24";
            person.AppendChild(age);

            // save
            doc.Save("test.xml");

            // read
            doc.Load("test.xml");

            Console.WriteLine(doc.OuterXml);


            //вміст веб-сторінки у вигляді рядку з використанням System.Net
            string url = "https://smolldo.github.io/Shminder/";

            using (WebClient client = new WebClient())
            {
                string response = client.DownloadString(url);
                Console.WriteLine(response);
            }

            //запис у текстовий файл з використанням System.io
            string path = @"E:\LR7\ppi\lr2.txt";
            string text = "Hello, world!";

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(text);
            }

            Console.ReadLine();
        }
    }
}
