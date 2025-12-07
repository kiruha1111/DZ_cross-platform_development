using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Timirbaev_Erik_Lab_5
{
    /// <summary>
    /// Класс для управления парком курьеров.
    /// Предоставляет методы для работы со списком курьеров и их сохранения в файл.
    /// </summary>
    [Serializable]
    [XmlType("TimirbaevPark")]
    internal class TimirbaevPark
    {
        /// <summary>
        /// Список курьеров (обычных и авто-курьеров).
        /// </summary>
        List<TimirbaevCourier> couriers = new List<TimirbaevCourier>();

        /// <summary>
        /// Добавляет обычного курьера в список.
        /// </summary>
        public void AddCourier()
        {
            TimirbaevCourier courier = new TimirbaevCourier();
            courier.CreateCourier();
            couriers.Add(courier);
            Console.WriteLine();
        }

        /// <summary>
        /// Добавляет авто-курьера в список.
        /// </summary>
        public void AddAutoCourier()
        {
            TimirbaevAutoCourier auto_courier = new TimirbaevAutoCourier();
            auto_courier.CreateCourier();
            couriers.Add(auto_courier);
            Console.WriteLine();
        }

        /// <summary>
        /// Отображает информацию обо всех курьерах в списке.
        /// </summary>
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

        /// <summary>
        /// Очищает список всех курьеров.
        /// </summary>
        public void DeleteCouriers()
        {
            couriers.Clear();
            Console.WriteLine("Список очищен");
            Console.WriteLine();
        }

        /// <summary>
        /// Сохраняет список курьеров в XML файл.
        /// </summary>
        public void Save()
        {
            Console.WriteLine();
            if (couriers.Count > 0)
            {
                try
                {
                    Console.Write("Введите название файла: ");
                    string fileName = Console.ReadLine() + ".xml";

                    // Создание сериализатора для списка курьеров
                    XmlSerializer serializer = new XmlSerializer(typeof(List<TimirbaevCourier>));

                    // Сохранение в файл
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

        /// <summary>
        /// Загружает список курьеров из XML файла.
        /// </summary>
        public void Dowloand()
        {
            Console.WriteLine();
            try
            {
                Console.Write("Введите название файла: ");
                string fileName = Console.ReadLine() + ".xml";

                // Создание сериализатора для списка курьеров
                XmlSerializer serializer = new XmlSerializer(typeof(List<TimirbaevCourier>));

                // Загрузка из файла
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