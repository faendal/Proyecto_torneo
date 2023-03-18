using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Torneo.Classes
{
    public class Escenario
    {
        public static byte numero_taquilla = 1;
        public static readonly byte taquillas = 25;

        private string nombre;
        private string direccion;
        private uint capacidad;
        private List<Taquilla> l_taquillas;

        public Escenario(string nombre, string direccion, uint capacidad)
        {
            Nombre = nombre;
            Direccion = direccion;
            Capacidad = capacidad;
            L_taquillas = new List<Taquilla>();
            for (byte i = 0; i < taquillas; i++) 
            { 
                L_taquillas.Add(new Taquilla(numero_taquilla));
                numero_taquilla++;
            }
            numero_taquilla = 1;
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
        public string Direccion
        {
            get => direccion.ToUpper();
            set
            {
                if (!String.IsNullOrEmpty(value) || !String.IsNullOrWhiteSpace(value)) direccion = value.ToUpper();
                else throw new Exception("Debe ingresar un nombre válido");
            }
        }
        public uint Capacidad
        {
            get => capacidad;
            set
            {
                if (value < 0 || value < Torneo.capacidad_min) throw new Exception("Ingrese una capacidad válida");
                else capacidad = value;
            }
        }

        public List<Taquilla> L_taquillas { get => l_taquillas; private set => l_taquillas = value; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}

