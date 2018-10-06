using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmon
{
    public class Lucha
    {
        public List<Jugador> participantes;
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
            Console.WriteLine("Luchador numero 1: " + participantes[0].nombre + "\n");
            Console.WriteLine("\t\t\t V/S \n");
            Console.WriteLine("Luchador numero 2: " + participantes[1].nombre + "\n");
        }
        public void Turn()
        {
            Console.WriteLine("\n La batalla va a comenzar!!, se tirarána moneda al aire para definir al primer turno \n");
            Random rd1 = new Random();
            int azar = rd1.Next(1, 2);
            if (azar == 1)
            {
                Console.WriteLine("La moneda dio sello!!, comenzarál luchador " + participantes[0].nombre);
                turno = 1;
            }
            if (azar == 2)
            {
                Console.WriteLine("La moneda dio cara!!, comenzarál luchador " + participantes[1].nombre);
                turno = 2;
            }
        }
        public void SelectAct()
        {
            foreach (Jugador j in participantes)
            {
                int counter = 1;
                Console.WriteLine(j.nombre + " sus bitmons disponibles son los siguientes!! \n");
                foreach (Bitmon b in j.equipo)
                {
                    Console.WriteLine(counter + ".- " + "Nombre: " + b.nombre + " Tipo: " + b.tipo + "\n");
                    counter++;
                }
                bool aux1 = true;
                Bitmon bitaux = null;
                while (aux1)
                {
                    Console.WriteLine("Ingrese el nombre de su PRIMER  Bitmon en batalla!(Primer caracter en masyucula): \n");
                    string aux = Console.ReadLine();
                    foreach (Bitmon b in j.equipo)
                    {
                        if (aux == b.nombre)
                        {
                            b.estadolucha = "activo";
                            bitaux = b;
                            Console.WriteLine(b.nombre + " elegido!!");
                            break;
                        }
                        else { continue; }

                    }
                    if (bitaux == null)
                    {
                        Console.WriteLine("opción inválida, ingrésela nuevamente!!");
                        continue;
                    }
                    aux1 = false;
                }
                foreach(Bitmon b in j.equipo)
                {
                    if(b.nombre == bitaux.nombre)
                    {
                        b.estadolucha = "activo";
                    }
                }
                Console.Clear();
            }
        }
       

        public void PeleaTurno() {
            if (turno == 1)
            {
                Console.WriteLine("Estado de los bitmons iniciado este turno!:");
                Console.WriteLine("Bitmon de " + participantes[0].nombre);
                foreach (Bitmon b in participantes[0].equipo)
                {

                    if (b.estadolucha == "activo")
                    {
                        Console.WriteLine(b.nombre + "->VIDA->" + b.vida + "->STAMINA->" + b.stamina + "->Estado->:" + b.estadolucha);
                    }

                }
                Console.WriteLine("Bitmon de " + participantes[1].nombre);
                foreach (Bitmon b in participantes[1].equipo)
                {
                    if (b.estadolucha == "activo")
                    {
                        Console.WriteLine(b.nombre + "->VIDA->" + b.vida + "->STAMINA->" + b.stamina + "->Estado->:" + b.estadolucha);
                    }

                }

                

                bool boolaux = true;
                while (boolaux)
                {
                    int opcion;
                    Console.WriteLine("Turno de " + participantes[0].nombre);
                    Console.WriteLine("Por favor, eliga su accion!! (Ingrese el numero asociado a la accion)");
                    Console.WriteLine("1.- Atacar ");
                    Console.WriteLine("2.- Descansar ");
                    Console.WriteLine("3.- Cambiar ");

                    try
                    {
                        opcion = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("dato mal ingresado, ingréselo nuevamente porfavor");
                        Console.WriteLine("Presiona una letra para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    if (opcion == 3)
                    {
                        participantes[0].CambiarAct();
                        boolaux = false;
                        break;
                    }
                    if (opcion == 2)
                    {
                        Console.WriteLine("Está seguro que quieres que este bitmon descanse? [S/N]");

                        char p = Convert.ToChar(Console.ReadLine());

                        if (p == 's' || p == 'S')
                        {
                            foreach (Bitmon b in participantes[0].equipo)
                            {
                                if (b.estadolucha == "activo")
                                {
                                    b.vida = b.vida + 30;
                                    b.stamina = b.stamina + 5;
                                    Console.WriteLine($"Estadisticas de {b.nombre} mejoradas!!");
                                    Console.WriteLine($" Vida: +30      Stamina: +5 ");
                                    Console.WriteLine("Apreta una tecla para continuar!!");
                                    Console.ReadKey();
                                    break;
                                }
                            }

                        }
                        if (p == 'n' || p == 'N')
                        {
                            Console.WriteLine("Turno perdido :(");
                            Console.WriteLine("Apreta una tecla para continuar!!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("opción no valida, ingresela nuevamente!!");

                        }
                        boolaux = false;
                        break;
                    }
                    if (opcion == 1)
                    {
                        Bitmon act1 = null;
                        Bitmon act2 = null;
                        foreach (Bitmon b in participantes[0].equipo)
                        {
                            if (b.estadolucha == "activo")
                            {
                                act1 = b;
                            }
                        }
                        foreach (Bitmon b in participantes[1].equipo)
                        {
                            if (b.estadolucha == "activo")
                            {
                                act2 = b;
                            }
                        }
                        Console.WriteLine("Ataques disponible de " + act1.nombre);
                        int counter = 1;
                        foreach (Poder p in act1.poderes)
                        {
                            Console.WriteLine(counter + ".- Nombre: " + p.nombre + ", Costo: " + p.costo + ", Danio: " + p.danio + ", Tipo: " + p.tipo + ", Ulti: " + p.ulti);
                            counter++;
                        }

                        Poder power;
                        while (true)
                        {
                            int poderelegido;
                            Console.WriteLine("Ingrese el número del poder elegido para atacar al enemigo: ");
                            try
                            {
                                poderelegido = Convert.ToInt32(Console.ReadLine()) - 1;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Formato no aceptado");
                                continue;
                            }
                            if (poderelegido < 0 || poderelegido > 3)
                            {
                                Console.WriteLine("opción no valida, ingrese nuevamente");
                                continue;
                            }
                            else
                            {
                                power = act1.poderes[poderelegido];
                                break;
                            }
                        }
                        
                        act2 = act1.Ataca(act2, power);
                        
                        foreach(Bitmon b in participantes[1].equipo)
                        {
                            if (b.nombre == act2.nombre)
                            {
                                b.vida = act2.vida;
                                b.estadosalud = act2.estadosalud;
                                b.estadolucha = act2.estadolucha;
                                b.stamina = act2.stamina;
                                break;
                            }
                        }
                       
                        Console.WriteLine("Datos de los Bitmons Finalizado este turno");
                        Console.WriteLine("Bitmon de "+participantes[0].nombre );
                        foreach (Bitmon b in participantes[0].equipo)
                        {
                          
                            if (b.estadolucha == "activo")
                            {
                                Console.WriteLine(b.nombre + "->VIDA->" + b.vida+"->STAMINA->"+b.stamina+"->Estado->:"+b.estadolucha);
                            }

                        }
                        Console.WriteLine("Bitmon de " + participantes[1].nombre);
                        foreach (Bitmon b in participantes[1].equipo)
                        {
                            if (b.estadolucha == "activo")
                            {
                                Console.WriteLine(b.nombre + "->VIDA->" + b.vida + "->STAMINA->" + b.stamina + "->Estado->:" + b.estadolucha);
                            }

                        }
                        
                        Console.WriteLine("Presione cualquier letra para seguir jugando!");
                        Console.ReadKey();
                        Console.Clear();
                        boolaux = false;
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida, por favor, Ingresela Nuevamente!!");
                        Console.Clear();
                        continue;
                        
                    }
                }

            }

            if (turno == 2)
            {
                Console.WriteLine("Estado de los bitmons iniciado este turno!:");
                Console.WriteLine("Bitmon de " + participantes[0].nombre);
                foreach (Bitmon b in participantes[0].equipo)
                {

                    if (b.estadolucha == "activo")
                    {
                        Console.WriteLine(b.nombre + "->VIDA->" + b.vida + "->STAMINA->" + b.stamina + "->Estado->:" + b.estadolucha);
                    }

                }
                Console.WriteLine("Bitmon de " + participantes[1].nombre);
                foreach (Bitmon b in participantes[1].equipo)
                {
                    if (b.estadolucha == "activo")
                    {
                        Console.WriteLine(b.nombre + "->VIDA->" + b.vida + "->STAMINA->" + b.stamina + "->Estado->:" + b.estadolucha);
                    }

                }
             

                bool boolaux1 = true;
                while (boolaux1)
                {
                    int opcion;
                    Console.WriteLine("Turno de " + participantes[1].nombre);
                    Console.WriteLine("Por favor, eliga su accion!! (Ingrese el numero asociado a la accion)");
                    Console.WriteLine("1.- Atacar ");
                    Console.WriteLine("2.- Descansar ");
                    Console.WriteLine("3.- Cambiar ");
                    try {
                        opcion = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("dato mal ingresado, ingréselo nuevamente porfavor");
                        Console.WriteLine("Presiona una letra para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    
                    if (opcion == 3)
                    {
                        participantes[1].CambiarAct();
                        boolaux1=false;
                        break;
                    }
                    if (opcion == 2)
                    {
                        Console.WriteLine("Está seguro que quieres que este bitmon descanse? [S/N]");

                        char p = Convert.ToChar(Console.ReadLine());

                        if (p == 's' || p == 'S')
                        {
                            foreach (Bitmon b in participantes[1].equipo)
                            {
                                if (b.estadolucha == "activo")
                                {
                                    b.vida = b.vida + 30;
                                    b.stamina = b.stamina + 5;
                                    Console.WriteLine($"Estadisticas de {b.nombre} mejoradas!!");
                                    Console.WriteLine($" Vida: +30      Stamina: +5 ");
                                    Console.WriteLine("Apreta una tecla para continuar!!");
                                    Console.ReadKey();
                                    break;
                                }
                            }

                        }
                        if (p == 'n' || p == 'N')
                        {
                            Console.WriteLine("Turno perdido :(");
                            Console.WriteLine("Apreta una tecla para continuar!!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("opción no valida, ingresela nuevamente!!");

                        }
                        boolaux1 = false;
                        break;
                    }
                    if (opcion == 1)
                    {
                        Bitmon act1 = null;
                        Bitmon act2 = null;
                        foreach (Bitmon b in participantes[1].equipo)
                        {
                            if (b.estadolucha == "activo")
                            {
                                act1 = b;
                            }
                        }
                        foreach (Bitmon b in participantes[0].equipo)
                        {
                            if (b.estadolucha == "activo")
                            {
                                act2 = b;
                            }
                        }
                        Console.WriteLine("Ataques disponible de " + act1.nombre);
                        int counter = 1;
                        foreach (Poder p in act1.poderes)
                        {
                            Console.WriteLine(counter + ".- Nombre: " + p.nombre + ", Costo: " + p.costo + ", Danio: " + p.danio + ", Tipo: " + p.tipo + ", Ulti: " + p.tipo);
                            counter++;
                        }
                        Poder power;
                        while (true)
                        {
                            int poderelegido;
                            Console.WriteLine("Ingrese el número del poder elegido para atacar al enemigo: ");
                            try
                            {
                                poderelegido = Convert.ToInt32(Console.ReadLine()) - 1;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Formato no aceptado");
                                continue;
                            }
                            if (poderelegido < 0 || poderelegido > 3)
                            {
                                Console.WriteLine("opción no valida, ingrese nuevamente");
                                continue;
                            }
                            else
                            {
                                power = act1.poderes[poderelegido];
                                break;
                            }
                        }

                        act2 = act1.Ataca(act2, power);
                        foreach (Bitmon b in participantes[0].equipo)
                        {
                            if (b.nombre == act2.nombre)
                            {
                                b.vida = act2.vida;
                                b.estadosalud = act2.estadosalud;
                                b.estadolucha = act2.estadolucha;
                                b.stamina = act2.stamina;
                                break;
                            }
                        }

                        Console.WriteLine("Datos de los Bitmons Finalizado este turno");
                        Console.WriteLine("Bitmon de " + participantes[0].nombre);
                        foreach (Bitmon b in participantes[0].equipo)
                        {
                            if (b.estadolucha == "activo")
                            {
                                Console.WriteLine(b.nombre + "->VIDA->" + b.vida + "->STAMINA->" + b.stamina + "->Estado->:" + b.estadolucha);
                            }

                        }
                        Console.WriteLine("Bitmon de " + participantes[1].nombre);
                        foreach (Bitmon b in participantes[1].equipo)
                        {
                            if (b.estadolucha == "activo")
                            {
                                Console.WriteLine(b.nombre + "->VIDA->" + b.vida + "->STAMINA->" + b.stamina + "->Estado->:" + b.estadolucha);
                            }

                        }
                        
                        Console.WriteLine("Presione cualquier letra para seguir jugando!");
                        Console.ReadKey();
                        Console.Clear();
                        boolaux1 = false;
                    }

                    else
                    {
                        Console.WriteLine("Opción inválida, por favor, Ingresela Nuevamente!!");
                        Console.Clear();
                        continue;
                        
                    }
                }
            }
           
        }
    
       
    }
}


