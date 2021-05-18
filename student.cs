using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dz5
{
    /// <summary>
    /// Ученики, все
    /// </summary>
    class Students
    {
        private Student[] arrStudents;
        public Students(string fileName)
        {
            arrStudents = LoadArrFromFile(fileName); //получить студентов из файла
            Array.Sort(arrStudents, ((st, st1) => st.Surname.CompareTo(st.Surname))); //отсортировать по фамилиям
        }

        /// <summary>
        /// Получение данных через индексируемое свойство
        /// </summary>
        /// <param name="i">индекс</param>
        /// <returns>строковое представление</returns>
        public string this[int i] => arrStudents[i].ToString();
        /// <summary>
        /// Количество учеников
        /// </summary>
        public int Length => arrStudents.Length;
        /// <summary>
        /// Получение самых косячных учеников
        /// </summary>
        /// <returns></returns>
        public string[] GetDummersStudents()
        {
            Student[] tempStudents = new Student[arrStudents.Length];
            Array.Copy(arrStudents, tempStudents, arrStudents.Length);
            Array.Sort(tempStudents, ((st, st1) => st.Average.CompareTo(st1.Average)));
            double minAverage = tempStudents[2].Average;
            tempStudents = Array.FindAll(tempStudents, st => st.Average <= minAverage);
            string[] returnMe = new string[tempStudents.Length];
            for (int i = 0; i < tempStudents.Length; i++)
            {
                returnMe[i] = tempStudents[i].ToString();
            }
            return returnMe;
        }
        /// <summary>
        /// Получение самых лучших учеников
        /// </summary>
        /// <returns></returns>
        public string[] GetBestStudents()
        {
            Student[] tempStudents = new Student[arrStudents.Length];
            Array.Copy(arrStudents, tempStudents, arrStudents.Length);
            Array.Sort(tempStudents, ((st1, st) => st.Average.CompareTo(st1.Average)));
            double minAverage = tempStudents[0].Average;
            tempStudents = Array.FindAll(tempStudents, st => st.Average <= minAverage);
            string[] returnMe = new string[tempStudents.Length];
            for (int i = 0; i < tempStudents.Length / tempStudents.Length; i++)
            {
                returnMe[i] = tempStudents[i].ToString();
            }
            return returnMe;
        }
        /// <summary>
        /// Получение массива студентов из файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static Student[] LoadArrFromFile(string fileName = @"..\..\Data1.txt")
        {
            List<Student> list = new List<Student>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string[] strs = reader.ReadLine().Split(' ');
                    int[] vals = new int[strs.Length - 3];
                    for (int i = 0; i < strs.Length - 4; i++)
                    {
                        vals[i] = int.Parse(strs[i + 2]);

                    }

                    list.Add(new Student { Name = strs[0], Surname = strs[1], Valuations = vals });
                }
            }
            return list.ToArray();
        }
        public static void MakeSampleFile(string fileName = @"..\..\Data1.txt")
        {
            Random rnd = new Random();
            const int SIZE = 30;
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                string[] names = { "Иван", "Петр", "Сергей", "Андрей", "Алексей", "Федосей", "Барин", "Вася", "Егор", "Алексей", "Саня", "Митя", "Миша", "Костя", "Юра" };
                string[] surnames = { "Танк", "Город", "Троллейбус", "Свет", "Черн", "Гор", "Чемодан" };
                string[] surnamesEnd = { "ов", "вин", "ив", "еев", "рев", "ван", "фан", "ев" };
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < SIZE; i++)
                {
                    sb.Clear();
                    sb.Append(surnames[rnd.Next(0, surnames.Length - 1)]);
                    sb.Append(surnamesEnd[rnd.Next(0, surnamesEnd.Length - 1)] + " ");
                    sb.Append(names[rnd.Next(0, names.Length - 1)] + " ");
                    int count = rnd.Next(3, 10);
                    for (int j = 0; j < count; j++)
                    {
                        sb.Append($"{rnd.Next(2, 6)} ");
                    }
                    writer.WriteLine(sb.ToString());
                }
                writer.Close();
            }
        }
        /// <summary>
        /// Один ученик
        /// </summary>
        struct Student
        {
            public string Surname { get; set; }
            public string Name { get; set; }
            public int[] Valuations { get; set; }
            /// <summary>
            /// Средняя оценка ученика
            /// </summary>
            public double Average => (double)Valuations.Sum() / Valuations.Length;
            public override string ToString()
            {
                return $"{Surname} {Name} - {Average:F2}";
            }
        }
    }

}