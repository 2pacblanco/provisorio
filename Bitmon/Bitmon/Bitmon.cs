using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmon
{
    public class Bitmon
    {
        public int vida, stamina, defensa;
        public string nombre, tipo, estadolucha;
        public List<Poder> poderes;

        public Bitmon(int vida, int stamina, int defensa, string nombre, string tipo, string estadolucha, List<Poder> poderes)
        {
            this.vida = vida;
            this.stamina = stamina;
            this.defensa = defensa;
            this.nombre = nombre;
            this.tipo = tipo;
            this.estadolucha = estadolucha;
            this.poderes = poderes;
        }
        
    }
}
