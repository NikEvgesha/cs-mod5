using System;

namespace cs_mod5
{
    class Program
    {
        /*Проверка строковых значений (что введено не число)*/
        static bool CheckStr(string val)
        {
            int parsedVal;
            if (int.TryParse(val, out parsedVal))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /*Проверка числовых значений (что введено число и оно >= 0)*/
        static bool CheckNum(string val, out byte parsedVal)
        {
            if (byte.TryParse(val, out parsedVal))
            {
                if (parsedVal >= 0)
                {
                    return true;
                }
                else return false;
            }
            else return false;
            
        }

        /*Ввод питомцев*/
        static string[] GetPetsNames(byte num)
        {
            string[] PetNamesArray = new string[num];
            string name;
            bool Check;
            for (int i = 0; i < num; i++)
            {
                do
                {
                    Console.WriteLine("Введите имя питомца №{0}:", i+1);
                    name = Console.ReadLine();
                    Check = CheckStr(name);
                    if (!Check)
                    {
                        Console.WriteLine("Ошибка!");
                    }
                }
                while (!Check);
                PetNamesArray[i] = name;
            }
            return PetNamesArray;
        }

        /*Ввод любимых цветов*/
        static string[] GetColors(byte num)
        {
            string[] ColorsArray = new string[num];
            string color;
            bool Check;
            for (int i = 0; i < num; i++)
            {
                do
                {
                    Console.WriteLine("Введите цвет №{0}:", i + 1);
                    color = Console.ReadLine();
                    Check = CheckStr(color);
                    if (!Check)
                    {
                        Console.WriteLine("Ошибка!");
                    }
                }
                while (!Check);
                ColorsArray[i] = color;
            }
            return ColorsArray;
        }

        /*Вывод любимых цветов*/
        static void DisplayColor(string[] ColorsArray)
        {
            
            foreach (string color in ColorsArray)
            {
                switch (color)
                {
                    case "красный":
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\tКрасный");
                        break;

                    case "зеленый":
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\tЗеленый");
                        break;

                    case "бирюзовый":
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\tБирюзовый");
                        break;

                    case "желтый":
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tжелтый");
                        break;

                    case "черный":
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\tчерный");
                        break;

                    case "белый":
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\tбелый");
                        break;

                    default:
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\t{0}\tЯ не знаю такого цвета! Но мой любимый цвет - пурпурный!", color);
                        break;
                }
                
            }
        }


    /*Запрос данных у пользователя*/
    static (string Name, string Surname, byte Age, string[] Pets, string[] FavColors) Anketa()
        {
            (string Name, string Surname, byte Age, string[] Pets, string[] FavColors) User;
            bool CheckRes;
            byte NumPets;
            byte NumColors;
            do
            {
                Console.WriteLine("Введите имя: ");
                User.Name = Console.ReadLine();
                CheckRes = CheckStr(User.Name);
                if (!CheckRes)
                {
                    Console.WriteLine("Ошибка!");
                }
            }
            while (!CheckRes);

            do
            {
                Console.WriteLine("Введите фамилию: ");
                User.Surname = Console.ReadLine();
                CheckRes = CheckStr(User.Surname);
                if (!CheckRes)
                {
                    Console.WriteLine("Ошибка!");
                }
            }
            while (!CheckRes);

            do
            {
                Console.WriteLine("Введите возраст (цифрами): ");
                
                CheckRes = CheckNum(Console.ReadLine(), out User.Age);
                if (!CheckRes || User.Age == 0)
                {
                    Console.WriteLine("Ошибка!");
                }
                
               
            }
            while (!CheckRes || User.Age == 0) ;


            do
            {
                Console.WriteLine("Введите количество ваших питомцев (цифрами): ");
                
                CheckRes = CheckNum(Console.ReadLine(), out NumPets);
                if (!CheckRes)
                {
                    Console.WriteLine("Ошибка!");
                }

            }
            while (!CheckRes);

            if (NumPets > 0)
            {
                User.Pets = GetPetsNames(NumPets);
            }
            else User.Pets = null;

            do
            {
                Console.WriteLine("Введите количество ваших любимых цветов (цифрами): ");

                CheckRes = CheckNum(Console.ReadLine(), out NumColors);
                if (!CheckRes)
                {
                    Console.WriteLine("Ошибка!");
                }

            }
            while (!CheckRes);

            if (NumColors > 0)
            {
                User.FavColors = GetColors(NumColors);
            }
            else User.FavColors = null;



            return User;
        }

        /*Вывод данных*/
        static void DisplayUserData((string Name, string Surname, byte Age, string[] PetName, string[] FavColors) user_data)
        {
            Console.WriteLine("Ваше имя: {0} {1}", user_data.Name, user_data.Surname);
            Console.WriteLine("Ваш возраст: {0}", user_data.Age);

            if (user_data.PetName == null)
            {
                Console.WriteLine("У Вас нет питомцев :(");
            }
            else
            {
                Console.WriteLine("Ваши питомцы: ");
                foreach (string PetName in user_data.PetName)
                {
                    Console.WriteLine("\t{0}", PetName);
                }
            }

            if (user_data.FavColors == null)
            {
                Console.WriteLine("У Вас нет любимых цветов :(");
            }
            else
            {
                Console.WriteLine("Ваши любимые цвета: ");
                DisplayColor(user_data.FavColors);

            }
        }





        static void Main(string[] args)
        {
            Console.WriteLine("\tАНКЕТА");
            (string Name, string Surname, byte Age, string[] PetName, string[] FavColors) user_data;
            user_data = Anketa();
            DisplayUserData(user_data);
           


        }
    }
}
