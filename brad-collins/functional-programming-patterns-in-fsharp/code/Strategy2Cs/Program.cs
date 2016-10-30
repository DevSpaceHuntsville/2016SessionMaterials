using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy2Cs
{
    public class StartsWith
    {
        public string Prefix { get; private set; }
        public StartsWith(string prefix)
        {
            Prefix = prefix;
        }

        public bool Test(string sample)
        {
            return sample.StartsWith(Prefix);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> func = s => s.Length;

            var words = new List<string>()
            {
                "Lorem",
                "ipsum",
                "dolor",
                "sit",
                "amet",
                "consectetur",
                "adipiscing",
                "elit",
            };

            var startsWithL = new StartsWith("L");
            var lWords = words.FindAll(startsWithL.Test);

            foreach (var word in lWords) Console.WriteLine(word);
            // "Lorem"

            var startsWithA = new StartsWith("a");
            var aWords = words.FindAll(startsWithA.Test);

            foreach (var word in aWords) Console.WriteLine(word);
            // "amet"
            // "adipiscing"
        }
    }
}
