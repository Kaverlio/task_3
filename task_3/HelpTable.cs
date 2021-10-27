using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace task_3
{
    class HelpTable
    {

        private static string[] strArr = Program.getListElements().ToArray();

        public static void GenTable() {

            var table = new ConsoleTable(strArr);
            for (int i = 1; i < strArr.Length; i++) {
                table.AddRow(createRow(i));
            }

            table.Write();
            Console.WriteLine();
            Console.ReadKey();
        }
// i, Program.checkWinner(i.ToString(), 1.ToString()), Program.checkWinner(i.ToString(), 2.ToString()), Program.checkWinner(i.ToString(), 3.ToString()), Program.checkWinner(i.ToString(), 4.ToString()), Program.checkWinner(i.ToString(), 5.ToString()));

        private static String[] createRow(int c) {
            List<string> tempArr = new List<string>();
            tempArr.Add(c.ToString());
            for (int i = 1; i < strArr.Length; i++) {
                tempArr.Add(Program.checkWinner(c.ToString(), i.ToString()));
            }
            
            return tempArr.ToArray();
        }
    }
}
