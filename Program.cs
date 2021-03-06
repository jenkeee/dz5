
/*
4. *Задача ЕГЭ.

На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
< Фамилия > < Имя > < оценки >,

где < Фамилия > — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:
Иванов Петр 4 5 3

Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
Достаточно решить 2 задачи. Старайтесь разбивать программы на подпрограммы. Переписывайте в начало программы условие и свою фамилию. Все программы сделать в одном решении. Для решения задач используйте неизменяемые строки (string).
*/




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz5
{

    class Program
    {

        #region menu
        ///////////////////////////cсоздадим метод проверки ввода
        static int Checktoparse(string message)
        {
            string num_before;
            bool flag_ornum;
            int num_after;
            do
            {
                num_before = Console.ReadLine();

                flag_ornum = int.TryParse(num_before, out num_after);
            } while (!flag_ornum);
            return num_after;

        }
        static void Main(string[] args)
        {
            int value;
            do
            {
                Console.Title = ("Меню");
                Console.Clear();
                HelpCS.MyHeader(text: "Главное меню.");
                Console.WriteLine("Введите номер задачи от 1 до 4. принимаются только целые числа.");
                value = Checktoparse(""); // даем значение велью методом GetValue // и там метод уже либо пропустит int32 либо будет бесконечно вызыватся, пока ты не напишиш цифры удовлетворяющие условия
                // гет валью дает нам проверку на вводимы знаки, а диапазон мы сдесь даже не ставили У НАС ВСЕГО 3 КЕЙСА

                HelpCS.MyFooter();
                switch (value)
                {
                    case 1:
                        dz1();
                        break;
                    case 2:
                        dz2();
                        break;
                    case 3:
                        dz3();
                        break;
                    case 4:
                        dz4();
                        break;

                }
            } while (true);
            #endregion
        }

        #region задание 1
        /// <summary>
        /// 1.Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, 
        /// при этом цифра не может быть первой:
        /// а) без использования регулярных выражений;
        /// б) **с использованием регулярных выражений.
        /// </summary>
        static void dz1()
        {


            Console.Clear();
            HelpCS.MyHeader(text: "Задача 1. Проверка корректности ввода логина. ");
            ///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Пункт А. Без использования регулярных выражений.");
            if (Helpdz1.GetLoginFromConsole(out string login, Helpdz1.ValidNoRegex)) //ввод с консоли логина и сразу его проверка без регулярного выражения
            {
                Console.WriteLine($"Введен корректный логин пользователя \"{login}\"");
            }
            HelpCS.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Пункт Б. C использованием регулярных выражений.");
            if (Helpdz1.GetLoginFromConsole(out login, Helpdz1.ValidWithRegex)) //ввод с консоли логина и сразу его проверка с регулярным выражением
            {
                Console.WriteLine($"Введен корректный логин пользователя \"{login}\"");
            }
            /////////////////////////////////////////////////////////////////////////////////// подробное решение в файле helpdz1.cs
            HelpCS.MyFooter();
        }


        #endregion
        #region задание 2
        /// <summary>
        /// Задача 2.
        /// Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
        /// а) Вывести только те слова сообщения,  которые содержат не более n букв.
        /// б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        /// в) Найти самое длинное слово сообщения.
        /// г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        /// </summary>
        static void dz2()
        {
            Console.Clear();
            HelpCS.MyHeader(text: "Задача 2. Статический класс Message со статическими методами.");
            ///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Пункт А. Вывести только слова сообщения, которые содержат не более введенных букв.");
            Console.Write("Введите сообщение:> ");
            string message = Console.ReadLine();
            if (HelpCS.GetNumberFromConsole(out int minSize,
                "Ограничение на количество букв в словах сообщений (int)"))
            {
                Console.WriteLine("Сообщение со словами с такими условиями:");
                string mutMessage = Message.GetWordsIfLength(message, minSize);
                Console.WriteLine(mutMessage);
            }
            HelpCS.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Пункт Б. Удалить из сообщения слова, заканчиваемые на заданный символ.");
            if (HelpCS.GetNumberFromConsole(out char c,
                "Введите символ (char)"))
            {
                Console.WriteLine("Сообщение без слов с такими условиями:");
                string mutMessage = Message.GetDelIfLastSymbol(message, c);
                Console.WriteLine(mutMessage);
            }
            HelpCS.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Пункт В. Найти самое длинное слово сообщения.");
            Console.WriteLine($"Это слово = {Message.GetMaxLengthWord(message)}");
            HelpCS.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Пункт Г. Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.");
            string messageLength = Message.GetMaxLengthWords(message);
            Console.WriteLine("Сообщение из самых длинных слов:");
            Console.WriteLine(messageLength);
            HelpCS.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            HelpCS.MyFooter();
        }

        #endregion
        #region задание 3
        /// <summary>
        /// 3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
        /// Например: badc являются перестановкой abcd.
        /// </summary>
        static void dz3()
        {

            // прикрепил альтернативное решение также
            Console.Clear();
            HelpCS.MyHeader(text: "3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.");
            ///////////////////////////////////////////////////////////////////////////////////
            do
            {
                Console.Write("Введите первую строку:> ");
                string s1 = Console.ReadLine();
                Console.Write("Введите вторую строку:> ");
                string s2 = Console.ReadLine();
                if (s1.MySpecEquals(s2))
                {
                    Console.WriteLine("Эти две строки являются строками - перестановками");
                }
                else
                {
                    Console.WriteLine("Эти две строки не являются строками - перестановками");
                    Console.Beep(500, 500);
                }
                Console.Write("Повторить? (y):> ");
            } while (Console.ReadLine() == "y");
            ///////////////////////////////////////////////////////////////////////////////////
            HelpCS.MyFooter();
        }


        #endregion
        #region задание 4
        static void dz4()
        {
            Console.Clear();
            HelpCS.MyHeader(text: "Задача 4. Задача ЕГЭ.");
            ///////////////////////////////////////////////////////////////////////////////////
            Students students;
            try
            {
                students = new Students(@"..\..\data1.txt"); //получение данных из файла Пример входной строки:                /// Иванов Петр 4 5 3
            }
            catch (Exception exc)
            {

                HelpCS.MyPause("Ошибка! Не удалось получить данные из файла." + exc.Message);
                return;
            }
            Console.WriteLine("Все ученики со средними оценками:");
            for (int i = 0; i < students.Length; i++)
            {
                Console.Write($"{students[i],-30}");
            }
            HelpCS.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Лига солнцеликих:");
            foreach (string s in students.GetDummersStudents())
            {
                Console.Write($"{s,-30}");
            }
            Console.WriteLine();
            Console.SetCursorPosition(10, 19);
            Console.WriteLine("THE FORCE BE WITH U...");
            foreach (string s in students.GetBestStudents())
            {
                Console.Write($"{s,-30}");
            }
            //Students.MakeSampleFile();
            ///////////////////////////////////////////////////////////////////////////////////
            HelpCS.MyFooter();
            Console.ReadKey();

        }
        #endregion




    } }













