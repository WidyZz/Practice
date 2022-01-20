using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        //public delegate bool Podminka(int i);

        static void Main(string[] args)
        {
            // Podtritko == discard
            var result2 = TryParse("sss", out _);
                

            Console.WriteLine(result2);

            string[] stringArray = { "Pes", "Kocka", "Lemur", "Lev" };

            Metoda(stringArray);
            
            List<int> nums = new List<int>();
            for (int i = 1; i < 40; i++) {
                nums.Add(i);
            }
            // vypis mocniny sudych cisel
            var result = nums.Where(r => r % 2 == 0).Select(r => Math.Pow(r, 2));

            foreach (var item in result) {
                Console.WriteLine(string.Join(", ", item));
            }

            //var data = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var data = "Hello, World!".ToCharArray();
            var vysledek = data
                .Where(c => char.IsUpper(c))
                .Select(c=> new string(c, 10))
                .OrderByDescending(c=>c);
                           //= Utils.Vyber(data, c => char.IsUpper(c));
            Console.WriteLine(string.Join(", ", vysledek));

            var p = new Person { FirstName= "Jan", LastName = "Novak" };
            Console.WriteLine(p.FullName);


        }
        // Overloady
        public string Save() { return " ";  }
        public void Save(string fileName) { }
        public void Save(string fileName, bool overwrite) { }
        public void Save(Stream stream) { }
        // in = nemuzu prepisovat, je to read-only, out = musim alokovat hodnotu do i
        public static bool TryParse(in string s, out int i) {
            i = 10;
            return true;
        }

        // Params Keyword
        public static void Metoda<T>(params T[] args) {
                Console.WriteLine($"Your input is: {string.Join(", ", args)}");

        }
    }
    public static class Utils
    {
        // Prepsany linq .Where
        public static IEnumerable<T> Vyber<T>(this IEnumerable<T> vstup, Func<T, bool> p){
            foreach (var item in vstup){
                if (p(item)) yield return item;
            }
        }
    }

    /* LIFO - last in first out*/
    public class Zasobnik<T>
    {
        public T[] uloziste;
        public int ukazatel;
        public Zasobnik(int kapacita)
        {
            this.uloziste = new T[kapacita];
            this.ukazatel = 0;
        }

        public bool JePrazdny => this.ukazatel == 0;
        public bool JePlny => this.ukazatel == this.uloziste.Length;

        public void Vloz(T cislo)
        {
            if (this.JePlny) throw new Exception("Zasobnik je plny.");
            this.uloziste[this.ukazatel] = cislo;
            ukazatel++;
        }

        public T Vyjmi()
        {
            if (this.JePrazdny) throw new Exception("Zasobnik je prazdny.");
            this.ukazatel--;
            return this.uloziste[this.ukazatel];
        }
    }
}
