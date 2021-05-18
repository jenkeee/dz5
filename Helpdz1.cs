using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Console;


namespace dz5
{



    static class helpdz3
    {
        public static bool MySpecEquals(this string s1, string s2) // internal static bool MySpecEquals(this string s1, string s2)
        {
            string str1 = string.Join("", s1.OrderBy(c => c).ToArray());
            string str2 = string.Join("", s2.OrderBy(c => c).ToArray());
            return str1.Equals(str2);
        }
    }
    /// <summary>
    /// Мой класс инструментами для дз
    /// </summary>
    static class Helpdz1
    {
        internal static bool GetLoginFromConsole(out string login, Func<string, bool> func) // если пройдет условия вернет введенные данные в переменную login 
        {
            while (true)
            {
                Write("Введите логин (q-отмена):> ");
                string buff = ReadLine(); // созданим переменную буфер
                if (func(buff)) // если логин пройдет валидаторы, с регексом или без, он вернет значение и дальше пойдет этот цикл 
                {
                    login = buff;
                    return true;
                }
                if (buff == "q") //
                {
                    login = string.Empty;
                    return false;
                }
                WriteLine("Введен неверный формал логина!");
                Beep(500, 500); // звуковой сигнал , просто так
            }
        }
        /// <summary>
        /// Проверка логина без регулярного выражения
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        internal static bool ValidNoRegex(string login)
        {
            if (login.Length < 2 || login.Length > 10)
                return false;
            if (Char.IsDigit(login[0]))
                return false;
            for (int i = 0; i < login.Length; i++)
            {
                char c = char.ToLower(login[i]);
                if (!(c >= 'a' && c <= 'z' || char.IsDigit(c)))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Проверка логина с регулярным выражением
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        internal static bool ValidWithRegex(string login)
        {
            Regex regex = new Regex(@"^[a-z][a-z\d]{1,9}$", RegexOptions.IgnoreCase);
            return regex.IsMatch(login);
        }

    }
}
