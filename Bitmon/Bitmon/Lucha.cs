using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmon
{
    public class Lucha
    {
        List<Jugador> participantes;
        public int idlucha, turno;
        public string estadolucha;

        public Lucha(List<Jugador> participantes, int idlucha, int turno, string estadolucha)
        {
            this.participantes = participantes;
            this.idlucha = idlucha;
            this.turno = turno;
            this.estadolucha = estadolucha;
        }

        public void MsjeBatalla()
        {
            Console.WriteLine("\n Se viene la batalla!!! \n");
            Console.WriteLine("Luchador numero 1: " + participantes[0].nombre+"\n");
            Console.WriteLine("\t\t\t V/S \n");
            Console.WriteLine("Luchador numero 2: " + participantes[1].nombre + "\n");
        }
        public void Turn()
        {
            Console.WriteLine("\n La batalla va a comenzar!!, se tirará una moneda al aire para definir al primer turno \n");
            Random rd1 = new Random();
            int azar = rd1.Next(1,3);
            if (azar == 1)
            {
                Console.WriteLine("La moneda dio sello!!, comenzará el luchador "+participantes[0].nombre);
                turno = 1;
            }
            if (azar == 2)
            {
                Console.WriteLine("La moneda dio cara!!, comenzará el luchador " + participantes[1].nombre);
                turno = 2;
            }
        }
        public void SelectAct()
        {
            foreach(Jugador j in participantes)
            {
                int counter = 1;
                Console.WriteLine(j.nombre+ " sus bitmons disponibles son los siguientes!! \n");
                foreach(Bitmon b in j.equipo)
                {
                    Console.WriteLine(counter + ".- " + "Nombre: " + b.nombre + " Tipo: " + b.tipo + "\n");
                    counter++;
                }
                bool aux1 = true;
                while (aux1)
                {
                    Console.WriteLine("Ingrese el nombre porfavor!!(Primer caracter en masyucula): \n");
                    string aux = Console.ReadLine();
                    foreach (Bitmon b in j.equipo)
                    {
                        if (aux == b.nombre)
                        {
                            b.estadolucha = "activo";
                            Console.WriteLine(b.nombre + " elegido!!");
                            aux1 = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nombre incorrecto!!");
                            continue;
                        }
                    }
                }
                Console.Clear();
            }
        }

    }
}
