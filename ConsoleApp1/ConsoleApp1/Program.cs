using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            DataBase dataBase = new DataBase();
        }
    }

    class DataBase
    {
        private List<Criminal> _criminals = new List<Criminal> { new Criminal("Hulio", false, 185, 85, "Hispanic"), new Criminal("Julio", false, 180, 75, "Hispanic"), new Criminal("John", true, 175, 95, "American"), new Criminal("Ivan", false, 185, 85, "Russian") };
        private List<Criminal> _filtredCriminals;

        public DataBase()
        {
            _filtredCriminals = FilterArrested();
            Search();
        }

        public void Search()
        {
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("1. Поиск по имени");
                Console.WriteLine("2. Поиск по росту");
                Console.WriteLine("3. Поиск по весу");
                Console.WriteLine("4. Поиск по национальности");
                Console.WriteLine("5. Выход");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SearchName();
                        break;
                    case "2":
                        SearchHeight();
                        break;
                    case "3":
                        SearchWeight();
                        break;
                    case "4":
                        SearchNationality();
                        break;
                    case "5":
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка");
                        break;
                }
            }
        }

        private void SearchName()
        {
            Console.WriteLine("Введите имя");
            string input = Console.ReadLine();
            var nameFilred = from Criminal criminal in _filtredCriminals where criminal.Name == (input) select criminal;
            ShowInfo(nameFilred);
        }

        private void SearchHeight()
        {
            Console.WriteLine("Введите рост");
            string input = Console.ReadLine();
            int number;

            if (int.TryParse(input, out number))
            {
                var heightFilred = from Criminal criminal in _filtredCriminals where criminal.Height == (number) select criminal;
                ShowInfo(heightFilred);
            }
        }

        private void SearchWeight()
        {
            Console.WriteLine("Введите вес");
            string input = Console.ReadLine();
            int number;

            if (int.TryParse(input, out number))
            {
                var weightFilred = from Criminal criminal in _filtredCriminals where criminal.Weight == (number) select criminal;
                ShowInfo(weightFilred);
            }
        }

        private void SearchNationality()
        {
            Console.WriteLine("Введите национальность");
            string input = Console.ReadLine();
            var nationalityFilred = from Criminal criminal in _filtredCriminals where criminal.Nationality == (input) select criminal;
            ShowInfo(nationalityFilred);
        }

        private void ShowInfo(IEnumerable<Criminal> list)
        {
            foreach (var criminal in list)
            {
                Console.WriteLine(criminal.Name + " " + criminal.Height + " " + criminal.Weight + " " + criminal.Nationality);
            }
        }

        private List<Criminal> FilterArrested()
        {
            var filtredCriminals = from Criminal criminal in _criminals where criminal.IsArrested == false select criminal;
            return filtredCriminals.ToList();
        }
    }

    class Criminal
    { 
        public string Name { get; private set; }
        public bool IsArrested { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }

        public Criminal(string name, bool isArrested, int height, int weight, string nationality)
        {
            Name = name;
            IsArrested = isArrested;
            Height = height;
            Weight = weight;
            Nationality = nationality;
        }
    }
}