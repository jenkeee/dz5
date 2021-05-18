﻿using System;
using System.Text;
using static System.Console;

namespace dz5
{
    /// <summary>
    /// Мой класс с полезными инструментами
    /// </summary>
    static class HelpCS
    {
        /// <summary>
        /// Ввод символа с консоли
        /// </summary>
        /// <param name="number">вертаемый введенный сивол</param>
        /// <param name="message">сообщение приглашение</param>
        /// <returns>признак что символ введено</returns>
        internal static bool GetNumberFromConsole(out char number, string message = "Пожалуйста введите символ (char) (q-отмена)")
        {
            while (true)
            {
                Write($"{message}:>");
                string buffString = ReadLine();
                if (buffString == "q") //пользовательская команда отмена ввода
                {
                    number = default;
                    return false;
                }
                if (char.TryParse(buffString, out char num))
                {
                    number = num;
                    return true;
                }
                WriteLine("Ошибка! Введен неверный формат вещественного числа!");
                Beep(500, 500);
            }
        }

        /// <summary>
        /// Ввод целого числа с консоли
        /// </summary>
        /// <param name="number">вертаемое введенное целое число</param>
        /// <param name="message">сообщение приглашение</param>
        /// <param name="min">минимум диапазона</param>
        /// <param name="max">максимум диапазона</param>
        /// <returns>признак что число введено</returns>
        internal static bool GetNumberFromConsole(out int number, string message = "Пожалуйста введите целое число (int) (q-отмена)", int min = int.MinValue, int max = int.MaxValue, bool cancelEnable = true)
        {
            while (true)
            {
                Write($"{message}:>");
                string buffString = ReadLine();
                if (Int32.TryParse(buffString, out int num)) //введено должно быть число
                {
                    if (num < max && num > min) //число должно быть в допустимом диапазоне
                    {
                        number = num;
                        return true;
                    }
                    WriteLine($"Ошибка! Введенное число превышает разрешенный диапазон от {min} до {max}!");
                }
                else if (buffString == "q" && cancelEnable) //введена пользовательская команда отмена ввода
                {
                    number = default;
                    return false;
                }
                else //введено не число
                {
                    WriteLine("Ошибка! Введен неверный формат целого числа!");
                }
                Beep(500, 500);
            }
        }
        /// <summary>
        /// Ввод вещественного числа с консоли
        /// </summary>
        /// <param name="number">вертаемое введенное вещественное число</param>
        /// <param name="message">сообщение приглашение</param>
        /// <param name="min">минимум диапазона</param>
        /// <param name="max">максимум диапазона</param>
        /// <returns>признак что число введено</returns>
        internal static bool GetNumberFromConsole(out double number, string message = "Пожалуйста введите вещественное число (double) (q-отмена)", double min = double.MinValue, double max = double.MaxValue)
        {
            while (true)
            {
                Write($"{message}:>");
                string buffString = ReadLine();
                if (Double.TryParse(buffString, out double num))
                {
                    if (num < max && num > min) //число должно быть в допустимом диапазоне
                    {
                        number = num;
                        return true;
                    }
                    WriteLine($"Ошибка! Введенное число превышает разрешенный диапазон от {min:f2} до {max:f2}!");
                }
                else if (buffString == "q") //пользовательская команда отмена ввода
                {
                    number = default;
                    return false;
                }
                else
                {
                    WriteLine("Ошибка! Введен неверный формат вещественного числа!");
                }
                Beep(500, 500);
            }
        }
        /// <summary>
        /// Вывод моей шапки консольного приложения
        /// </summary>
        /// <param name="title">Заголовок консоли</param>
        /// <param name="text">Текст вверху экрана консоли</param>
        internal static void MyHeader(string title = "THE FORCE BE WITH U", string text = "")
        {
            const int widthConsole = 120;
            Title = text; // поменяем тайтлы
            WindowWidth = widthConsole;
            BackgroundColor = ConsoleColor.DarkGreen;
            ForegroundColor = ConsoleColor.White;
            StringBuilder sb = new StringBuilder(); //форматированный вывод шапки
            sb.Append('┌');
            sb.Append('─', widthConsole - 3);
            sb.Append('┐');
            WriteLine(sb.ToString());
            sb.Clear();
            sb.Append('│');
            sb.Append(' ', Convert.ToInt32(widthConsole / 2.0 - text.Length / 2.0) - 2);
            sb.Append(text);
            sb.Append(' ', Convert.ToInt32(widthConsole / 2.0 - text.Length / 2.0 + 0.6) - 2);
            sb.Append('│');
            WriteLine(sb.ToString());
            sb.Clear();
            sb.Append('└');
            sb.Append('─', widthConsole - 3);
            sb.Append('┘');
            WriteLine(sb.ToString());
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Black;
            WriteLine("");
        }
        /// <summary>
        /// Вывод моего подвала
        /// </summary>
        /// <param name="text">текст перед выходом из программы</param>
        internal static void MyFooter(string text = "\n\n\n\n\n\nДля продолжения нажми любую кнопку...")
        {
            WriteLine("\n" + text);
            BackgroundColor = ConsoleColor.DarkRed;
            ForegroundColor = ConsoleColor.White;
            const int widthConsole = 120;
            string force = "THE FORCE BE WITH U...";
            StringBuilder foot = new StringBuilder(); //форматированный вывод шапки
            foot.Append('┌');
            foot.Append('─', widthConsole - 3);
            foot.Append('┐');
            WriteLine(foot.ToString());
            foot.Clear();
            foot.Append('│');
            foot.Append(' ', Convert.ToInt32(widthConsole / 2.0 - force.Length / 2.0) - 2);
            foot.Append(force);
            foot.Append(' ', Convert.ToInt32(widthConsole / 2.0 - force.Length / 2.0 + 0.6) - 2);
            foot.Append('│');
            WriteLine(foot.ToString());
            foot.Clear();
            foot.Append('└');
            foot.Append('─', widthConsole - 3);
            foot.Append('┘');
            WriteLine(foot.ToString());
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Black;
            ReadKey();
        }
        /// <summary>
        /// Вывод паузы в работе программы
        /// </summary>
        /// <param name="text">текст во время паузы</param>
        internal static void MyPause(string text = "Для продолжения нажмите любую кнопку ...")
        {
            WriteLine(text + "\n");
            ReadKey();
        }
    }
}
