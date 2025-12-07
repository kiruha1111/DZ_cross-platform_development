using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timirbaev_Erik_Lab_5
{
    /// <summary>
    /// Класс, представляющий авто-курьера. Наследуется от TimirbaevCourier.
    /// Добавляет информацию об автомобиле.
    /// </summary>
    [Serializable]
    public class TimirbaevAutoCourier : TimirbaevCourier
    {
        /// <summary>
        /// Марка автомобиля авто-курьера.
        /// </summary>
        public string car_model { get; set; }

        /// <summary>
        /// Государственный номер автомобиля.
        /// </summary>
        public string car_number { get; set; }

        /// <summary>
        /// Переопределенный метод создания курьера.
        /// Сначала вызывает базовый метод, затем запрашивает данные об автомобиле.
        /// </summary>
        public override void CreateCourier()
        {
            // Вызов базового метода для ввода общих данных
            base.CreateCourier();

            // Ввод марки автомобиля
            while (true)
            {
                Console.Write("Введите марку автомобиля: ");
                car_model = Console.ReadLine();
                if (string.IsNullOrEmpty(car_model))
                    Console.WriteLine("Ошибка! Марка автомобиля не может быть пустой.");
                else
                    break;
            }

            // Ввод госномера
            while (true)
            {
                Console.Write("Введите госномер автомобиля: ");
                car_number = Console.ReadLine();
                if (string.IsNullOrEmpty(car_number))
                    Console.WriteLine("Ошибка! Госномер не может быть пустым.");
                else
                    break;
            }
        }

        /// <summary>
        /// Переопределенный метод отображения информации.
        /// Показывает данные курьера и информацию об автомобиле.
        /// </summary>
        public override void ShowCourier()
        {
            // Вызов базового метода для отображения общих данных
            base.ShowCourier();
            Console.WriteLine($"Марка автомобиля: {car_model}");
            Console.WriteLine($"Госномер: {car_number}");
        }
    }
}