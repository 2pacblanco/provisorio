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
                            break;
                        }
                        else { continue; }
                        
                    }
                    aux1 = false;
                }
                Console.Clear();
            }
        }
        public void CambiarAct()
        {
            foreach (Jugador j in participantes)
            {
                int counter = 1;

                Console.WriteLine(j.nombre + " Su pokemon activo es \n");

                foreach (Bitmon b in j.equipo)
                {


                    if (b.estadolucha == "activo")
                    {
                        Console.WriteLine(counter + ".- " + "Nombre: " + b.nombre + " Tipo: " + b.tipo + "\n");
                    }


                }
                Console.WriteLine(j.nombre + " Desea cambiar su Bitmon Activo?");
                string resp = Console.ReadLine();
                if (resp == "si")
                {

                    Console.WriteLine(j.nombre + " sus pokemones disponibles para cambiar son \n");

                    foreach (Bitmon b in j.equipo)
                    {
                        if (b.estadolucha != "activo")
                        {
                            Console.WriteLine(".- " + "Nombre: " + b.nombre + " Tipo: " + b.tipo + "\n");
                        }
                    }
                    Console.WriteLine(j.nombre + "Por cual bitmon de los anteriores desea cambiar su Bitmon activo");
                    string bitMov = Console.ReadLine();
                    foreach (Bitmon b in j.equipo)
                    {
                        if (b.estadolucha == "activo")
                        {
                            b.estadolucha = "null";
                        }
                        if (b.nombre == bitMov)
                        {
                            b.estadolucha = "activo";
                            Console.WriteLine("se ha cambiado el bitmon activo por otro");
                        }

                    }
                    Console.WriteLine("ahora su pokemon activo nuevo es ");
                    foreach(Bitmon b in j.equipo)
                    {
                        if (b.estadolucha =="activo")
                        {
                            Console.WriteLine(".- " + "Nombre: " + b.nombre + " Tipo: " + b.tipo + "\n");
                        }
                            
                    }
                    Console.Clear();

                }
            }

        }

        public void PeleaTurno(){
            if (turno == 1 || turno == 0 )
            {
                while (true)
                {
                    Console.WriteLine("Turno de " + participantes[0].nombre );
                    Console.WriteLine("Por favor, eliga su accion!! (Ingrese el numero asociado a la accion)");
                    Console.WriteLine("1.- Atacar ");
                    Console.WriteLine("2.- Descansar ");
                    Console.WriteLine("3.- Cambiar ");
                    int opcion = Convert.ToInt32(Console.ReadLine());
                    if (opcion == 3)
                    {
                        CambiarAct();//arreglar metodo
                        break;
                    }
                    if (opcion == 2)
                    {
                        Console.WriteLine("Está seguro que quieres que este bitmon descanse? [S/N]");
                        string p = Console.ReadLine();
                        if (p == "s" || p == "S")
                        {
                            foreach (Bitmon b in participantes[0].equipo)
                            {
                                if (b.estadolucha == "activo")
                                {
                                    b.stamina = b.stamina + 10;
                                    b.defensa = b.defensa + 20;
                                    break;
                                }

                            }
                        }
                        if (p == "n" || p == "N")
                        {
                            continue;
                        }
                    }
                    if (opcion==1){
                        Bitmon act1 = null;
                        Bitmon act2 = null;
                        foreach(Bitmon b in participantes[0].equipo){
                            if (b.estadolucha=="activo"){
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
                        Console.WriteLine("Ataques disponible de " + act1.nombre );
                        int counter = 1;
                        foreach(Poder p in act1.poderes){
                            Console.WriteLine(counter+".- Nombre: " + p.nombre + ", Costo: " + p.costo + ", Danio: " + p.danio + ", Tipo: " + p.tipo + ", Ulti: " + p.tipo );
                            counter++;
                        }
                        int poderelegido;
                        while (true)
                        {
                            Console.WriteLine("Ingrese el número del poder elegido para atacar al enemigo: ");
                            poderelegido = Convert.ToInt32(Console.ReadLine()) - 1;
                            if (poderelegido < 0 || poderelegido > 4)
                            {
                                Console.WriteLine("opción no valida, ingrese nuevamente");
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                        Poder power = act1.poderes[poderelegido];
                        act2 = act1.Ataca(act2,power);
                        int counter2 = 0;
                        foreach(Bitmon b in participantes[1].equipo)
                        {
                            if (b.estadolucha == "activo")
                            { 
                                break;
                            }
                            counter2++;
                        }
                        participantes[1].equipo[counter2] = act2;

                        foreach (Bitmon b in participantes[1].equipo)
                        {
                            if (b.estadolucha == "activo")
                            {
                                Console.WriteLine("Vida poquemon afectado->" +b.vida);
                            }
                  
                        }



                    }




                }
            }
        }


    }

}

