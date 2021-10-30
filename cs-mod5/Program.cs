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




        /*Запрос данных у пользователя*/
        static (string Name, string Surname, byte Age, string[] Pets/*, string[] FavColors*/) Anketa()
        {
            (string Name, string Surname, byte Age, string[] Pets/*, string[] FavColors*/) User;
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



            return User;
        }



        static void Main(string[] args)
        {
            Console.WriteLine("\tАНКЕТА");
            (string Name, string Surname, byte Age, string[] PetName/*, string[] FavColors*/) user_data;
            user_data = Anketa();
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
        }
    }
}
