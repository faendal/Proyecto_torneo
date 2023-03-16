using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Torneo.Classes
{
    public class Equipo
    {
        private string nombre;
        private List<Jugador> l_jugadores;
        private Tecnico tecnico;

        public Equipo(string nombre, List<Jugador> l_jugador, Tecnico tecnico)
        {
            Nombre = nombre;
            L_jugadores = l_jugador;
            this.tecnico = tecnico;
        }

        public Equipo(string nombre)
        {
            Nombre = nombre;
        }

        public string Nombre
        {
            get => nombre.ToUpper();
            set
            {
                if (!String.IsNullOrEmpty(value) || !String.IsNullOrWhiteSpace(value)) nombre = value.ToUpper();
                else throw new Exception("Debe ingresar un nombre válido");
            }
        }
        public List<Jugador> L_jugadores
        {
            get => l_jugadores;
            set
            {
                if (value.Count == Torneo.nro_max_jugadores) l_jugadores = value;
                else throw new Exception("El equipo debe contener exactamente " + Torneo.nro_max_jugadores + " jugadores");
            }
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
