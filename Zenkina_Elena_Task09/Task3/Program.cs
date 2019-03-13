using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string english = @"
            To be, or not to be, that is the question:
            Whether ’tis nobler in the mind to suffer
            The slings and arrows of outrageous fortune,
            Or to take arms against a sea of troubles
            And by opposing end them. To die—to sleep,
            No more; and by a sleep to say we end
            The heart-ache and the thousand natural shocks
            That flesh is heir to: ’tis a consummation
            Devoutly to be wish’d.To die, to sleep;
            To sleep, perchance to dream—ay, there’s the rub:
            For in that sleep of death what dreams may come,
            When we have shuffled off this mortal coil,
            Must give us pause—there’s the respect
            That makes calamity of so long life.";

            // Слово английского языка.
            Regex regex = new Regex(@"[a-zA-Z’']+\b", RegexOptions.Compiled);

            MatchCollection matches = regex.Matches(english);
            // Т.к. слова, отличающиеся регистром, надо считать одинаковыми, то приведем все слова к нижнему регустру.
            string[] singleWords = matches.Cast<Match>().Select(w => w.Value.ToLower()).ToArray();

            var grouped = singleWords
                .GroupBy(i => i)
                .Select(i => new { Word = i.Key, Count = i.Count() }).OrderByDescending(i => i.Count);

            Console.WriteLine("Слова из части монолога Гамлета, отсортированые по частоте встречаемости:");
            foreach (var word in grouped)
            {
                Console.WriteLine(word.Word + " - " + word.Count);
            }

            Console.ReadKey(); 
        }
    }
}
