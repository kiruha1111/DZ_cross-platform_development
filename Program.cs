using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timirbaev_Erik_Lab_5
{
    /// <summary>
    /// Главный класс программы, содержащий точку входа.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в приложение. Запускает главное меню управления курьерской службой.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        static void Main(string[] args)
        {
            // Создание объекта для управления парком курьеров
            TimirbaevPark products = new TimirbaevPark();
            // Основной цикл программы
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
                // Обработка выбора пользователя
                switch (TimirbaevUtilities.GetCorrectNumber(0, 6))
                {
                    case 0:
                        return; // Выход из программы
                    case 1:
                        products.AddCourier(); // Добавить обычного курьера
                        break;
                    case 2:
                        products.AddAutoCourier(); // Добавить авто-курьера
                        break;
                    case 3:
                        products.ViewCouriers(); // Показать всех курьеров
                        break;
                    case 4:
                        products.Dowloand(); // Загрузить из файла
                        break;
                    case 5:
                        products.Save(); // Сохранить в файл
                        break;
                    case 6:
                        products.DeleteCouriers(); // Очистить список
                        break;
                }
            }
        }
    }
}