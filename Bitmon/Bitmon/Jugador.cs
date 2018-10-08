﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmon
{
    public class Jugador
    {
        public List<Bitmon> bitmons;
        public List<Bitmon> equipo;
        public string nombre;
        public int id;

        public Jugador(List<Bitmon> bitmons, List<Bitmon> equipo, string nombre, int id)
        {
            this.bitmons = bitmons;
            this.equipo = equipo;
            this.nombre = nombre;
            this.id = id;
        }

        public void CambiarAct()
        {
            
                int counter = 1;
                Console.WriteLine("Por favor, elija su Bitmon que saldrá a la Batalla: \n");
                Console.WriteLine("Los disponibles para luchar son los siguientes:  (Ingrese el nombre de el Bitmon[primera letra mayuscula])");
            bool waza =false;
            foreach(Bitmon b in equipo)
            {
                if(b.estadolucha!= "dead")
                {
                    waza=true;
                }
            }
            if (waza)
            {
                foreach (Bitmon b in equipo)
                {
                    if (b.estadolucha == null)
                    {
                        Console.WriteLine($"{counter}.- Nombre: {b.nombre} Vida: {b.vida} Tipo: {b.tipo}");
                    }
                    counter++;
                    if (b.estadolucha == "activo")
                    {
                        b.estadolucha = null;
                    }
                }
                bool boolau1 = true;
                while (boolau1)
                {
                    string aux1 = Console.ReadLine();
                    counter = 1;
                    foreach (Bitmon c in equipo)
                    {
                        if (c.nombre == aux1)
                        {
                            c.estadolucha = "activo";
                            Console.WriteLine("Felicidades, su Bitmon elegido es {0}", c.nombre);
                            Console.WriteLine("\n Presiona una tecla para continuar!! ");
                            Console.ReadKey();
                            break;
                        }
                        counter++;
                    }

                    if (counter > 3)
                    {
                        Console.WriteLine("Nombre incorrecto :(, ingréselo nuevamente \n");
                        continue;
                    }
                    boolau1 = false;

                }
            }

            else
            {
                Console.WriteLine("NO TIENE BITMONS DISPONIBLES PARA CAMBIAR");
            }
        }

        public bool VerifyLife()
        {
            foreach (Bitmon b in equipo)
            {
                if (b.vida > 0)
                {
                    return true;

                }
                else { continue; }
            }
            return false;
        }

        public void Vervida()
        {
            foreach (Bitmon b in equipo)
            {
                if (b.estadolucha == "muerto")
                {
                    Console.Clear();
                    b.estadolucha = "dead";
                    CambiarAct();
                    Console.Clear();
                    break;
                }
                else { continue; }
            }
        }

    }
}