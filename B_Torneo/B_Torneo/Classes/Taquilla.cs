using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Torneo.Classes
{
    public class Taquilla
    {
        // La clase Taquilla sirve para vender las boletas provenientes de 
        // cada enfrentamiento. Esta pertenece a cada escenario pero
        // a través del método vender_boleta, toma un enfrentamiento 
        // y modifica las listas de boletas de este

        // Cantidad máxima de boletas que se pueden vender en un solo tirón
        private readonly static byte cantidad_maxima_boletas = 10;

        private byte numero;
        private bool abierta;

        public Taquilla(byte numero) 
        { 
            Numero = numero;
            abierta = true;
        }
        public bool Abierta { get => abierta; }
        public byte Numero { get => numero; private set => numero = value; }

        public void Abrir_taquilla(Enfrentamiento enfrentamiento) 
        { 
            try 
            { 
                if (!abierta && enfrentamiento.L_disponibles.Count > 0) abierta = true; 
                else throw new Exception("No se puede abrir una taquilla que ya está abierta o sin boletas para vender"); 
            } 
            catch (Exception error) { throw new Exception("Ocurrió un error abriendo la caja\n" + error); } 
        }
        public void Cerrar_taquilla() 
        { 
            try 
            { 
                if (abierta) abierta = false; 
                else throw new Exception("No se puede cerrar una taquilla que ya está cerrada"); 
            } 
            catch (Exception error) { throw new Exception("Ocurrió un error cerrando la caja\n" + error); } 
        }
        
        // Método para vender las boletas provenientes del enfrentamiento que este toma como parámetro
        public string Vender_boleta(byte cantidad, Enfrentamiento enfrentamiento)
        {
            try
            {
                // String a retornar y lista auxiliar de boletas que permite
                // desplegar el número de las boletas del retorno de manera correcta
                string retorno = "";
                List<Boleta> l_vender = new List<Boleta>();
                // Valida que la taquilla esté abierta, que la cantidad sea menor del máximo y que si hayan suficientes boletas
                if (abierta && cantidad <= cantidad_maxima_boletas && enfrentamiento.L_disponibles.Count >= cantidad)
                {
                    for (byte i = 0; i < cantidad; i++)
                    {
                        enfrentamiento.L_vendidas.Add(enfrentamiento.L_disponibles[0]);
                        l_vender.Add(enfrentamiento.L_disponibles[0]);
                        enfrentamiento.L_disponibles.RemoveAt(0);
                        // Se genera el retorno con el formato deseado
                        retorno += "Boleta número: " + l_vender[i].Numero + "\n" +
                                   "Torneo: " + enfrentamiento.Torneo_actual + "\n" + 
                                   "Enfrentamiento: " + enfrentamiento.ToString() + "\n" + 
                                   "Fecha y Hora: " + enfrentamiento.Fecha_hora.DayOfWeek + ", " +  
                                   enfrentamiento.Fecha_hora.Day + " of " + enfrentamiento.Fecha_hora.ToString("MMMM") +
                                   "  " + enfrentamiento.Fecha_hora.Year + ", " + enfrentamiento.Fecha_hora.TimeOfDay + 
                                   "\n----------------------------------------------------------------------\n";
                    }
                    return retorno;
                }
                else throw new Exception("No se pueden vender más de 10 boletas a un solo cliente o no hay suficientes boletas en esta taquilla");
            }
            catch (Exception error) { throw new Exception("Ocurrió un error vendiendo un conjunto de boletas\n" + error); }
        }

        public override string ToString()
        {
            return "Taquilla #" + numero;
        }
    }
}
