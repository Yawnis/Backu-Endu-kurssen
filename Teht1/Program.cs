using System;
using System.Threading.Tasks;

namespace Teht1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool realtime = true;

            if (args.Length >= 2)
            {
                if (args[1] == "realtime")
                {
                    realtime = true;
                }
                else if (args[1] == "offline")
                {
                    realtime = false;
                }
            }
            else if (args.Length == 0)
            {
                return;
            }

            Console.WriteLine(args[0]);

            string input = args[0];
            int count = 0;

            ICityBikeDataFetcher fetchy;
            if (realtime)
            {
                fetchy = new RealTimeCityBikeDataFetcher();
            }
            else
            {
                fetchy = new OfflineCityBikeDataFetcher();
            }

            Task<int> task = fetchy.GetBikeCountInStation(input);
            task.Wait();
            count = task.Result;
            Console.WriteLine("The Bikeys: " + count.ToString());
        }
    }
}