using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Timirbaev_Erik_Lab_5
{
    internal class TimirbaevUtilities
    {
        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

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