using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Timirbaev_Erik_Lab_5
{
    /// <summary>
    /// Статический класс с вспомогательными утилитами для валидации ввода.
    /// </summary>
    internal class TimirbaevUtilities
    {
        /// <summary>
        /// Проверяет, состоит ли строка только из цифр.
        /// </summary>
        /// <param name="str">Проверяемая строка.</param>
        /// <returns>True, если строка содержит только цифры, иначе False.</returns>
        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Пытается преобразовать строку в указанный тип T.
        /// </summary>
        /// <typeparam name="T">Тип, в который нужно преобразовать.</typeparam>
        /// <param name="input">Входная строка.</param>
        /// <param name="res">Результат преобразования.</param>
        /// <returns>True, если преобразование успешно, иначе False.</returns>
        private static bool TryConvert<T>(string input, out T res) where T : IComparable<T>
        {
            try
            {
                res = (T)Convert.ChangeType(input, typeof(T));
                return true;
            }
            catch
            {
                res = default;
                return false;
            }
        }

        /// <summary>
        /// Проверяет корректность ввода числа в заданном диапазоне.
        /// </summary>
        /// <typeparam name="T">Тип числа (int, double и т.д.).</typeparam>
        /// <param name="value">Переменная для сохранения результата.</param>
        /// <param name="low">Нижняя граница диапазона.</param>
        /// <param name="high">Верхняя граница диапазона.</param>
        /// <returns>True, если ввод корректен, иначе False.</returns>
        public static bool ValidityEnter<T>(ref T value, T low, T high) where T : IComparable<T>
        {
            string input = Console.ReadLine();

            bool isValid = TryConvert(input, out T parsedValue);

            if (isValid && parsedValue.CompareTo(low) >= 0 && parsedValue.CompareTo(high) <= 0)
            {
                value = parsedValue;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Получает корректное число от пользователя в заданном диапазоне.
        /// Запрашивает ввод до тех пор, пока не будет получено корректное значение.
        /// </summary>
        /// <typeparam name="T">Тип числа.</typeparam>
        /// <param name="low">Нижняя граница диапазона.</param>
        /// <param name="high">Верхняя граница диапазона.</param>
        /// <returns>Корректное число, введенное пользователем.</returns>
        public static T GetCorrectNumber<T>(T low, T high) where T : IComparable<T>
        {
            T x = default;
            while (!ValidityEnter(ref x, low, high))
            {
                Console.Write($"Введите число в диапазоне [{low}..{high}]: ");
            }
            return x;
        }
    }
}