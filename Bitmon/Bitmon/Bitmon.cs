using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmon
{
    public class Bitmon
    {
        public int vida, stamina, defensa,ataque;
        public string nombre, tipo, estadolucha,estadosalud;
        public List<Poder> poderes;

        public Bitmon(int vida, int stamina, int defensa, int ataque, string nombre, string tipo, string estadolucha, List<Poder> poderes,string estadosalud)
        {
            this.vida = vida;
            this.stamina = stamina;
            this.defensa = defensa;
            this.ataque = ataque;
            this.nombre = nombre;
            this.tipo = tipo;
            this.estadolucha = estadolucha;
            this.poderes = poderes;
            this.estadosalud = estadosalud;
        }

        public Bitmon Ataca(Bitmon atacado, Poder pow)
        {
            double defensareal = atacado.defensa * (0.3);//esto nos pareció necesario para hacer un poco más rápido y fluido el juego
            double ataquereal = pow.danio + ataque;
            //reduccion de vida
            if (pow.tipo == "Normal")
            {
                atacado.vida = atacado.vida - Convert.ToInt32(ataquereal - defensareal);
                Console.WriteLine("Daño de ataque escogido: "+ Convert.ToInt32(ataquereal - defensareal));
            }
            if(pow.tipo == "Electro")
            {
                if(atacado.tipo == "Agua")//aumentaremos 30%+ el ataque y la defensa la redujiremos 30%-
                {
                    atacado.vida = atacado.vida - Convert.ToInt32(ataquereal*1.3 - defensareal*0.7);
                    Console.WriteLine("[CRIT]Daño de ataque escogido: " + Convert.ToInt32(ataquereal * 1.3 - defensareal * 0.7));
                }
                if (atacado.tipo == "Hielo")//ataque 30%- y defensa 30%+
                {
                    atacado.vida = atacado.vida - Convert.ToInt32(ataquereal*0.7 - defensareal*1.3);
                    Console.WriteLine("[CRIT]Daño de ataquce escogido: " + Convert.ToInt32(ataquereal * 0.7 - defensareal * 1.3));
                }
                if (atacado.tipo == "Normal" || atacado.tipo=="Fuego" || atacado.tipo=="Electro")
                {
                    atacado.vida = atacado.vida - Convert.ToInt32(ataquereal - defensareal);
                    Console.WriteLine("1.-Daño de ataque escogido: " + Convert.ToInt32(ataquereal - defensareal));
                }
            }
            if (pow.tipo == "Agua")
            {
                if (atacado.tipo == "Fuego")//aumentaremos 30%+ el ataque y la defensa la redujiremos 30%-
                {
                    atacado.vida = atacado.vida - Convert.ToInt32(ataquereal * 1.3 - defensareal * 0.7);
                    Console.WriteLine("[CRIT]Daño de ataque escogido: " + Convert.ToInt32(ataquereal * 1.3 - defensareal * 0.7));
                }
                if (atacado.tipo == "Electro")//ataque 30%- y defensa 30%+
                {
                    atacado.vida = atacado.vida - Convert.ToInt32(ataquereal * 0.7 - defensareal * 1.3);
                    Console.WriteLine("[CRIT]Daño de ataque escogido: " + Convert.ToInt32(ataquereal * 0.7 - defensareal * 1.3));
                }
                if(atacado.tipo == "Normal" || atacado.tipo == "Agua" || atacado.tipo == "Hielo")
                {
                    atacado.vida = atacado.vida - Convert.ToInt32(ataquereal - defensareal);
                    Console.WriteLine("2.-Daño de ataque escogido: " + Convert.ToInt32(ataquereal - defensareal));
                }
            }
            if (pow.tipo == "Hielo")
            {
                if (atacado.tipo == "Electro")//aumentaremos 30%+ el ataque y la defensa la redujiremos 30%-
                {
                    atacado.vida = atacado.vida - Convert.ToInt32(ataquereal * 1.3 - defensareal * 0.7);
                    Console.WriteLine("[CRIT]Daño de ataque escogido: " + Convert.ToInt32(ataquereal * 1.3 - defensareal * 0.7));
                }
                if (atacado.tipo == "Fuego")//ataque 30%- y defensa 30%+
                {
                    atacado.vida = atacado.vida - Convert.ToInt32(ataquereal * 0.7 - defensareal * 1.3);
                    Console.WriteLine("[CRIT]Daño de ataque escogido: " + Convert.ToInt32(ataquereal * 0.7 - defensareal * 1.3));
                }
                if (atacado.tipo == "Normal" || atacado.tipo == "Agua" || atacado.tipo == "Hielo")
                {
                    atacado.vida = atacado.vida - Convert.ToInt32(ataquereal - defensareal);
                    Console.WriteLine("3.-Daño de ataque escogido: " + Convert.ToInt32(ataquereal - defensareal));
                }
            }
            if (pow.tipo == "Fuego")
            {
                if (atacado.tipo == "Hielo")//aumentaremos 30%+ el ataque y la defensa la redujiremos 30%-
                {
                    atacado.vida = atacado.vida - Convert.ToInt32(ataquereal * 1.3 - defensareal * 0.7);
                    Console.WriteLine("[CRIT]Daño de ataque escogido: " + Convert.ToInt32(ataquereal * 1.3 - defensareal * 0.7));
                }
                if (atacado.tipo == "Agua")//ataque 30%- y defensa 30%+
                {
                    atacado.vida = atacado.vida - Convert.ToInt32(ataquereal * 0.7 - defensareal * 1.3);
                    Console.WriteLine("[CRIT]Daño de ataque escogido: " + Convert.ToInt32(ataquereal * 0.7 - defensareal * 1.3));
                }
                if (atacado.tipo == "Normal" || atacado.tipo == "Fuego" || atacado.tipo == "Electro")
                {
                    atacado.vida = atacado.vida - Convert.ToInt32(ataquereal - defensareal);
                    Console.WriteLine("4.-Daño de ataque escogido: " + Convert.ToInt32(ataquereal - defensareal));
                }
            }

            //reduccion stamina
            stamina = stamina - pow.costo;

            if(pow.ulti != null)
            {
                atacado.estadosalud = pow.ulti;
            }

            if (atacado.vida <= 0)
            {
                atacado.vida = 0;
                atacado.estadolucha = "muerto";
                Console.WriteLine($"{atacado.nombre} ha sido vencido :(. \n Por favor, eliga otro Bitmon! ");
            }

            return atacado;

        }

    }
}
