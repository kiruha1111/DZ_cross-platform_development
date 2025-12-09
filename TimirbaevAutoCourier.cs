using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timirbaev_Erik_Lab_5
{
    [Serializable]
    public class TimirbaevAutoCourier : TimirbaevCourier
    {
        public string car_model { get; set; }
        public string car_number { get; set; }
        public override void CreateCourier()
        {
            base.CreateCourier();

            while (true)
            {
                Console.Write("Введите марку автомобиля: ");
                car_model = Console.ReadLine();
                if (string.IsNullOrEmpty(car_model))
                    Console.WriteLine("Ошибка! Марка автомобиля не может быть пустой.");
                else
                    break;
            }

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

        public override void ShowCourier()
        {
            base.ShowCourier();
            Console.WriteLine($"Марка автомобиля: {car_model}");
            Console.WriteLine($"Госномер: {car_number}");
        }
    }
}