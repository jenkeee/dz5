using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dz5
{
    /// <summary>
    /// Статический класс обработки текста
    /// </summary>
    static class Message
    {
        /// <summary>
        /// Получить слова сообщения, которые больше введенного значения
        /// </summary>
        /// <param name="message">полное сообщение</param>
        /// <param name="minCount">минимальн длинна</param>
        /// <returns>отобранные слова</returns>
        public static string GetWordsIfLength(string message, int minCount)
        {
            string[] words = message.Split(' ');
            string[] filterWords = Array.FindAll(words, s => s.Length <= minCount);
            return string.Join(", ", filterWords);
        }
        /// <summary>
        /// Удалить из сообщения все слова с последней буквой введенной
        /// </summary>
        /// <param name="message">полное сообщение</param>
        /// <param name="c">буква</param>
        /// <returns>отобранные слова</returns>
        public static string GetDelIfLastSymbol(string message, char c)
        {
            Regex regex = new Regex($@"\w+{c}\b");
            return regex.Replace(message, "");
        }
        /// <summary>
        /// Самое длинное слово в сообщении
        /// </summary>
        /// <param name="message">полное сообщение</param>
        /// <returns>длинное слово</returns>
        public static string GetMaxLengthWord(string message)
        {
            string[] words = message.Split(' ');
            Array.Sort(words, (s, s1) => s.Length - s1.Length);
            return words.Last();
        }
        /// <summary>
        /// Формирование строки с помощью StringBuilder из самых длинных слов
        /// </summary>
        /// <param name="message">полное сообщение</param>
        /// <returns>переделанное сообщение</returns>
        public static string GetMaxLengthWords(string message)
        {
            int max = GetMaxLengthWord(message).Length; //получение длинны самого длинного слова
            Regex regex = new Regex(@"\w{" + max + @"}\b");
            StringBuilder returnMe = new StringBuilder();
            MatchCollection collection = regex.Matches(message);
            foreach (var elem in collection)
            {
                returnMe.Append($"{elem} ");
            }
            return returnMe.ToString();
        }
        /// <summary>
        /// Словать с частотным анализом текста
        /// </summary>
        /// <param name="message">полное сообщение</param>
        /// <returns>список из сообщений</returns>
       

    }
}