using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Eratoasthenes();
        }

        static void Eratoasthenes()
        {
            Eratoasthenes Eratoasthenes = new Eratoasthenes(30);
            Eratoasthenes.ToString();
        }
    }
}
