using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Torneo.Classes
{
    public class Taquilla
    {
        private readonly static byte cantidad_maxima_boletas = 10;

        private byte numero;
        private bool abierta;
        private ushort cantidad_boletas;
        private List<Boleta> l_disponibles; 
        private List<Boleta> l_vendidas; 
        public Taquilla(byte numero, ushort cantidad_boletas) 
        { 
            this.numero = numero; 
            abierta = false;
            this.cantidad_boletas = cantidad_boletas;
            l_disponibles = new List<Boleta>();
            l_vendidas = new List<Boleta>();
            for (int i = 0; i < cantidad_boletas; i++) { l_disponibles.Add(new Boleta()); }
        }
        public bool Abierta { get => abierta; }
        public void Abrir_taquilla() 
        { 
            try 
            { 
                if (!abierta && l_disponibles.Count > 0) abierta = true; 
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
        
        public void Vender_boleta()
        {
            try
            {
                if (abierta && l_disponibles.Count > 0)
                {
                    l_vendidas.Add(l_disponibles[0]);
                    l_disponibles.RemoveAt(0);
                }
                else throw new Exception("No quedan boletas en esta taquilla");
            }
            catch (Exception error) { throw new Exception("Ocurrió un error vendiendo una boleta individual\n" + error); }
        }
        public void Vender_boleta(byte cantidad)
        {
            try
            {
                if (abierta && cantidad <= cantidad_maxima_boletas && l_disponibles.Count >= cantidad)
                {
                    for (byte i = 0; i < cantidad; i++)
                    {
                        l_vendidas.Add(l_disponibles[0]);
                        l_disponibles.RemoveAt(0);
                    }
                }
                else throw new Exception("No se pueden vender más de 10 boletas a un solo cliente o no hay suficientes boletas en esta taquilla");
            }
            catch (Exception error) { throw new Exception("Ocurrió un error vendiendo un conjunto de boletas\n" + error); }
        }
    }
}
