using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timirbaev_Erik_Lab_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            TimirbaevPark products = new TimirbaevPark();
            while (true)
            {
                Console.WriteLine("Выбор команды");
                Console.WriteLine("1. Добавить курьера");
                Console.WriteLine("2. Добавить авто курьера");
                Console.WriteLine("3. Информация о курерах");
                Console.WriteLine("4. Загрузить из файла");
                Console.WriteLine("5. Сохранить в файл");
                Console.WriteLine("6. Очистить список");
                Console.WriteLine("0. Выход");
                Console.WriteLine();
                Console.Write("Введите номер от 0 до 6: ");
                switch (TimirbaevUtilities.GetCorrectNumber(0, 6))
                {
                    case 0:
                        return;
                    case 1:
                        products.AddCourier();
                        break;
                    case 2:
                        products.AddAutoCourier();
                        break;
                    case 3:
                        products.ViewCouriers();
                        break;
                    case 4:
                        products.Dowloand();
                        break;
                    case 5:
                        products.Save();
                        break;
                    case 6:
                        products.DeleteCouriers();
                        break;
                }
            }
        }
    }
}