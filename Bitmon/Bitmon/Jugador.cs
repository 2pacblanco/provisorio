using System;
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

        public Jugador(List<Bitmon> bitmons, List<Bitmon> equipo,string nombre, int id)
        {
            this.bitmons = bitmons;
            this.equipo = equipo;
            this.nombre = nombre;
            this.id = id;
        }

    }
}
