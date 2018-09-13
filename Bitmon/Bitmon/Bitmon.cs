using System; using System.Collections.Generic; using System.Linq; using System.Text; using System.Threading.Tasks;  namespace Bitmon {     public class Bitmon     {         public int vida, stamina, defensa,ataque;         public string nombre, tipo, estadolucha;         public List<Poder> poderes;          public Bitmon(int vida, int stamina, int defensa, int ataque, string nombre, string tipo, string estadolucha, List<Poder> poderes)         {             this.vida = vida;             this.stamina = stamina;             this.defensa = defensa;             this.ataque = ataque;             this.nombre = nombre;             this.tipo = tipo;             this.estadolucha = estadolucha;             this.poderes = poderes;         }          public Bitmon Ataca(Bitmon atacado, Poder pow)
        {
            double defensareal = atacado.defensa * (0.5);//esto nos pareció necesario para hacer un poco más rápido y fluido el juego
            double ataquereal = pow.danio + ataque;
            //reduccion de vida
            if (tipo == "Normal")
            {
                atacado.vida = Convert.ToInt32(ataquereal - defensareal);
            }
            if(tipo == "Electricidad")
            {
                if(atacado.tipo == "")
            }





        }      } } 