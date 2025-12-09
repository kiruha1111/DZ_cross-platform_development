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
    [Serializable]
    [XmlInclude(typeof(TimirbaevAutoCourier))]
    public class TimirbaevCourier
    {
        static int MaxId = 0;
        public int id { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string phone { get; set; }
        public TimirbaevCourier() { id = ++MaxId; }
        public virtual void CreateCourier()
        {
            while (true)
            {
                Console.Write("Введите имя: ");
                firstname = Console.ReadLine();
                if (string.IsNullOrEmpty(firstname))
                    Console.WriteLine("Ошибка! Имя не может быть пустым.");
                else
                    break;
            }
            while (true)
            {
                Console.Write("Введите фамилию: ");
                surname = Console.ReadLine();
                if (string.IsNullOrEmpty(surname))
                    Console.WriteLine("Ошибка! Фамилия не может быть пустой.");
                else
                    break;
            }
            Console.Write("Введите возраст: ");
            age = TimirbaevUtilities.GetCorrectNumber(18, 60);
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
        public virtual void ShowCourier()
        {
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Имя: {firstname}");
            Console.WriteLine($"Фамилия: {surname}");
            Console.WriteLine($"Возраст: {age}");
            Console.WriteLine($"Номер телефона: {phone}");
        }
		
		public bool TestAutoDocsMethod(string testParam)
        {
            Console.WriteLine("Auto-docs test: " + testParam);
            return true;
        }
    }
}