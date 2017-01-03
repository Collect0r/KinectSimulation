using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public static class Class1
    {
        private static String[] names = new String[] { "Joachim", "Vera", "Simon", "Katrin", "Nikola", "Timo" };

        private static bool retry = true;

        private static List<String> chosenNames = new List<String>();
        public static void run()
        {
            while (retry)
            {
                try
                {
                    for (int i = 0; i < names.Length; i++)
                    {
                        String name = names[i];
                        Random rnd = new Random();
                        int rndIndex = rnd.Next(0, 6);

                        String rndName = "";

                        while (rndName == "" || rndName == name || chosenNames.Contains(rndName) || (i % 2 == 0 ? rndIndex == i + 1 : rndIndex == i - 1))
                        {
                            rndIndex = rnd.Next(0, 6);
                            rndName = names[rndIndex];

                            if (rndName == name && chosenNames.Count >= 4)
                                throw new InvalidOperationException("");
                        }

                        chosenNames.Add(rndName);
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\\Users\\Joachim\\Desktop\\" + name + ".txt"))
                        {
                            file.WriteLine(rndName);
                        }

                        retry = false;
                    }
                }
                catch (Exception e)
                {
                    chosenNames.Clear();
                    retry = true;
                }
            }

            Console.WriteLine(chosenNames.Count);
        }
    }
}