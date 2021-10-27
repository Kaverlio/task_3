using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    class Program
    {
        private static List<string> listElements = new List<string>();
        private static bool f = true;
        private static string choosePC = "";
        private static string chooseUser = "";
        private static string privateKey = "";
        private static string hmac = "";
        private static Random rnd = new Random();

        static void Main(string[] args)
        {
            while (f)
            {
                if (args.Distinct().Count() != args.Length)
                {
                    Console.WriteLine("Параметры не должны повторятся");
                    break;
                }
                else if (args.Length < 2)
                {
                    Console.WriteLine("Надо ввести минимум 3 параметра");
                    break;
                }
                else if (args.Length % 2 != 0)
                    for (int i = 0; i < args.Length; i++) // get argumets
                    {
                        listElements.Add(args[i]);
                    }
                else if (args.Length % 2 == 0) {
                    Console.WriteLine("Вы ввели четное количество параметров, нужно нечетное");
                    break;
                }

                privateKey = KeyGenerate.genPrivateKey();
                Console.WriteLine(privateKey);
                Console.WriteLine("Выберете из предложеного списка:");

                foreach(string s in listElements)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("0 - Выход");
                Console.WriteLine("? - Помощь");
                Console.Write("Вы ввели: ");
                chooseUser = Console.ReadLine();
                switch (chooseUser)
                {
                    case "0":
                        f = !f;
                        break;
                    case "?":
                        HelpTable.GenTable();

                        listElements.Clear();
                        break;
                    default:
                        if (listElements.Contains(chooseUser))
                        {
                            Console.WriteLine("Вы выбрали: " + chooseUser);
                            choosePC = args[rnd.Next(0, args.Length - 1)];
                            Console.WriteLine("Компьютер выбрал: " + choosePC);
                            Console.WriteLine(checkWinner(chooseUser, choosePC));
                            hmac = HMACGenerate.genHMAC(privateKey + choosePC);
                            Console.WriteLine(hmac);
                            listElements.Clear();
                        }                        
                        break;
                }
                
            }
        }

        public static string checkWinner(string u, string pc) {
            int cheak = (listElements.Count - 1) / 2;
            int indexUser = listElements.IndexOf(u);
            int indexPC = listElements.IndexOf(pc);
            if (u == pc)
                return "Ничья";
            else {
                if (cheak == indexUser || cheak == indexPC) {
                    if (indexUser > indexPC)
                        return "Победа";
                    else
                        return "Поражение";
                } else {
                    if (indexUser < cheak && (indexUser + cheak >= indexPC && indexUser < indexPC))
                        return "Поражение";
                    else if (indexUser > cheak &&  indexUser < indexPC)
                        return "Поражение";
                    else if (indexUser > cheak && indexPC < indexUser - cheak)
                        return "Поражение";
                    else
                        return "Победа";
                }
            }
        }

        public static List<string> getListElements() {
            List<string> temp = new List<string>();
            temp.Add("User/PC");
            temp.AddRange(listElements);
            return temp;
        }

       
    }
}
