using System;
using System.IO;

namespace Cwiczenie2
{
    public class PiszBledy
    {

        public static void piszLog(String log)
        {

            using(StreamWriter writer = new StreamWriter("log.txt" , true))
            {
                writer.WriteLine(log);
            }
        }




    }
}
