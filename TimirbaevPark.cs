using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Timirbaev_Erik_Lab_5
{
    [Serializable]
    [XmlType("TimirbaevPark")]
    internal class TimirbaevPark
    {
        List<TimirbaevCourier> couriers = new List<TimirbaevCourier>();
        public void AddCourier()
        {
            TimirbaevCourier courier = new TimirbaevCourier();
            courier.CreateCourier();
            couriers.Add(courier);
            Console.WriteLine();
        }
        public void AddAutoCourier()
        {
            TimirbaevAutoCourier auto_courier = new TimirbaevAutoCourier();
            auto_courier.CreateCourier();
            couriers.Add(auto_courier);
            Console.WriteLine();
        }
        public void ViewCouriers()
        {
            Console.WriteLine();
            if (couriers.Count > 0)
            {
                foreach (var product in couriers)
                {
                    product.ShowCourier();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Список пуст");
                Console.WriteLine();
            }
        }
        public void DeleteCouriers()
        {
            couriers.Clear();
            Console.WriteLine("Список очищен");
            Console.WriteLine();
        }
        public void Save()
        {
            Console.WriteLine();
            if (couriers.Count > 0)
            {
                try
                {
                    Console.Write("Введите название файла: ");
                    string fileName = Console.ReadLine() + ".xml";
                    XmlSerializer serializer = new XmlSerializer(typeof(List<TimirbaevCourier>));
                    using (FileStream file = new FileStream(fileName, FileMode.Create))
                    {
                        serializer.Serialize(file, couriers);
                    }

                    Console.WriteLine("Cохранено");
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine("Ошибка сохранения!");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Товаров нет");
                Console.WriteLine();
            }
        }
        public void Dowloand()
        {
            Console.WriteLine();
            try
            {
                Console.Write("Введите название файла: ");
                string fileName = Console.ReadLine() + ".xml";
                XmlSerializer serializer = new XmlSerializer(typeof(List<TimirbaevCourier>));
                using (FileStream file = new FileStream(fileName, FileMode.Open))
                {
                    couriers = (List<TimirbaevCourier>)serializer.Deserialize(file);
                }

                Console.WriteLine("Загружено");
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Ошибка загрузки!");
                Console.WriteLine();
            }
        }
    }
}