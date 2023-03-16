using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Torneo.Classes
{
    public class Jugador
    {
        public enum l_posiciones { Arquero, Defensa, Medio, Delantero };

        private string nombre;
        private DateTime f_nacimiento;
        private string nacionalidad;
        private ushort numero;
        private l_posiciones posicion;
        private byte edad;

        public string Nombre
        {
            get => nombre.ToUpper();
            set
            {
                if (!String.IsNullOrEmpty(value) || !String.IsNullOrWhiteSpace(value)) nombre = value.ToUpper();
                else throw new Exception("Debe ingresar un nombre válido");
            }
        }
        public DateTime F_nacimiento
        { 
            get => f_nacimiento; 
            set
            {
                if ((DateTime.Now.Year - value.Year) < Torneo.edad_minima) throw new Exception("La edad del jugador es menor a la permitida");
                else
                {
                    f_nacimiento = value;
                    edad = (byte)(DateTime.Now.Year - value.Year);
                }
            }
        }
        public string Nacionalidad
        {
            get => nacionalidad.ToUpper();
            set
            {
                if (!String.IsNullOrEmpty(value) || !String.IsNullOrWhiteSpace(value)) nacionalidad = value.ToUpper();
                else throw new Exception("Debe ingresar un nombre válido");
            }
        }
        public ushort Numero 
        { 
            get => numero;
            set
            {
                if (value >=0 && value <= 999) { numero = value; }
                else throw new Exception("El valor del numero debe estar entre 0 y 999");
            }
        }

        public Jugador(string nombre, DateTime f_nacimiento, string nacionalidad, ushort numero, l_posiciones posicion)
        {
            Nombre = nombre;
            F_nacimiento = f_nacimiento;
            Nacionalidad = nacionalidad;
            Numero = numero;
            this.posicion = posicion;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
