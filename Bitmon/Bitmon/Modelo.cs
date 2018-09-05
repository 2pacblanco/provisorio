using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmon
{
    public class Modelo
    {
        public Modelo()
        {}

        public void Mostrar(List<Bitmon> lista)
        {
            int counter = 1;
            foreach (Bitmon b in lista)
            {
                Console.WriteLine(counter + ".- " + "Nombre: " + b.nombre + " Tipo: " + b.tipo + "\n");
                counter++;
            }
        }

        public void Addequipo(List<Bitmon> disponibles, List<Bitmon> equipo)
        {
            bool gol = true;
            while (gol)
            {
                Console.WriteLine("Ingrese el nombre porfavor!!: \n");
                string aux = Console.ReadLine();
                foreach (Bitmon b in disponibles)
                {
                    if (b.nombre == aux)
                    {
                        equipo.Add(b);
                        disponibles.Remove(b);
                        gol = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nombre incorrecto!!");
                        continue;
                    }
                }
            }
        }
    }
}

