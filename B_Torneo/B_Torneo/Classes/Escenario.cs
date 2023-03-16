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
        private readonly byte taquillas = 25;

        private string nombre;
        private string direccion;
        private uint capacidad;
        private uint boletas;

        private List<Taquilla> l_taquillas;

        public Escenario(string nombre, string direccion, uint capacidad)
        {
            Nombre = nombre;
            Direccion = direccion;
            Capacidad = capacidad;
            l_taquillas = new List<Taquilla>();
            boletas = capacidad;
            for (byte i = 0; i < taquillas; i++) { Agregar_taquilla((ushort) (boletas / taquillas)); }
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

        public void Agregar_taquilla(ushort cantidad)
        {
            try
            {
                if (cantidad < boletas)
                {
                    Taquilla taquilla = new Taquilla(numero_taquilla, cantidad); 
                    l_taquillas.Add(taquilla);
                    boletas -= cantidad;
                    numero_taquilla++;
                }
                else throw new Exception("La cantidad de boletas entregadas a una taquilla no puede superar el aforo ni la cantidad de boletas restantes");
            }
            catch (Exception error) { throw new Exception("Ocurrió un problema agregando la taquilla \n" + error); }
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}

