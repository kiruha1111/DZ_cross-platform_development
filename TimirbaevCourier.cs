using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Timirbaev_Erik_Lab_5
{
    /// <summary>
    /// Базовый класс, представляющий курьера.
    /// Поддерживает XML-сериализацию и наследование для авто-курьеров.
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(TimirbaevAutoCourier))]
    public class TimirbaevCourier
    {
        /// <summary>
        /// Статический счетчик для генерации уникальных идентификаторов.
        /// </summary>
        static int MaxId = 0;

        /// <summary>
        /// Уникальный идентификатор курьера.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Имя курьера.
        /// </summary>
        public string firstname { get; set; }

        /// <summary>
        /// Фамилия курьера.
        /// </summary>
        public string surname { get; set; }

        /// <summary>
        /// Возраст курьера (от 18 до 60 лет).
        /// </summary>
        public int age { get; set; }

        /// <summary>
        /// Номер телефона курьера (10 цифр без +7).
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// Конструктор по умолчанию. Автоматически назначает уникальный ID.
        /// </summary>
        public TimirbaevCourier() { id = ++MaxId; }
		
		/// <summary>
        /// Виртуальный метод для создания курьера через консольный ввод.
        /// Запрашивает у пользователя данные и выполняет валидацию.
        /// </summary>
        public virtual void CreateCourier()
        {
            // Ввод имени
            while (true)
            {
                Console.Write("Введите имя: ");
                firstname = Console.ReadLine();
                if (string.IsNullOrEmpty(firstname))
                    Console.WriteLine("Ошибка! Имя не может быть пустым.");
                else
                    break;
            }

            // Ввод фамилии
            while (true)
            {
                Console.Write("Введите фамилию: ");
                surname = Console.ReadLine();
                if (string.IsNullOrEmpty(surname))
                    Console.WriteLine("Ошибка! Фамилия не может быть пустой.");
                else
                    break;
            }

            // Ввод возраста с валидацией
            Console.Write("Введите возраст: ");
            age = TimirbaevUtilities.GetCorrectNumber(18, 60);

            // Ввод телефона с валидацией
            while (true)
            {
                Console.Write("Введите номер телефона: +7");
                phone = Console.ReadLine();
                if (!TimirbaevUtilities.IsDigitsOnly(phone) || phone.Length != 10)
                    Console.WriteLine("Ошибка! Номер должен содержать ровно 10 цифр.");
                else
                    break;
            }
        }

        /// <summary>
        /// Виртуальный метод для отображения информации о курьере в консоли.
        /// </summary>
        public virtual void ShowCourier()
        {
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Имя: {firstname}");
            Console.WriteLine($"Фамилия: {surname}");
            Console.WriteLine($"Возраст: {age}");
            Console.WriteLine($"Номер телефона: {phone}");
        }
		
		/// <summary>
        /// Тестовый метод для проверки автоматической документации
        /// </summary>
        /// <param name="testParam">Тестовый параметр</param>
        /// <returns>Всегда возвращает true</returns>
        public bool TestAutoDocsMethod(string testParam)
        {
            Console.WriteLine("Auto-docs test: " + testParam);
            return true;
        }
    }
}